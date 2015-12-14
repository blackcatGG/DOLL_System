using UnityEngine;
using System.Collections;

//読み込みを行うテキストアセットは
//UTF-8コードで保存されたものに限る

[AddComponentMenu ("DOLL/Novel/NovelReader")]
[RequireComponent (typeof(TextMesh))]
[RequireComponent (typeof(NovelGraph))]
public class NovelReader : MonoBehaviour {

    //表示するテキスト
    public TextAsset textAsset;
    //string
    public string text;
    //１文字読むのにかかる時間
    public float OneStringTime = 0.1f;
    //クリックに対応するパッドのボタン,キー
    public string clickButton = "Fire1";
    public string clickKey = "z";

    //各種フラグ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

    //読んでいるかどうか
    [HideInInspector]public bool read_flag = true;
    //現在の読み込み位置
    [HideInInspector]public int cnt = 0;
    //表示文を消すフラグ
    [HideInInspector]public bool clear_flag = false;
    //スキップするフラグ
    [HideInInspector]public bool skip_flag = false;

    //コンポーネント===========================

    //キャラグラフィック描写
    [HideInInspector]public NovelGraph novelGraph;
    //メイン表示先
    [HideInInspector]public TextMesh mainMesh;

    // Use this for initialization
    public virtual void Start () {

        //テキストメッシュを取得
        mainMesh = GetComponent<TextMesh>();

        //テキストアセットが設定されている時のみ実行する+
        if (textAsset != null)
        {
            text = textAsset.text;
            StartCoroutine(Process());
        }

	}
	
    //メインプロセス
    public virtual IEnumerator Process()
    {
        //読み上げを開始する
        StartCoroutine(Read());

        //ループ
        while (true)
        {
            //スキップ処理
            if (Input.GetButtonDown(clickButton) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(clickKey))
            {

            }

            //読むのを停止している時
            while (!read_flag) {

                //クリック待ち
                if (Input.GetButtonDown(clickButton) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(clickKey))
                {
                    //消去フラグが立っていたら表示中のテキストを消去する
                    if (clear_flag)
                    {
                        mainMesh.text = "";//無にする
                        clear_flag = false;//消去フラグを下す
                    }
                    //読み上げのフラグを再開
                    read_flag = true;

                    //読み上げ再開
                    StartCoroutine(Read());
                }

                yield return new WaitForFixedUpdate();
            }

            yield return new WaitForFixedUpdate();

        }

    }

    //読みあげ
    public virtual IEnumerator Read()
    {
        //ループ
        while (true)
        {
            //コマンドを追加する際はここに追加していく
            if (Command("@")) { StopAndClear();}
            else if (Command("w")) { yield return StartCoroutine(WaitTime()); }
            else if (Command("*")) { StopAndNotClear(); }
            else if (Command("cl")) { Clear(); }
            else if (Command("<speed>=")) { ChangeTime(); }
            else if (Command("<send>=")) { Send(); }
            else if (Command("<goto>=")) { LoadScene(); }
            else if (Command("//")) { Comment(); }
            else if (Command("<graph_draw>=")) { GraphDraw(); }//グラフィック表示
            else
            {
                //コマンドではない読み上げる文ならば

                //1文字追加
                mainMesh.text += text.Substring(cnt, 1);

                //読み上げ位置を１文字分ずらす
                if (cnt + 1 < text.Length) cnt++;
                else break;//終端ならばここで終了する

                if (skip_flag)
                {
                    yield return new WaitForSeconds(0.001f);
                }
                else
                {
                    //待つ
                    yield return new WaitForSeconds(OneStringTime);
                }

            }

        }

        Debug.Log("End Of File"+gameObject.name + "s => " + textAsset.name);

    }

    //
    //コマンドのチェック
    public bool Command(string command)
    {
        //テキストの終端付近ならば実行しない
        if(cnt + command.Length >= text.Length)
        {
            return false;
        }

        //現在読み込んでいる位置からコマンドの長さ分の読み込みをする
        string s = text.Substring(cnt, command.Length);

        //コマンド通りだったら
        if (s == command) {
            return true;
        }

        //コマンド通りでなかったら
        return false;
    }

    //
    //特定文字の読み飛ばし
    public void Replace(string s)
    {
        //指定文字があったら
        if (Command(s))
        {
            //その分読み込み位置を移動させる
            cnt += s.Length;
        }
    }

    public void Replace(char s)
    {
        //指定文字があったら
        if (Command(s.ToString()))
        {
            //その分読み込み位置を移動させる
            cnt += s.ToString().Length;
        }
    }

    //
    //デフォルト0：停止し、クリック後に消去し読み始める
    public void StopAndClear()
    {
        clear_flag = true;//クリック後文字列を消去する
        read_flag = false;//停止フラグ

        //読み込み停止
        StopCoroutine("Read");
        //@分の１進める
        cnt += 1;
        //直後に改行文字があれば除去する
        Replace("\n");Replace("\r");

    }

    //
    //デフォルト1:消去
    public void Clear()
    {
        //文字列を無しにする
        mainMesh.text = "";
        //cl分の２文字進める
        cnt += 2;
        //改行文字があれば消去する
        Replace("\n");Replace("\r");
        StopCoroutine("Read");
        StartCoroutine(Read());

    }
	
    //
    //デフォルト2:停止し、クリック後消去せずに読み始める
    public void StopAndNotClear()
    {
        read_flag = false;//停止フラグ
        //読み込み停止
        StopCoroutine("Read");
        //@分の１進める
        cnt += 1;
        //直後に改行文字があれば除去する
        Replace("\n"); Replace("\r");

    }

    //
    //デフォルト3:ウエイト
    public IEnumerator WaitTime()
    {
        //読み込みを停止
        //StopCoroutine("Read");

        int i = 0;

        //時間指定後の;が来るまでの文字数を調べる
        while (text.Substring(cnt + 1 + i, 1) != ";")
        {
            Debug.Log(i);
            i++;
            yield return new WaitForFixedUpdate();
        }

        //停止時間を取得
        float t = float.Parse(text.Substring(cnt+1,i));

        Debug.Log(t);

        float c;

        for(c=0.0f;c< t; c++)
        {
            if (!skip_flag)
            {
                yield return new WaitForFixedUpdate();
            }
            else
            {
                break;
            }
        }

        //ウエイトの分だけ読み飛ばす
        cnt += 1 + i + 1;

        //改行文字は消去
        Replace('\n');Replace('\r');

        //再開
        //StartCoroutine(Read());

    }

    //
    //デフォルト4:文字の読み込み間隔を変更する
    public void ChangeTime()
    {
        StopCoroutine("Read");

        int i = 0;//探索用

        // <speed>= 8文字

        while (text.Substring(cnt + 8 + i, 1) != ";")
        {
            i++;
        }

        OneStringTime = 1.0f / float.Parse(text.Substring(cnt + 8, i));

        cnt += 8 + i + 1;

        //速度変更の直後に改行があるなら除去する
        Replace("\n");
        Replace("\r");

        StartCoroutine(Read());
    }

    //
    //デフォルト5:SendMessageを行う
    public void Send()
    {
        StopCoroutine("Read");

        int i = 0;//探索用
        bool hikisuu = true;//デフォルトは「ある」に設定

        float h_num;//引数
        string message = "";

        //区切り文字があるまで見る
        while (text.Substring(cnt + 7 + i, 1) != ",")
        {
            //終端文字なら
            if (text.Substring(cnt + 7 + i, 1) == ";")
            {
                //引数は「ない」と判断
                hikisuu = false;
            }
            i++;
        }

        Debug.Log(message);

        //メッセージを抜き取り
        message = text.Substring(cnt + 7, i);

        cnt += 7 + i + 1;// , ないし　; までカウントを進める

        i = 0;//iをリセット

        //引数があるなら
        if (hikisuu)
        {

            //終端文字があるまで見る
            while (text.Substring(cnt + i, 1) != ";")
            {
                i++;
            }

            //引数を設定
            h_num = float.Parse(text.Substring(cnt, i));

            //引数つきのメッセージを送る
            BroadcastMessage(message, h_num);

            Debug.Log("Sended : " + message + " : " + h_num);

            cnt += i + 1;

        }
        else
        {
            //ないなら
            //ふつうのメッセージを送る
            BroadcastMessage(message);
            Debug.Log("Sended : " + message);
        }

        StartCoroutine(Read());

    }

    //
    //デフォルト6:シーンの読み込みを行う
    public void LoadScene()
    {

        // <goto>= 7文字

        int i = 0;//探索用

        string scene ="";

        //終端文字があるまで見る
        while (text.Substring(cnt + 7 + i, 1) != ";")
        {
            i++;
        }

        scene = text.Substring(cnt + 7, i);

        cnt += 7 + i + 1;

        Application.LoadLevel(scene);

        StartCoroutine("Count");

    }

    //
    //デフォルト7:コメント行
    public void Comment()
    {

        int i =0;//探索用

        //終端文字があるまで見る
        while (text.Substring(cnt + 2 + i, 1) != "\n" && text.Substring(cnt + 2 + i, 1) != "\r")
        {
            i++;
        }

        cnt += 2 + i + 1;

        StartCoroutine("Count");

    }

    //=============================================================================


    //
    //グラフィック1:立ち絵等の描画を行う
    public void GraphDraw()
    {
        StopCoroutine("Read");

        //適応されていない場合
        if (novelGraph == null) return;

        int i = 0;//探索用

        // <graph_draw>= 13文字

        int meshNum = 0;//テキストナンバー

        // ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

        cnt += 13;

        //区切り文字があるまで見る
        while (text.Substring(cnt + i, 1) != ";")
        {
            i++;
        }

        meshNum = int.Parse(text.Substring(cnt, i));

        novelGraph.DrawTexture(meshNum);

        cnt += i + 1;//;までスキップ

        //変更の直後に改行があるなら除去する
        Replace("\n");Replace("\r");

        StartCoroutine(Read());

    }

}
