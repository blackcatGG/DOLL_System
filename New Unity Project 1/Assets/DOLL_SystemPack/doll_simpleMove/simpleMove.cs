using UnityEngine;
using System.Collections;

[AddComponentMenu ("DOLL/SimpleMove/SimpleMove")]
public class simpleMove : MonoBehaviour {

    //速度
    public Vector3 velocity;

    //回転
    public Vector3 Angle;
	
	public virtual void Start()
    {
        //コルーチンをスタートさせる
        StartCoroutine(Move());
        StartCoroutine(Rotate());
    }

    public virtual IEnumerator Move()
    {
        //ループ
        while (true) {

            //移動
            transform.position += velocity * Time.deltaTime;

            yield return new WaitForFixedUpdate();

            //速度が０なら終了する
            if (velocity.magnitude == 0.0f)
            {
                break;
            }

        }

    }

    public virtual IEnumerator Rotate()
    {
        //ループ
        while (true)
        {
            //回転する
            transform.Rotate(Angle * Time.deltaTime);

            yield return new WaitForFixedUpdate();

            //角速度が０なら終了する
            if(Angle.magnitude == 0.0f)
            {
                break;
            }

        }
    }

}
