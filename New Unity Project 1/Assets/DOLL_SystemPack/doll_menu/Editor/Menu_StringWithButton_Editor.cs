using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(Menu_StringWithButton))]
public class Menu_StringWithButton_Editor : Menu_String_Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

}
