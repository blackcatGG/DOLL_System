using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (SI_CharacterMoveControl))]
public class SI_CharacterMoveControl_Editor : Editor {

    bool editParameter = false;

    public override void OnInspectorGUI()
    {
        SI_CharacterMoveControl obj = target as SI_CharacterMoveControl;

        obj.parameter = (CharacterSpeedParameter)EditorGUILayout.ObjectField("パラメータ",obj.parameter,typeof(CharacterSpeedParameter));

        if (!editParameter)
        {
            if (GUILayout.Button("パラメータを編集"))
            {
                editParameter = true;
            }
        }
        else
        {
            CharacterSpeedParameter_Editor.InspectorSopprt(obj.parameter);
            if (GUILayout.Button("編集を終了"))
            {
                editParameter = false;
            }
        }
        EditorUtility.SetDirty(target);

    }

}
