
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[System.Serializable]
public class Param
{
    /* it definitely makes sense to make param its own class to store potential metadata
    in addition to what I have below. not sure if this is the exact setup we want though
    */
    public string name;
    public float defaultValue;
    public float min;
    public float max;
    public float targetReward;
    public float currentValue;
    public List<(float, float)> data;

    public Param(string name, float defaultValue, float min, float max, float targetReward)
    {
        this.currentValue = defaultValue;
        this.defaultValue = defaultValue;
        this.name = name;
        this.min = min;
        this.max = max;
        this.data = new List<(float, float)>();
        this.targetReward = targetReward;
    }

    public void setValue(float newValue)
    {
        this.currentValue = newValue;
    }

    public float getDefault()
    {
        return this.defaultValue;
    }

    public float getValue()
    {
        return this.currentValue;
    }

    public float getMin()
    {
        return this.min;
    }
    public float getMax()
    {
        return this.max;
    }

    public float getTargetReward()
    {
        return this.targetReward;
    }

    public string getName()
    {
        return this.name;
    }

    public List<(float, float)> getData()
    {
        return this.data;
    }

    public void initializeData()
    {
        this.data = new List<(float, float)>();
    }

    public void addData(float reward)
    {

        if (this.data == null)
        {
            initializeData();
        }

        this.data.Add((currentValue, reward));
        if (data.Count > 1000)
        {
            data = data.GetRange(data.Count - 1000, data.Count);
        }
    }

    void returnToDefault()
    {
        this.currentValue = this.defaultValue;
    }

}