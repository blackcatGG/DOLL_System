using UnityEngine;
using System.Collections;

[AddComponentMenu ("DOLL/SimpleMove/SimpleMoveRigidBody")]
[RequireComponent (typeof(Rigidbody))]
public class simpleMoveRigidBody : simpleMove {

    Rigidbody control;

	// Use this for initialization
	public override void Start () {

        control = GetComponent<Rigidbody>();

        control.useGravity = false;

        base.Start();

	}


    public override IEnumerator Move()
    {
        //ループ
        while (true)
        {

            //移動
            control.velocity = velocity;

            yield return new WaitForFixedUpdate();

            //速度が０なら終了する
            if (velocity.magnitude == 0.0f)
            {
                break;
            }

        }

    }

}
