using System;
using System.Collections.Generic;
using Random;
class ParamEvaluation {
    // using https://docs.microsoft.com/en-us/archive/msdn-magazine/2018/august/test-run-introduction-to-q-learning-using-csharp#wrapping-up as a guide
    // but also not really this is a pretty dumb approach
    public List<Param> paras;
    public List<int> paraValues; // current parameter values
    public List<float> paraWeights; // weights in approximate Q learning
    public float learningRate;
    public int expectedReward; // expected value of reward function

    public ParamEvaluation(List<Param> paras, List<int> paraValues, List<float> paraWeights, float learningRate, int expectedReward) {
      this.paras = paras;
      this.paraValues = paraValues;
      this.paraWeights = paraWeights;
      this.learningRate = learningRate;
      this.expectedReward = expectedRewards;
    }
    List<int> getValues() {
      return this.paraValues;
    }

    List<int> GetRandomNextState(List<int> currentPos) {
      // generate random next state based on current Position, increments
      nextState = new List<int>();
      Random rnd = new Random();
      for(int i=0; i<currentPos.Length; i++) {
        currValue = currentPos[i];
        double num = rnd.NextDouble();
        if (num<0.33) {
          nextState.add(currValue - paras[i].getIncrement());
          paras[i].setValue(currValue - paras[i].getIncrement());
        } else if (num<0.66) {
          nextState.add(currValue);
        } else {
          nextState.add(currValue + paras[i].getIncrement());
          paras[i].setValue(currValue + paras[i].getIncrement());
        }
      }
      return nextState;
    }

    List<int> getNextState(List<int> currentPos) {
      // call getrandomnextstate N times (N = 5?)
      // call evalParam on each one
      // return the list of params with the highest evalParam function value
      List<int> result = new List<int>();
      int N = 5;
      for (int i = 0; i< N; i++){
        nextState = GetRandomNextState(currentPos)
        sum = evalParam(nextState, this.paraWeights)
        result.Add(sum)
      }
      return result
    }

    void updateWeights(int score, int target, List<int> paraValues, List<float> paraWeights) {
      // apply evaluation rule (see whiteboard pic) to each parameter based on score's distance to target score
      // get learning rate with this.learningRate
      paraWeights[i] = paraWeights[i] + (score-target)*this.learningRate*paraValues[i] 
    }

    double evalParam(List<int> pos, List<float> weights) {
      int sum = 0;
      for (int i = 0; i < pos.Length; i++) {
        sum += pos[i]*weights[i];
      }
      return sum;
    }




}