using UnityEngine;
using System.Collections;

public enum MenuClickType
{
    Left = 0,Right = 1,Center = 2,
}

[AddComponentMenu ("DOLL/Menu/MenuCamera")]
[RequireComponent(typeof(Camera))]
public class Menu_Camera : MonoBehaviour {

    [HideInInspector] public Camera cam;

    public float RayLength = 10.0f;

    public GameObject target;

	// Use this for initialization
	void Start () {

        //カメラ取得
        cam = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {

        //マウスのカーソルに触れているオブジェクトを取得する
        Ray ray;
        RaycastHit hit;
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, RayLength))
        {
            target = hit.collider.gameObject;
        }
        else
        {
            target = null;
        }

        //ターゲットがある場合
        if (target != null)
        {
            //マウスが乗っていることを伝える
            target.SendMessage("OnMenuButton");
            //クリック処理
            ClickProcess();
        }

    }

    public void ClickProcess()
    {
        for(int i = 0; i < 3; i++)
        {
            //クリックした瞬間
            if (Input.GetMouseButtonDown(i))
            {
                target.SendMessage("ClickMenuButtonDown",i);
            }

            //クリックし続けている
            if (Input.GetMouseButton(i))
            {
                target.SendMessage("ClickMenuButton", i);
            }

            //上げた時
            if (Input.GetMouseButtonUp(i))
            {
                target.SendMessage("ClickMenuButtonUp", i);
            }
        }
    }
    
}