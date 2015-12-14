using UnityEngine;
using System.Collections;

[AddComponentMenu ("DOLL/HP&Damage/DamegeControl")]
public class DamageControl : MonoBehaviour {

    //誰が撃ったのか
    public HPControlType type;

    //ダメージ量
    public float damege;

	// Use this for initialization
	public virtual void Start () {

	}
	
	// Update is called once per frame
	public virtual void Update () {
	
	}

    //あたった時の処理
    public virtual void OnTriggerEnter(Collider collider) {

        //HPControlを取得
        HPControl control = collider.GetComponent<HPControl>();

        //そもそも体力を持っていないオブジェクトに対しては処理をしない
        if (control == null) return;

        //あたったのが自分ではないのであれば
        if(control.type != type)
        {
            //ダメージを与える
            control.Damege(damege);
        }

    }

}
