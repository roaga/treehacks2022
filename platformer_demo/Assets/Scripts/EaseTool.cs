using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseTool : MonoBehaviour
{
    public GameObject test;
    public int hello;
    public int hello2;

    public GameObject[] paras;
    public int numOutput;
    // public Fu rewardFunc;

    // Start is called before the first frame update
    void Start()
    {
        print("");// yo
    }

    public void printArr(String[] arr)
    {
        print("Printing arr " + arr.Length);
        for (int i = 0; i < arr.Length; i++)
        {
            print(arr[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
