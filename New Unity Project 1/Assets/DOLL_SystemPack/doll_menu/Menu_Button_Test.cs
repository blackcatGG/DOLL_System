using UnityEngine;
using System.Collections;

public class Menu_Button_Test : Menu_Button {

    public bool flag;

    void Update()
    {
        if (flag) { GetComponent<MeshRenderer>().material.color = Color.black; }
        else { GetComponent<MeshRenderer>().material.color = Color.white; }
    }

    public override void LeftDown()
    {
        if (flag) { flag = false; }
        else { flag = true; }
    }

}
