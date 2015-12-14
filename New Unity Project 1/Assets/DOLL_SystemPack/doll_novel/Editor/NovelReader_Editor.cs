using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(NovelReader))]
public class NovelReader_Editor : Editor {

    public override void OnInspectorGUI()
    {
        NovelReader obj = target as NovelReader;

        obj.textAsset = (TextAsset)EditorGUILayout.ObjectField("テキストアセット", obj.textAsset, typeof(TextAsset),true);

        obj.OneStringTime = EditorGUILayout.FloatField("１文字の読み込み速度(秒)", obj.OneStringTime);

        obj.clickButton = EditorGUILayout.TextField("クリックに対応するパッドボタン", obj.clickButton);
        obj.clickKey = EditorGUILayout.TextField("クリックに対応するキー", obj.clickKey);

        EditorGUILayout.Space();

        EditorGUILayout.TextArea(obj.textAsset.text);

        EditorUtility.SetDirty(target);

    }
}
