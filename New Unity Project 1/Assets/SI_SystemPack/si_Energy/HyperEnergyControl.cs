using UnityEngine;
using System.Collections;

[RequireComponent (typeof (HPControl))]
public class HyperEnergyControl : EnergyControl {

    //上昇値
    public float attackUp;
    public float damegeUp;

    //ピンチになるときの割合
    public float pinchPer = 30.0f;

    //ピンチ時に自動で上昇する値
    public float pinchUp = 1.0f;

    //ピンチ時に補正がかかる割合
    public float pinchUpAttackPer = 1.5f;
    public float pinchUpDamegePer = 1.5f;

    //体力制御
    private HPControl hpControl;
    private float attackPer = 1.0f;
    private float damegePer = 1.0f;

	// Use this for initialization
	public override void Start () {

        hpControl = GetComponent<HPControl>();

        //プロセスループを実行させる
        StartCoroutine(Process());

	}
	
	// Update is called once per frame
	void Update () {
	
        //ピンチ時の体力より低い場合
        if(hpControl.hpPer <= pinchPer / 100.0f)
        {
            attackPer = pinchUpAttackPer;
            damegePer = pinchUpDamegePer;
            //自然上昇
            Add(pinchUp * Time.deltaTime);

        }
        else
        {
            attackPer = 1.0f;
            damegePer = 1.0f;
        }

	}

    public override IEnumerator Process()
    {
        yield return null;
    }

    //攻撃時の上昇（技の方から直接値を得る）
    public virtual void Attack(float vol)
    {
        Add(vol * attackPer);
    }

    //攻撃時上昇
    public virtual void Attack()
    {
        Add(attackUp * attackPer);
    }

    //ダメージを受けた時の上昇
    public virtual void Damege()
    {
        Add(damegeUp * damegePer);
    }

}
