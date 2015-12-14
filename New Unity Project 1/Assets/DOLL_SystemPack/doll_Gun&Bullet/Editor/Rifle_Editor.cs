using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(Rifle))]
public class Rifle_Editor : Gun_Base_Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

}
