using UnityEngine;
using System.Collections;

[System.Serializable]
public class NovelGraph_MeshParameter
{
    public int now = 0;
    public MeshRenderer mesh;
    public Material[] materials;
}

public class NovelGraph : MonoBehaviour {

    //描画先
    public NovelGraph_MeshParameter[] graph;

    //メッシュの表示
    public void DrawTexture(int meshNum)
    {
        //存在しないメッシュ番号ならばここで返す
        if (meshNum < 0 || meshNum >= graph.Length) { Debug.Log("Not Found Mesh : " + meshNum); return; }

        if (graph[meshNum].mesh != null)
        {
            //白にして表示する
            graph[meshNum].mesh.material.color = Color.white;

            Debug.Log("Draw Succeed");

        }

    }

    //色指定ありのメッシュ表示
    public void DrawTexture(int meshNum, Color color)
    {
        //存在しないメッシュ番号ならばここで返す
        if (meshNum < 0 || meshNum >= graph.Length) { Debug.Log("Not Found Mesh : " + meshNum); return; }

        if (graph[meshNum].mesh != null)
        {
            graph[meshNum].mesh.material.color = color;

            Debug.Log("Draw Succeed");
        }

    }

    //メッシュの非表示
    public void DeleteTexture(int meshNum)
    {
        //存在しないメッシュ番号ならばここで返す
        if (meshNum < 0 || meshNum >= graph.Length) { Debug.Log("Not Found Mesh : " + meshNum); return; }

        if (graph[meshNum].mesh != null)
        {
            //透過させ、消去する
            graph[meshNum].mesh.material.color = Color.clear;
        }

    }

    //テクスチャの切り替え
    public void ChangeTexture(int meshNum,int texNum){

        //存在しないメッシュ番号ならばここで返す
        if (meshNum < 0 || meshNum >= graph.Length) { Debug.Log("Not Found Mesh : " + meshNum); return; }

        //パラメータのテクスチャがあるかどうか
        if (graph[meshNum].mesh != null)
        {

            //存在するテクスチャならば
            if (texNum >= 0 && texNum < graph[meshNum].materials.Length)
            {
                //設定する
                graph[meshNum].mesh.material = graph[meshNum].materials[texNum];
                Debug.Log("Succeed");
            }

            else
            {
                //存在しないテクスチャ
                Debug.Log("Not Found Texture : " + texNum);

            }
        }
		
	}

    //テクスチャの移動
    public IEnumerator MoveTexture(int meshNum,Vector3 to,float time)
    {
        //存在しないメッシュ番号ならばここで返す
        if (meshNum < 0 || meshNum >= graph.Length) { Debug.Log("Not Found Mesh : " + meshNum); yield return null; }

        //存在しないメッシュならばここで返す
        if (graph[meshNum].mesh == null) { Debug.Log("Not Set Mesh : " + meshNum); yield return null; }

        //１Fでの変動
        Vector3 per = (to - graph[meshNum].mesh.transform.position) / (1.0f / time);

        float t = 0;

        while (true)
        {
            if (t >= time) break;

            if(Vector3.Distance(graph[meshNum].mesh.transform.position, to) < 0.1f)
            {
                break;
            }

            graph[meshNum].mesh.transform.position += per;

            t++;

            yield return new WaitForFixedUpdate();

        }

        graph[meshNum].mesh.transform.position = to;

    }

}
