using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (DamageControl))]
public class DamageControl_Editor : Editor {

    public override void OnInspectorGUI()
    {
        DamageControl obj = target as DamageControl;

        obj.type = (HPControlType)EditorGUILayout.EnumPopup("射出親", obj.type);

        obj.damege = EditorGUILayout.FloatField("ダメージ",obj.damege);

    }

}
