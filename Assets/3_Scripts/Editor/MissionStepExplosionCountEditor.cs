using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MissionStepExplosionCount))]
public class MissionStepExplosionCountEditor : Editor
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
        EditorGUILayout.PropertyField(serializedObject.FindProperty("count"));
        serializedObject.ApplyModifiedProperties();
    }
}
