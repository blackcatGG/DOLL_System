using UnityEngine;
using System.Collections;

public class MoveControl_ImpactAbsorber : MonoBehaviour {

    //吸収率
    public float absorb;

    //衝撃を受ける挙動制御系
    private MoveControl_Base control;

	// Use this for initialization
	void Start () {

        control = GetComponent<MoveControl_CharacterController>();
        if (control == null)
        {
            control = GetComponent<MoveControl_Rigidbody>();
        }

	}
	
    //吸収率を引いた分だけの力を与える
    public void Impact(Vector3 impact)
    {
        control.Acceleration(impact * (1.0f - absorb));
    }
	
}
