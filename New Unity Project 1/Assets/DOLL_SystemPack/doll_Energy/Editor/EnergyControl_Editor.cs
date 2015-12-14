using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(EnergyControl))]
public class EnergyControl_Editor : Editor {

    public override void OnInspectorGUI()
    {
        EnergyControl obj = target as EnergyControl;

        obj.now = EditorGUILayout.Slider("現在のエネルギー量", obj.now, obj.min, obj.max);
        obj.min = EditorGUILayout.FloatField("最小値",obj.min);
        obj.max = EditorGUILayout.FloatField("最大値", obj.max);
        obj.heal = EditorGUILayout.FloatField("回復量/秒",obj.heal);

        EditorUtility.SetDirty(target);

    }

}
