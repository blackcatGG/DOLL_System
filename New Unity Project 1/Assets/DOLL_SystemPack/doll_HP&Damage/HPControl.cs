using UnityEngine;
using System.Collections;

//このプレイヤーが誰なのか
public enum HPControlType { Player,Enemy,Else}

[AddComponentMenu ("DOLL/HP&Damage/HPControl")]
public class HPControl : EnergyControl {

    public HPControlType type;

    //HPの割合のみを渡す
    public float hpPer {
        get { return now / max; }
    }

    //オーバーライド
    public override void Start()
    {
        //今のHPを最大にまでしておく
        now = max;
    }

    //ダメージを与える
    public float Damege(float damege)
    {
        //ダメージを与える
        Add(-damege);

        //与えたダメージ量を返す
        return damege;
    }

}
