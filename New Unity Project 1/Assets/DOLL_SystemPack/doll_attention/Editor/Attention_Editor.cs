using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (Attention))]
public class Attention_Editor : Editor {

    public override void OnInspectorGUI()
    {
        Attention obj = target as Attention;

        obj.OneStringTime = EditorGUILayout.FloatField("１文字の読み込み速度(秒)", obj.OneStringTime);

        obj.back = (MeshRenderer)EditorGUILayout.ObjectField("バックの帯", obj.back, typeof(MeshRenderer),true);

        if (obj.back != null)
        {
            obj.per = EditorGUILayout.Slider("帯の色の変化率", obj.per, 0.0f, 60.0f);

            obj.backColor = EditorGUILayout.ColorField("帯の色", obj.backColor);

            if (GUILayout.Button("帯を削除", GUILayout.Width(80.0f)))
            {
                DestroyImmediate(obj.back.gameObject);
            }

        }
        else
        {
            if (GUILayout.Button("帯を生成", GUILayout.Width(80.0f)))
            {
                obj.SetBack(obj.backColor);
            }
        }


    }

}
