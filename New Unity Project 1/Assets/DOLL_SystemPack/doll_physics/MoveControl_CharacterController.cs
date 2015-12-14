using UnityEngine;
using System.Collections;
//キャラクターコントローラ


[AddComponentMenu("DOLL/Physics/MoveControl_CharacterController")]
[RequireComponent(typeof(CharacterController))]
public class MoveControl_CharacterController : MoveControl_Base
{
    //キャラクターコントローラ
    private CharacterController characterController;

    public override void Start()
    {
        //GetComponent
        characterController = GetComponent<CharacterController>();

        base.Start();
    }

    public override void Update()
    {
        //移動する
        characterController.Move(velocity * Time.deltaTime);

        //地面についている
        if (characterController.isGrounded)
        {
            //減速させる
            velocity -= velocity * move_friction * Time.deltaTime;

            //地面に着いたら垂直速度を０にする
            if (characterController.velocity.y < 0.0f)
            {
                velocity.y = 0.0f;
            }
        }
        else
        {
            //空気抵抗を受ける
            velocity -= velocity * air_friction * Time.deltaTime;
            velocity.y += gravity * Time.deltaTime;

        }


        base.Update();
    }

}