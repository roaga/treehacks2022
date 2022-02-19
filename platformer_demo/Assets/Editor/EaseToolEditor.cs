
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using System;
using System.Linq;

[CustomEditor(typeof(EaseTool))]
public class EaseToolEditor : Editor
{
    float gridSize = 0.0f;
    int index = 0;

    enum fields { Select }

    private void OnEnable()
    {

    }

    public override void OnInspectorGUI()
    {
        EaseTool current = (EaseTool)target;

        base.OnInspectorGUI();
        GUILayout.Space(10);
        using (new GUILayout.HorizontalScope())
        {
            GUILayout.Label("Grid Size: ");
            if (GUILayout.Button("Snap Selecttion"))
            {

            }
        }

        GUILayout.Space(10);
        GUILayout.Label("Rank function: ");
        GUILayout.Space(10);





        current.numOutput = EditorGUILayout.IntField("Output Num: ", current.numOutput);

        for (int i = 0; i < current.numOutput; i++)
        {
            GUILayout.Space(5);
            current.test = (GameObject)EditorGUILayout.ObjectField(current.test, typeof(UnityEngine.Object), true);



            var componentArr = current.test.GetComponents(typeof(Component));
            String[] componentNames = new String[componentArr.Length];
            for (int j = 0; i < componentArr.Length; i++)
            {
                componentNames[j] = componentArr[i].GetType().ToString();
            }
            current.printArr(componentNames);


            // // var propertyValues = current.test.GetType().GetFields();
            // var propertyValues = current.test.GetType().GetProperties();



            // // FieldInfo[] valuesArr = new FieldInfo[propertyValues.Length];
            // String[] names = new String[propertyValues.Length];
            // for (int j = 0; i < propertyValues.Length; i++)
            // {
            //     names[j] = propertyValues[j].Name;
            // }
            // current.printArr(names);
            // index = EditorGUILayout.Popup(index, names);

        }
        GUILayout.Space(10);


        GUILayout.Space(10);


    }
}
