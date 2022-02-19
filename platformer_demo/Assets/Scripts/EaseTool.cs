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
    public int framesPerUpdate; // update params every N frames
    // public List<int> paraValues;
    // public int expectedReward; // expected score
    // public ParamEvaluation evaluator;
    // // Start is called before the first frame update
    void Start()
    {
        // for(int i = 0; i < paras.Length; i++) {
        //     paraValues.add(paras[i].getDefault());
        // }
        // paraWeights = new List<double>(); // TODO: set to default weights (everything is 1 or something)
        // evaluator = new ParamEvaluation(paras, paraValues, paraWeights, 0.5, expectedReward);
    }

    // Update is called once per frame
    void Update()
    {
        numFrames++;
        if (numFrames % framesPerUpdate == 0)
        {
            int score = -1; // TODO: pass in score from most recent frames
            // evaluator.updateWeights(score, target, paraValues, paraWeights);
            // newParams = evaluator.getNextState(paraValues);
            // // update all param values with ML stuff
            // for(int i = 0; i < paras.Length; i++) {
            //     paras[i].setValue(newParams[i]);
            // }
        }
    }

    public void PrintParas()
    {
        string ret = "List: ";
        for (int i = 0; i < paras.Count; i++)
        {
            ret += paras[i].name + " ";
        }
        // print(ret);
    }
}
