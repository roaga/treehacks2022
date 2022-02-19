using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Param;

public class EaseTool : MonoBehaviour
{
    public Param[] paras;
    public func rewardFunc;
    public int numFrames;
    public int framesPerUpdate; // update params every N frames
    public int[] paraValues;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < paras.Length; i++) {
            paraValues.add(paras[i].getDefault());
        }
    }

    // Update is called once per frame
    void Update()
    {
        numFrames++;
        if (numFrames % framesPerUpdate == 0) {
            // do fancy RL things to recalculate params
            // update all param values with ML stuff
            for(int i = 0; i < paras.Length; i++) {
                paras[i].setValue(paraValues[i]);
            }
        }
    }
}
