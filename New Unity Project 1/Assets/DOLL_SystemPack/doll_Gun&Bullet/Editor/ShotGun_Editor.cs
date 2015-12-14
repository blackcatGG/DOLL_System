using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(ShotGun))]
public class ShotGun_Editor : Gun_Base_Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ShotGun obj = target as ShotGun;

        obj.scattareAngle = EditorGUILayout.Slider("拡散角度", obj.scattareAngle, 0.0f, 45.0f); EditorGUILayout.LabelField("収束率　" + (45.0f - obj.scattareAngle) / 45.0f * 100.0f);
        obj.shotNum = EditorGUILayout.IntSlider("分裂数", obj.shotNum, 0, 20);

        EditorUtility.SetDirty(target);

    }
}
