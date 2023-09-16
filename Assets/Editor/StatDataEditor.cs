using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(Leveling))]
public class StatDataEditor : Editor
{
    Vector2 scroll;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();

        Leveling data = (Leveling)target;

        scroll = EditorGUILayout.BeginScrollView(scroll, GUILayout.MaxHeight(300));

        for (int i = 0; i < 100; i++)
        {
            EditorGUILayout.BeginHorizontal("box");
            EditorGUILayout.LabelField("Level " + (i));
            EditorGUILayout.LabelField(((int)data.xpNeededPerLevel.Evaluate(i)) + " XP");
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndScrollView();
    }
}
