using UnityEngine;
using System.Collections;

//メニューベース
public class Menu_Base : MonoBehaviour
{
    //現在選択中のメニュー番号
    public int now = 0;

    //項目の個数
    public int num;

    public float reload;

    public virtual void Start()
    {
    }

    public virtual void OnEnable()
    {
        StartCoroutine(Process());
    }

    public virtual void OnDisable()
    {
        StopAllCoroutines();
    }

    //コルーチン
    public virtual IEnumerator Process()
    {
        while (true)
        {
            //スティックへの対応
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (h < -0.1f) { yield return StartCoroutine(HorizontalAxisDown()); }
            if (h > 0.1f) { yield return StartCoroutine(HorizontalAxisUp()); }
            if (v < -0.1f) { yield return StartCoroutine(VerticalAxisDown()); }
            if (v > 0.1f) { yield return StartCoroutine(VerticalAxisUp()); }

            //1F待つ
            yield return new WaitForFixedUpdate();
        }
    }

    //上昇処理
    public int Up()
    {
        int delta = now + 1;

        //項目の最大数を超えていたら
        if (delta >= num)
        {
            delta = 0;
            return delta;
        }

        return delta;

    }

    //下降処理
    public int Down ()
    {
        int delta = now - 1;

        //項目が０未満になったら
        if (delta < 0)
        {
            return num - 1;
        }

        return delta;

    }

    public virtual IEnumerator HorizontalAxisDown()
    {
        //下降
        now = Down();
        yield return new WaitForSeconds(reload);
    }

    public virtual IEnumerator HorizontalAxisUp()
    {
        //上昇
        now = Up();
        yield return new WaitForSeconds(reload);
    }

    public virtual IEnumerator VerticalAxisDown()
    {
        //下降
        now = Down();
        yield return new WaitForSeconds(reload);
    }

    public virtual IEnumerator VerticalAxisUp()
    {
        //上昇
        now = Up();
        yield return new WaitForSeconds(reload);
    }

}