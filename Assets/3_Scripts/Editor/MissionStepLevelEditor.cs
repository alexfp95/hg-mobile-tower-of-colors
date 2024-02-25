using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MissionStepLevel))]
public class MissionStepLevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUI.enabled = false;
        if (serializedObject.FindProperty("_id") != null)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_id"));
        }
        GUI.enabled = true;
        EditorGUILayout.PropertyField(serializedObject.FindProperty("reachLevel"));
        serializedObject.ApplyModifiedProperties();
    }
}
