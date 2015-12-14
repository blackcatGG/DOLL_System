using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (Menu_Button))]
public class Menu_Button_Editor : Editor {

    public override void OnInspectorGUI()
    {
        Menu_Button obj = target as Menu_Button;

        if(GameObject.FindObjectOfType<Menu_Camera>()== null)
        {
            GameObject ob = new GameObject("Menu_Camera", typeof(Menu_Camera));
            Camera cam = ob.GetComponent<Camera>();
            cam.orthographic = true;
        }

        EditorUtility.SetDirty(target);

    }

}
