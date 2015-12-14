using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MenuItemParameter
{
    public string name;//項目名
    public Vector3 position;//座標
    public Vector3 selectedPosition;//選択された時の座標
    public Color color;//色
    public Color selectedColor;//選ばれた時の色
}

[AddComponentMenu ("DOLL/Menu/Menu_String")]
public class Menu_String : Menu_Base
{
    public float move_per;

    public TextAnchor anchor;
    public float textScale;

    public MenuItemParameter[] items;

    public GameObject[] item_object;

    // Use this for initialization
    public override void Start()
    {
        //項目数を項目の設定数に合わせる
        num = items.Length;
        //項目生成
        GenerateItemObject();

        base.Start();

    }

    public override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(ItemProcess());

        for (int i = 0; i < item_object.Length; i++)
        {
            item_object[i].SetActive(true);
        }

    }

    public override void OnDisable()
    {
        base.OnDisable();

        for (int i = 0; i < item_object.Length; i++)
        {
            item_object[i].SetActive(false);
        }

    }

    //項目アイテム生成
    public virtual void GenerateItemObject() {

        int i = 0;

        GameObject ob;

        item_object = new GameObject[items.Length];

        //設定した項目数分オブジェクトを生成する
        foreach (MenuItemParameter item in items) {

            //検索、すでにオブジェクト生成されているなら
            if (transform.FindChild(name + "_item__" + item.name)!=null)
            {
                ob = transform.FindChild(name + "_item__" + item.name).gameObject;
                item_object[i] = ob;
            }
            else
            {
                //名前を設定しながら
                ob = new GameObject(name + "_item__" + item.name);
                //親をこのオブジェクトにする
                ob.transform.parent = transform;
                item_object[i] = ob;
            }
            
            //ローカルで座標設定
            ob.transform.localPosition = item.position;
            ob.transform.localScale = Vector3.one * textScale;

            TextMesh mesh;
            if (ob.GetComponent<TextMesh>() == null) {
                //テキストメッシュを追加
                mesh = ob.AddComponent<TextMesh>();
            }
            else
            {
                mesh = ob.GetComponent<TextMesh>();
            }

            //色の変更
            mesh.color = item.color;
            //項目名をセットする
            mesh.text = item.name;
            //アンカーを左上に
            mesh.anchor = anchor;

            i++;

       }
    }

    public virtual IEnumerator ItemProcess()
    {
        TextMesh mesh;

        while (true)
        {
            for(int i = 0; i < item_object.Length; i++)
            {
                //現在選ばれているならば
                if (i == now)
                {
                    //座標移動
                    if(item_object[i].transform.localPosition != items[i].selectedPosition)
                    {
                        //近くにくるまで割合移動
                        item_object[i].transform.localPosition = Vector3.Lerp(item_object[i].transform.localPosition, items[i].selectedPosition, move_per*Time.deltaTime);
                        if (Vector3.Distance(item_object[i].transform.localPosition, items[i].selectedPosition) < 0.001f)
                        {
                            //近くまで来たら座標をセットする
                            item_object[i].transform.localPosition = items[i].selectedPosition;
                        }
                    }

                    //色変更
                    mesh = item_object[i].GetComponent<TextMesh>();
                    if(mesh.color != items[i].selectedColor)
                    {
                        //割合変化
                        mesh.color = Color.Lerp(mesh.color, items[i].selectedColor, move_per*Time.deltaTime);
                        if (Vector4.Distance(mesh.color, items[i].selectedColor) < 0.001f)
                        {
                            //近くまで来たら色をセット
                            mesh.color = items[i].selectedColor;
                        }
                    }

                }else{
                    //座標移動
                    if (item_object[i].transform.localPosition != items[i].position)
                    {
                        //近くにくるまで割合移動
                        item_object[i].transform.localPosition = Vector3.Lerp(item_object[i].transform.localPosition, items[i].position, move_per*Time.deltaTime);
                        if (Vector3.Distance(item_object[i].transform.localPosition, items[i].position) < 0.001f)
                        {
                            //近くまで来たら座標をセットする
                            item_object[i].transform.localPosition = items[i].position;
                        }
                    }

                    //色変更
                    mesh = item_object[i].GetComponent<TextMesh>();
                    if (mesh.color != items[i].color)
                    {
                        //割合変化
                        mesh.color = Color.Lerp(mesh.color, items[i].color, move_per*Time.deltaTime);
                        if (Vector4.Distance(mesh.color, items[i].color) < 0.001f)
                        {
                            //近くまで来たら色をセット
                            mesh.color = items[i].color;
                        }
                    }
                }

            }

            //1F待つ
            yield return new WaitForFixedUpdate();
        }
    } 

}
