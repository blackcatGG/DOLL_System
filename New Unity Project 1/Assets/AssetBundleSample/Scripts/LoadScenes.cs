using UnityEngine;
using System.Collections;
using AssetBundles;


public class LoadScenes : MonoBehaviour
{
    //アセットバンドル名
	public string sceneAssetBundle;
    //アセットバンドルに含まれるシーン名
	public string sceneName;
	
	// Use this for initialization
	IEnumerator Start ()
	{	
		yield return StartCoroutine(Initialize() );
		
		// Load level.
		yield return StartCoroutine(InitializeLevelAsync (sceneName, true) );
	}

	// Initialize the downloading url and AssetBundleManifest object.
	protected IEnumerator Initialize()
	{
		//シーンロードによってこのゲームオブジェクトが消されないようにする
		DontDestroyOnLoad(gameObject);
		
		// With this code, when in-editor or using a development builds: Always use the AssetBundle Server
		// (This is very dependent on the production workflow of the project. 
		// 	Another approach would be to make this configurable in the standalone player.)

        //エディタ上で使う場合
		#if DEVELOPMENT_BUILD || UNITY_EDITOR
        //アセットバンドルサーバーを設置する
		AssetBundleManager.SetDevelopmentAssetBundleServer ();
		#else
		// Use the following code if AssetBundles are embedded in the project for example via StreamingAssets folder etc:
        //ローカルのデータパス上にあるアセットバンドルのＵＲＬに設定する。
		AssetBundleManager.SetSourceAssetBundleURL(Application.dataPath + "/");
		// Or customize the URL based on your deployment or configuration
		//AssetBundleManager.SetSourceAssetBundleURL("http://www.MyWebsite/MyAssetBundles");
		#endif
		
		// Initialize AssetBundleManifest which loads the AssetBundleManifest object.
        //アセットバンドルマネージャの初期化
		var request = AssetBundleManager.Initialize();
		
        //値がちゃんと帰ってきた場合
		if (request != null)
			yield return StartCoroutine(request);
	}

	protected IEnumerator InitializeLevelAsync (string levelName, bool isAdditive)
	{
		// This is simply to get the elapsed time for this phase of AssetLoading.
        
        //初期化の開始時間
		float startTime = Time.realtimeSinceStartup;

        // Load level from assetBundle.
        //非同期で読み込む
        AssetBundleLoadOperation request = AssetBundleManager.LoadLevelAsync(sceneAssetBundle, levelName, isAdditive);
		if (request == null)
			yield break;
		yield return StartCoroutine(request);

		// Calculate and display the elapsed time.
		float elapsedTime = Time.realtimeSinceStartup - startTime;
		Debug.Log("Finished loading scene " + levelName + " in " + elapsedTime + " seconds" );
	}
}
