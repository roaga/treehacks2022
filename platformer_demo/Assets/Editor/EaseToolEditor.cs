using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EaseTool))]
public class EaseToolEditor : Editor
{
    float gridSize = 0.0f;


    public override void OnInspectorGUI()
    {
        EaseTool easeTool = (EaseTool)target;

        base.OnInspectorGUI();

        /*
        GUILayout.Space(10);

        easeTool.numParas = EditorGUILayout.IntField("Parameters Num: ", easeTool.numParas);

        if (easeTool.paras == null)
        {
            easeTool.paras = new List<Param>();
        }
        while (easeTool.paras.Count < easeTool.numParas)
        {
            easeTool.paras.Add(new Param("", 0, 0, 0, 0));
        }

        for (int i = 0; i < easeTool.numParas; i++)
        {
            GUILayout.Space(10);
            GUILayout.Label("Parameter " + i);
            easeTool.paras[i].name = EditorGUILayout.TextField("Name: ", easeTool.paras[i].name);

            easeTool.paras[i].defaultValue = EditorGUILayout.FloatField("Default ", easeTool.paras[i].defaultValue);

            easeTool.paras[i].min = EditorGUILayout.FloatField("Min: ", easeTool.paras[i].min);

            easeTool.paras[i].max = EditorGUILayout.FloatField("Max: ", easeTool.paras[i].max);

            easeTool.paras[i].targetReward = EditorGUILayout.FloatField("Target reward: ", easeTool.paras[i].targetReward);
        }

        GUILayout.Space(10);

        easeTool.PrintParas();

        */
    }
}
