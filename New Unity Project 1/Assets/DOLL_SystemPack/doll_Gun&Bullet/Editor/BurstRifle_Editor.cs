using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(BurstRifle))]
public class BurstRifle_Editor : Gun_Base_Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        BurstRifle obj = target as BurstRifle;

        obj.shotNum = EditorGUILayout.IntSlider("バースト点数",obj.shotNum,1,10);
        obj.burstTime = EditorGUILayout.Slider("一発あたりにかかる時間（秒）",obj.burstTime,0.0f,5.0f);

        EditorUtility.SetDirty(target);

    }

}
