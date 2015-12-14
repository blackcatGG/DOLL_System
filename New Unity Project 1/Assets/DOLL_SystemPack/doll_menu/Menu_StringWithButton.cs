using UnityEngine;
using System.Collections;

[AddComponentMenu ("DOLL/Menu/Menu_StringWithButton")]
public class Menu_StringWithButton : Menu_String {

    public override void Start()
    {
        base.Start();

    }

    public override void GenerateItemObject()
    {
        base.GenerateItemObject();

        for (int i=0;i<item_object.Length;i++)
        {
            //あたり判定
            item_object[i].AddComponent<AddBoxToRenderer>();
            //アイテム
            var control = item_object[i].AddComponent<Menu_StringWithButtonItem>();
            control.num = i;

        }

    }

}

//ボタン側
public class Menu_StringWithButtonItem : Menu_Button
{
    public int num;

    public override void Start()
    {
        base.Start();

    }

    public override void OnMenuButton()
    {
        Debug.Log("On");
        GetComponentInParent<Menu_StringWithButton>().now = num;
    }
}