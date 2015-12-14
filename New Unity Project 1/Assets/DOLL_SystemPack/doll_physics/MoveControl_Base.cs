using UnityEngine;
using System.Collections;

public class MoveControl_Base : MonoBehaviour {

    //現在速度
    public Vector3 velocity;

    //地面動摩擦
    public float move_friction;
    //空気抵抗
    public float air_friction;

    //重力加速度
    public float gravity;

	// Use this for initialization
	public virtual void Start () {
	
	}
	
	// Update is called once per frame
	public virtual void Update () {

	}

    //速度変更
    public void SetVelocity(Vector3 Velocity)
    {
        if (velocity != Velocity) velocity = Velocity;
    }

    //加速/s
    public void Acceleration(Vector3 acceleration)
    {
        velocity += acceleration * Time.deltaTime;
    }

    //未来位置
    public Vector3 GetPositionOverTime(float time)
    {
        Vector3 next = transform.position + velocity * time * Time.deltaTime;

        return next;
         
    }

}

