using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(Menu_Camera))]
public class Menu_Camera_Editor : Editor {

    public override void OnInspectorGUI()
    {
        Menu_Camera obj = target as Menu_Camera;

        obj.GetComponent<Camera>().orthographic = true;

        obj.RayLength = EditorGUILayout.Slider("レイの長さ",obj.RayLength,0.0f,20.0f);
        EditorGUILayout.LabelField("マウスターゲット　　"+obj.target);

        EditorGUILayout.Space();

        EditorGUILayout.HelpBox("現状、カメラはorthographicでしか作用しない",MessageType.Info);

        EditorUtility.SetDirty(target);

    }

}
