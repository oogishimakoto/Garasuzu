using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //シーンをロードする
    public void LoadScene(string str)
    {
        SceneManager.LoadScene(str);//シーンを読み込む
    }

    //ゲーム終了する
    public void GameEnd()
    {
#if UNITY_EDITOR    //UnityEditorでの実行なら
        //再生モードを解除する
        UnityEditor.EditorApplication.isPlaying = false;
#else //UnityEditorでの実行でなければ（→ビルド後）なら
        //アプリケーションを終了する
        Application.Quit();
#endif
    }
}
