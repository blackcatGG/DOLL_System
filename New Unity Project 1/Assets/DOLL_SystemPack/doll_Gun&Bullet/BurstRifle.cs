using UnityEngine;
using System.Collections;

[AddComponentMenu ("DOLL/Gun&Bullet/BurstRifle")]
public class BurstRifle : Gun_Base {

    //連続で撃つ数
    public int shotNum = 1;

    //1発撃つのにかかる時間
    public float burstTime;

    public override IEnumerator Process()
    {
        //ループ
        while (true)
        {
            //ショットボタンが押された場合
            if (Input.GetButton(button.ToString()))
            {
                for (int i = 0; i < shotNum; i++)
                {
                    //射撃する
                    yield return StartCoroutine(Shot());

                    ammo--;

                    if (ammo <= 0)
                    {
                        break;
                    }

                    //バーストの時間待つ
                    yield return new WaitForSeconds(burstTime);

                }

                if (ammo <= 0)
                {
                    break;
                }

                //リロードする
                yield return new WaitForSeconds(reload);
            }

            if (ammo <= 0)
            {
                break;
            }

            yield return new WaitForFixedUpdate();

        }

        Debug.Log(gameObject.name + ":Empty");

    }

}
