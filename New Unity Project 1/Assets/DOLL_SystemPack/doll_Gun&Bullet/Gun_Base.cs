using UnityEngine;
using System.Collections;

public enum ShotButton
{
    Fire1,Fire2,Fire3
}

public class Gun_Base : MonoBehaviour {

    public ShotButton button;
    //弾丸プレハブ
    public GameObject bulletPrefab;

    //弾を出す場所
    public Transform emitTransform;

    //弾薬
    public int ammo;

    //リロード
    public float reload;

    //射撃ブレ
    public float shotBlur;
    
    //弾の消滅時間
    public float bulletDestroyTime;

    //常時消費EN
    public float energyDrain;

    //ぶれる前の向き
    [HideInInspector]public Quaternion beforeRotation;

    // Use this for initialization
    public virtual void Start () {

        //向きを覚えさせておく
        beforeRotation = transform.rotation;

        //StartCoroutine(Process());

    }

    //この銃が起動した時
    public virtual void OnEnable()
    {
        //プロセスを実行
        StartCoroutine(Process());
    }

    //無効になった時
    public virtual void OnDisable()
    {
        //プロセスを停止
        StopAllCoroutines();
    }

    public virtual IEnumerator Process()
    {
        //ループ
        while (true)
        {
            //ショットボタンが押された場合
            if (Input.GetButton(button.ToString()))
            {

                //射撃する
                yield return StartCoroutine(Shot());

                ammo--;

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

        Debug.Log(gameObject.name+":Empty");

    }

    //射撃を行う
    public virtual IEnumerator Shot() {

        //銃をブレの分回転させる
        float sita = Random.Range(-shotBlur, shotBlur);
        float cos = Random.Range(-shotBlur,shotBlur);
        transform.Rotate(new Vector3(sita, cos,0.0f));

        //弾丸を出す
        GameObject bullet = Instantiate(bulletPrefab,emitTransform.position,emitTransform.rotation) as GameObject;

        var moveControl = bullet.GetComponent<MoveControl_Rigidbody>();

        //移動制御を持っている
        if (moveControl!= null)
        {
            //速度を向きに合わせたものにする
            moveControl.velocity = bullet.transform.rotation * moveControl.velocity;
        }

        //一定時間後弾は消滅する
        Destroy(bullet, bulletDestroyTime);

        //ブレをもとに戻す
        transform.rotation = beforeRotation;

        yield return new WaitForFixedUpdate();

    }
	
}
