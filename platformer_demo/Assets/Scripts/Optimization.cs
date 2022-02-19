using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimization
{
    public List<Param> parameters;

    private int runs = 0;
    
    public Optimization(List<Param> paras) {
        this.parameters = paras;
    }

    public void addData(string name, float reward) {
        foreach (Param param in parameters) {
            if (param.getName() == name) {
                param.addData(reward);
            }
        }
    }

    public void updateValues() {
        runs += 1;
        // for each parameter, update value to optimize toward desired goal (or just random change/sample if not enough data)
        foreach (Param param in parameters) {
            if (param.getData().Count > 10) {
                // optimize values!
                optimize(param);
            } else {
                // random adjustment (5 increments above default, and 5 below default, across range of constraints)
                float defaultVal = param.getDefault();
                if (runs <= 5) {
                    float incrementUp = Mathf.Abs(param.getMax() - defaultVal) / 5;
                    param.setValue(param.getValue() + incrementUp);
                } else {
                    if (runs == 6) {
                        param.setValue(param.getDefault()); // reset when done going up
                    }
                    float incrementDown = Mathf.Abs(param.getMin() - defaultVal) / 5;
                    param.setValue(param.getValue() - incrementDown);
                }
            }
        }
    }

    public List<Param> getParams() {
        return parameters;
    }

    private float optimize(Param param) {
        List<(float, float)> data = param.getData();
        float currValue = param.getValue();
        float min = param.getMin();
        float max = param.getMax();
        float targetReward = param.getTargetReward();

        // TODO

        return 0f;
    }


    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
