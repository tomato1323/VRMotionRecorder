using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GetStatus))]
public class SystemEditor : Editor
{
    public override void OnInspectorGUI(){
        GetStatus  gs = target as GetStatus;
        base.OnInspectorGUI();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("TimerStart")){
        gs.Timer_Start();
        }
        if (GUILayout.Button("DataExport")){
        gs.Export2CSV();
        }
        EditorGUILayout.EndHorizontal();
    }
}
