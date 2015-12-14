using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(MoveControl_Rigidbody))]
public class MoveControl_Rigidbody_Editor : Editor {

    public override void OnInspectorGUI()
    {
        var obj = target as MoveControl_Rigidbody;

        obj.velocity = EditorGUILayout.Vector3Field("速度/s", obj.velocity);
        //obj.move_friction = EditorGUILayout.FloatField("動摩擦/s", obj.move_friction);
        obj.air_friction = EditorGUILayout.FloatField("空気抵抗/s", obj.air_friction);
        obj.gravity = EditorGUILayout.FloatField("重力加速度/s", obj.gravity);

        EditorUtility.SetDirty(target);

    }

}
