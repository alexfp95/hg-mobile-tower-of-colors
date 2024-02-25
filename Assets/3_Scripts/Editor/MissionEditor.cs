using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Mission))]
public class MissionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUI.enabled = false;
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_id"));
        GUI.enabled = true;
        EditorGUILayout.PropertyField(serializedObject.FindProperty("title"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("difficulty"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("steps"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("rewards"));
        serializedObject.ApplyModifiedProperties();
    }
}
