using UnityEngine;
using System.Collections;

[AddComponentMenu("DOLL/Physics/MoveControl_Rigidbody")]
[RequireComponent(typeof(Rigidbody))]
public class MoveControl_Rigidbody : MoveControl_Base {

    private Rigidbody control;

    public override void Start()
    {
        control = GetComponent<Rigidbody>();

        base.Start();
    }

    public override void Update()
    {
        control.velocity = velocity;

        control.velocity -= velocity * air_friction * Time.deltaTime;
        velocity.y += gravity * Time.deltaTime;

        base.Update();
    }

}
