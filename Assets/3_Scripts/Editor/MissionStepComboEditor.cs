using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MissionStepCombo))]
public class MissionStepComboEditor : Editor
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
        EditorGUILayout.PropertyField(serializedObject.FindProperty("reachCount"));
        serializedObject.ApplyModifiedProperties();
    }
}
