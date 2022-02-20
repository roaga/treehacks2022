using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

public class Optimization : MonoBehaviour
{
    public List<Param> parameters;

    private int runs = 0;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     p = new Param("test", 0f, 0f, 0f, 0f);
    //     PostData(p);
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log(p.getValue());
    // }

    public Optimization(List<Param> paras)
    {
        for (int i = 0; i < paras.Count; i++)
        {
            paras[i].currentValue = paras[i].defaultValue;
            paras[i].data = new List<(float, float)>();
        }
        this.parameters = paras;
        for (int i = 0; i < paras.Count; i++)
        {

        }
    }

    public void addData(string name, float reward)
    {
        foreach (Param param in parameters)
        {
            if (param.getName() == name)
            {
                param.addData(reward);
                break;
            }
        }
    }

    public void PrintList()
    {
        string ret = "List: ";
        for (int i = 0; i < parameters.Count; i++)
        {
            ret += parameters[i].name + " ";
        }
        print(ret);
    }

    public void updateValues()
    {
        runs += 1;
        // for each parameter, update value to optimize toward desired goal (or just random change/sample if not enough data)
        foreach (Param param in parameters)
        {

            List<(float, float)> data = param.getData();
            if (data == null)
            {
                continue;
            }
            if (data.Capacity > 10)
            {
                // optimize values!
                optimize(param);
            }
            else
            {
                // random adjustment (5 increments above default, and 5 below default, across range of constraints)
                float defaultVal = param.getDefault();
                if (runs <= 5)
                {
                    float incrementUp = Mathf.Abs(param.getMax() - defaultVal) / 5;
                    param.setValue(param.getValue() + incrementUp);
                }
                else
                {
                    if (runs == 6)
                    {
                        param.setValue(param.getDefault()); // reset when done going up
                    }
                    float incrementDown = Mathf.Abs(param.getMin() - defaultVal) / 5;
                    param.setValue(param.getValue() - incrementDown);
                }
            }
        }
    }

    public List<Param> getParams()
    {
        return parameters;
    }

    private void optimize(Param param)
    {
        // TODO: accomodate target reward and determine when to terminate optimization
        List<(float, float)> data = param.getData();
        float currValue = param.getValue();
        float min = param.getMin();
        float max = param.getMax();
        float targetReward = param.getTargetReward();

        // request flask server
        PostData(param);
    }

    // NETWORKING

    [Serializable]
    public class Data
    {
        public List<float> x = new List<float>();
        public List<float> y = new List<float>();
        public float targetReward;
    }

    public void PostData(Param param)
    {
        Data data = new Data();
        data.targetReward = param.getTargetReward();
        foreach ((float, float) tuple in param.getData())
        {
            data.x.Add(tuple.Item1);
            data.y.Add(tuple.Item2);
            // data.x.Add(i);
            // data.y.Add(UnityEngine.Random.Range(0f, 20f));
        }
        string json = JsonUtility.ToJson(data);
        StartCoroutine(PostRequest("http://0.0.0.0:105/bayes", json, returnVal =>
        {
            param.setValue(returnVal);
        }));
    }

    IEnumerator PostRequest(string uri, string json, System.Action<float> callback)
    {
        var uwr = new UnityWebRequest(uri, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            // Debug.Log("Received: " + uwr.downloadHandler.text);
            yield return uwr.downloadHandler.text;
            float val = float.Parse(uwr.downloadHandler.text, CultureInfo.InvariantCulture.NumberFormat);
            callback(val);
        }
    }

}
