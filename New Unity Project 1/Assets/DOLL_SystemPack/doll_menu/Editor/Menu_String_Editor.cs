using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(Menu_String))]
public class Menu_String_Editor : Editor {

    public override void OnInspectorGUI()
    {
        Menu_String obj = target as Menu_String;

        obj.now = EditorGUILayout.IntSlider("現在選択されている項目", obj.now, 0, obj.items.Length-1);
        obj.reload = EditorGUILayout.FloatField("リロード(s)", obj.reload);
        obj.move_per = EditorGUILayout.Slider("変化割合/s", obj.move_per, 0.0f, 60.0f);
        obj.anchor = (TextAnchor)EditorGUILayout.EnumPopup("テキストの表示基準点",obj.anchor);
        float scale = obj.textScale;
        obj.textScale = EditorGUILayout.Slider("テキストのスケール", obj.textScale, 0.0f, 1.0f);
        if (obj.textScale != scale) {
            for (int i = 0; i < obj.item_object.Length; i++)
            {
                DestroyImmediate(obj.item_object[i]);
            }
            obj.item_object = null;
            GenerateItem(obj);
        }

        if (GUILayout.Button("項目生成", GUILayout.Width(80.0f)))
        {
            GenerateItem(obj);
        }

        if (GUILayout.Button("項目削除", GUILayout.Width(80.0f)))
        {
            for (int i = 0; i < obj.item_object.Length; i++)
            {
                DestroyImmediate(obj.item_object[i]);
            }
            obj.item_object = null;
        }

        SerializedProperty tps = serializedObject.FindProperty("items");
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(tps, new GUIContent("項目設定"), true);
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }
        EditorGUIUtility.LookLikeControls();

        if (GUILayout.Button("カメラを表示する"))
        {
            Menu_Button.CreateMenuCam();
        }

        EditorUtility.SetDirty(target);

    }

    void GenerateItem(Menu_String obj)
    {
        obj.GenerateItemObject();
    }

}
