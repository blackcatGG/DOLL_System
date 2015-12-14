using UnityEngine;
using System.Collections;

[AddComponentMenu ("DOLL/Energy/EnergyControl")]
public class EnergyControl : MonoBehaviour {

    public float now;
    public float min;
    public float max;

    public float heal;

	// Use this for initialization
	public virtual void Start () {

        now = max;

        StartCoroutine(Process());

	}
	
	//プロセス
	public virtual IEnumerator Process () {

        //ループ
        while(heal > 0.0f)
        {
            Add(heal * Time.deltaTime);

            yield return new WaitForFixedUpdate();
        }

	}

    //加算処理
    public void Add (float vol)
    {
        float delta = now + vol;

        if(delta > max)
        {
            now = max;
        }
        else if(delta < 0.0f)
        {
            now = 0.0f;
        }
        else
        {
            now = delta;
        }

    }

    //使用処理
    public bool Use (float vol)
    {
        float delta = now - vol;
        
        //使えないならば
        if(delta < 0.0f)
        {
            return false;
        }

        //使えるなら
        now = delta;

        return true;

    }

    //減算処理
    public void Down (float vol)
    {
        Use(vol);
    }

}
