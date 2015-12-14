using UnityEngine;
using System.Collections;

[AddComponentMenu ("DOLL/Gun&Bullet/ShotGun")]
public class ShotGun : Gun_Base {

    //拡散角度
    public float scattareAngle;

    //散弾数
    public int shotNum;

    //射撃を行う
    public override IEnumerator Shot()
    {
        GameObject bullet;

        //銃をブレの分回転させる
        float sita = Random.Range(-shotBlur, shotBlur);
        float pi = Random.Range(0.0f, 360.0f);
        transform.Rotate(new Vector3(sita, 0.0f, pi));

        //散弾数の数だけ弾を出す
        for (int i = 0; i < shotNum; i++)
        {
            //弾を出す
            bullet = Instantiate(bulletPrefab, emitTransform.position, emitTransform.rotation) as GameObject;

            //弾を拡散角度の分回転させる
            sita = Random.Range(-scattareAngle, scattareAngle);
            pi = Random.Range(0.0f, 360.0f);
            bullet.transform.Rotate(new Vector3(sita, 0.0f, pi));

            var moveControl = bullet.GetComponent<MoveControl_Rigidbody>();

            //移動制御を持っている
            if (moveControl != null)
            {
                //速度を向きに合わせたものにする
                moveControl.velocity = bullet.transform.rotation * moveControl.velocity;
            }

            //一定時間後弾は消滅する
            Destroy(bullet, bulletDestroyTime);

        }

        //ブレをもとに戻す
        transform.rotation = beforeRotation;

        yield return null;
    }

}
