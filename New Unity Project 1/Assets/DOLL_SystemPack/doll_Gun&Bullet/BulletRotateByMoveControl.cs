using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MoveControl_Rigidbody))]
public class BulletRotateByMoveControl : MonoBehaviour {

    //移動制御
    MoveControl_Rigidbody control;

	// Use this for initialization
	void Start () {

        //制御を得てくる
        control = GetComponent<MoveControl_Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

        //移動先に向ける
        transform.LookAt(transform.position+control.velocity);

	}
}
