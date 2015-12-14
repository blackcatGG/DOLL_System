using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(simpleMove))]
public class simpleMove_Editor : Editor {

    public override void OnInspectorGUI()
    {
        simpleMove obj = target as simpleMove;

        obj.velocity = EditorGUILayout.Vector3Field("速度/秒", obj.velocity);
        obj.Angle = EditorGUILayout.Vector3Field("回転速度", obj.Angle);

        EditorUtility.SetDirty(target);

    }

}
