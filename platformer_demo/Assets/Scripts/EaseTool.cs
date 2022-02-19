using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EaseTool : MonoBehaviour
{
    public List<Param> paras;
    public int numParas;
    // public func rewardFunc;
    private int numFrames;
    private Optimziation optimizer;
    public int framesPerUpdate; // update params every N frames
    void Start() {this.optimizer = new Optimziation(paras);}

    // Update is called once per frame
    void Update()
    {
        numFrames++;
        if (numFrames % framesPerUpdate == 0)
        {
            optimizer.updateValues();
            this.paras = optimizer.parameters;
        }
    }

    public void PrintParas()
    {
        string ret = "List: ";
        for (int i = 0; i < paras.Count; i++)
        {
            ret += paras[i].name + " ";
        }
        print(ret);
    }
}
