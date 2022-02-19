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
        base.OnInspectorGUI();

        GUILayout.Space(10);
        GUILayout.Label("Rank function: ");
        GUILayout.Space(5);
        GUILayout.Label("Output Variables Num: ");
        GUILayout.Space(5);

        using (new GUILayout.HorizontalScope())
        {
            GUILayout.Label("Grid Size: ");
            if (GUILayout.Button("Snap Selecttion"))
            {

            }
        }
        GUILayout.Space(10);
    }
}
