using UnityEngine;
using System.Collections;

[AddComponentMenu ("DOLL/Menu/Button")]
public class Menu_Button : MonoBehaviour {

    public virtual void Start()
    {
        CreateMenuCam();
    }

    static public void CreateMenuCam()
    {
        //メニュー用カメラがなかったら
        if (GameObject.FindObjectOfType<Menu_Camera>() == null)
        {
            GameObject ob = new GameObject("Menu_Camera", typeof(Menu_Camera));
            Camera cam = ob.GetComponent<Camera>();
            cam.orthographic = true;
        }
    }

    //マウスが乗っている
    public virtual void OnMenuButton()
    {

    }

    //クリックした瞬間
    public virtual void ClickMenuButtonDown(int type)
    {
        switch (type)
        {
            case 0: LeftDown(); break;
            case 1: RightDown(); break;
            case 2: CenterDown(); break;
            default: break;
        }
    }

    //クリックし続けている
    public virtual void ClickMenuButton(int type)
    {
        switch (type)
        {
            case 0: LeftHold(); break;
            case 1: RightHold(); break;
            case 2: CenterHold(); break;
            default: break;
        }
    }

    //上げた瞬間
    public virtual void ClickMenuButtonUp(int type)
    {
        switch (type)
        {
            case 0: LeftUp(); break;
            case 1: RightUp(); break;
            case 2: CenterUp(); break;
            default: break;
        }
    }

    public virtual void LeftDown(){}

    public virtual void LeftHold() {}

    public virtual void LeftUp() {}

    public virtual void RightDown() { }

    public virtual void RightHold() { }

    public virtual void RightUp() { }

    public virtual void CenterDown() { }

    public virtual void CenterHold() { }

    public virtual void CenterUp() { }

}
