using UnityEngine;
using System.Collections;

public class AI_Control { }

[AddComponentMenu ("SI/Move/SI_CharacterMoveControl")]
[RequireComponent (typeof(MoveControl_CharacterController))]//移動制御
[RequireComponent (typeof(BoosterEnergyControl))]//ブーストのエネルギー
public class SI_CharacterMoveControl : MonoBehaviour {

    //現在の速度
    private float nowSpeed;
    //取得用
    public float NowSpeed
    {
        get { return nowSpeed; }
    }

    //現在の進行方向変化率
    private float now_direction_per;
    //取得用
    public float NowDirectionPer
    {
        get { return now_direction_per; }
    }

    //慣性系移動であるか
    public bool inertia = false;

    //現在のスティックの向き
    public Vector3 vect;
    //現在キャラクターが進もうとしている向き
    public Vector3 nowDirection;

    //パラメータ
    public CharacterSpeedParameter parameter;

    //移動制御
    private MoveControl_CharacterController control;
    //ブースト
    private BoosterEnergyControl boost;
    //CPU
    private AI_Control cpu;

	// Use this for initialization
	void Start () {

        //コントロールを得る
        control = GetComponent<MoveControl_CharacterController>();
        //ブーストを得る
        boost = GetComponent<BoosterEnergyControl>();

	}

    public virtual void OnEnable()
    {
        //プロセスを実行
        StartCoroutine(Process());

    }

    public virtual void OnDisable()
    {
        //プロセスを停止
        StopCoroutine("Process");
    }

    public IEnumerator Process()
    {

        float h = 0.0f; float v = 0.0f;

        //速度を通常で初期化
        nowSpeed = parameter.normal;
        now_direction_per = parameter.normal_direction_per;

        //1F待つ
        yield return new WaitForFixedUpdate();

        if (GetComponentInChildren<AI_Control>() != null)
        {
            cpu = GetComponentInChildren<AI_Control>();
        }

        /*

        //無限ループ
        while (true)
        {

            if (cpu == null)
            {
                //方向が指定されている状態で、ブーストボタンを押した瞬間
                if (vect.magnitude > 0.0f && characterState.boostStatus == BoostStatus.NORMAL)
                {
                    if (Input.GetButtonDown("Boost" + player.name) || Input.GetKeyDown(keyConfig.key_Boost))
                    {
                        //ブーストを実行する。
                        StartCoroutine(BoostObjective());
                        characterState.movingStatusControl.time = 0.0f;
                        Debug.Log("Boost");
                    }
                }


                //スティックの傾きを初期化
                vect = Vector3.zero;
                h = 0.0f; v = 0.0f;

                //パッド
                vect = new Vector3(Input.GetAxis("Horizontal" + player.name), 0.0f, Input.GetAxis("Vertical" + player.name));

                //キーボード
                h += Input.GetKey(keyConfig.key_Right) ? 1.0f : 0.0f; h += Input.GetKey(keyConfig.key_Left) ? -1.0f : 0.0f;
                v += Input.GetKey(keyConfig.key_Up) ? 1.0f : 0.0f; v += Input.GetKey(keyConfig.key_Down) ? -1.0f : 0.0f;
                if (h != 0.0f || v != 0.0f) { vect = new Vector3(h, 0.0f, v); }
            }
            else
            {
                //AIがついている場合
                Debug.Log("AI_Activate : " + this.name);

                //方向が指定されている状態で、ブーストボタンを押した瞬間
                if (vect.magnitude > 0.0f && characterState.boostStatus == BoostStatus.NORMAL)
                {
                    if (cpu.GetButtonDown(AI_InputType.BOOST))
                    {
                        //ブーストを実行する。
                        StartCoroutine(BoostObjective());
                        characterState.movingStatusControl.time = 0.0f;
                        Debug.Log("Boost");
                    }
                }

                //スティックの傾きを初期化
                vect = Vector3.zero;

                //AIから入力を持ってくる
                vect = new Vector3(cpu.GetAxis(AI_AxisType.HORIZONTAL), 0.0f, cpu.GetAxis(AI_AxisType.VERTICAL));

            }

            //正規化		
            vect = vect.normalized;

            //方向切り替え
            nowDirection = Vector3.Lerp(nowDirection, vect, now_direction_per * Time.fixedDeltaTime);

            if (characterState.movingStatus == PlayerMovingStatus.NORMAL)
            {
                //実際に動かす部分
                if (!inertia) { move.SetVelocityXZ(nowDirection * nowspeed); }
                else { move.Acceleration(nowDirection * nowspeed); }
            }

            //1F待つ
            yield return new WaitForFixedUpdate();

        }

        */

    }

}
