using UnityEngine;
using System.Collections;

[AddComponentMenu ("DOLL/Attention/Attention")]
[RequireComponent (typeof(TextMesh))]
public class Attention : MonoBehaviour {

    //一文字表示するのに必要な時間
    public float OneStringTime = 0.2f;

    //表示するメッシュ
    private TextMesh mesh;

    //後方の黒帯、白帯
    public MeshRenderer back;
    public float per;
    public Color backColor;

    void Start()
    {
        mesh = GetComponent<TextMesh>();
    }

    public IEnumerator Draw(string text,float time)
    {
        int i = 0;

        //注釈を出す
        mesh.text = "";

        //もし帯がセットできているならば帯も一緒に表示する
        if (back != null)
        {
            StartCoroutine(DrawBack(time + OneStringTime * text.Length));
        }

        //表示するのにかかる時間
        while (i <= text.Length)
        {
            mesh.text += text[i];

            yield return new WaitForSeconds(OneStringTime);

            i++;
        }

        //描写
        yield return new WaitForSeconds(time);

        //注釈を消す
        mesh.text = "";

    }

    public IEnumerator DrawBack(float time)
    {

        back.material.color = backColor;

        yield return new WaitForSeconds(time);

        back.material.color = Color.clear;

    }

    //色指定で帯を用意する
    public GameObject SetBack(Color color)
    {
        //帯がセットされていないならば
        if (back == null)
        {
            //ここで生成する
            back = GameObject.CreatePrimitive(PrimitiveType.Quad).GetComponent<MeshRenderer>();
            back.transform.parent = transform;
        }

        //色を指定する
        back.material.color = new Color(color.r,color.g,color.b,0.0f);
        backColor = color;

        return back.gameObject;

    }

    //サイズ指定
    public GameObject SetBack(Color color,Vector3 Size)
    {
        //色指定の帯配置
        SetBack(color);

        //サイズを変更
        back.transform.localScale = Size;

        return back.gameObject;
    }

    //帯を削除する
    public void DestroyBack()
    {
        Destroy(back.gameObject);
    }

}
