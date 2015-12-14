using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (Gun_Base))]
public class Gun_Base_Editor : Editor {

    public override void OnInspectorGUI()
    {
        Gun_Base obj = target as Gun_Base;

        obj.button = (ShotButton)EditorGUILayout.EnumPopup("使用ボタン",obj.button);

        obj.bulletPrefab = (GameObject)EditorGUILayout.ObjectField("弾丸プレハブ",obj.bulletPrefab,typeof(GameObject),true);

        if(obj.emitTransform == null)
        {
            if (obj.transform.FindChild("emitPos")!=null)
            {
                obj.emitTransform = obj.transform.FindChild("emitPos");
            }
            else
            {
                obj.emitTransform = new GameObject("emitPos").transform;
            }
            obj.emitTransform.parent = obj.transform;
            obj.emitTransform.localPosition = Vector3.forward;
            obj.emitTransform.localEulerAngles = Vector3.zero;
        }

        obj.emitTransform = (Transform)EditorGUILayout.ObjectField("銃口（弾丸出現位置）",obj.emitTransform,typeof(Transform),true);

        int ammo_max = 5000;
        if(obj.ammo < 201) { ammo_max = 201; }

        obj.ammo = EditorGUILayout.IntSlider("弾数",obj.ammo, 0, ammo_max);

        obj.reload = EditorGUILayout.Slider("リロード時間(秒)",obj.reload,0.0f,90.0f);

        obj.shotBlur = EditorGUILayout.Slider("射撃ブレ",obj.shotBlur,0.0f,45.0f);EditorGUILayout.LabelField("射撃安定率　"+(45.0f-obj.shotBlur)/45.0f*100.0f);

        obj.bulletDestroyTime = EditorGUILayout.FloatField("弾丸の消滅時間（秒）", obj.bulletDestroyTime);

        EditorUtility.SetDirty(target);

    }

}
