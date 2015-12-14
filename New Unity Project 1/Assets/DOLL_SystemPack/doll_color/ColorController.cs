using UnityEngine;
using System.Collections;

public class ColorController: MonoBehaviour {

    //メッシュの色を変化させる
    public static void ChangeColor(MeshRenderer mesh,Color color)
    {
        //メッシュの色を変化させる
        mesh.material.color = color;
    }

    public static IEnumerator ChangeColorByTime(MeshRenderer mesh,Color color,float time,float per)
    {
        float t = 0.0f;

        //時間が来ると終わり
        while (t<=time)
        {
            //メッシュの色を徐々に変更する
            mesh.material.color = Color.Lerp(mesh.material.color, color, per*Time.deltaTime);

            t += Time.deltaTime;
            yield return new WaitForFixedUpdate();

        }
    }

    //マテリアルナンバーを設定し、そのマテリアルの色を変更する
    public static void ChangeColor(MeshRenderer mesh, int materialNum,Color color)
    {
        if(materialNum >= 0&&materialNum < mesh.materials.Length)
        {
            mesh.materials[materialNum].color = color;
        }
    }

    public static IEnumerator ChangeColorBySinCurve(MeshRenderer mesh,Color a,Color b,float Per)
    {
        //現在の角度
        float p = 0.0f;
        //加算角度を計算
        float add = Mathf.PI * 2.0f * Per;

        while (true)
        {
            //角度を加算
            p += add * Time.deltaTime;

            //Sin値を得る(-1 ~ 1　→　0 ~ 2にして２で割る 0 ~ 1)
            float vol = (Mathf.Sin(p) + 1.0f )/ 2.0f;

            mesh.material.color = Color.Lerp(a, b, vol);

            yield return new WaitForFixedUpdate();

        }

    }

}
