using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBGM : MonoBehaviour
{
    private static bool isJingleBegin = false; // ジングルを再生したか
    private static BGMSoundData.BGM nowScene = BGMSoundData.BGM.Empty; // 現在のシーン 
    private static BGMSoundData.BGM lastScene = BGMSoundData.BGM.Empty; // 前のシーン 


    float bgmTime = 0.0f;

    public static PlayBGM Instance;
    private void Awake()
    {
        // シングルトン
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        // 現在のシーン状態を保存
        if (
            SceneManager.GetActiveScene().name == "1-1" |
            SceneManager.GetActiveScene().name == "1-2" |
            SceneManager.GetActiveScene().name == "1-3" |
            SceneManager.GetActiveScene().name == "2-1" |
            SceneManager.GetActiveScene().name == "2-2" |
            SceneManager.GetActiveScene().name == "2-3"
        )
        {
            nowScene = BGMSoundData.BGM.Stage1;
        }
        else if (
            SceneManager.GetActiveScene().name == "3-1" |
            SceneManager.GetActiveScene().name == "3-2" |
            SceneManager.GetActiveScene().name == "3-3" |
            SceneManager.GetActiveScene().name == "4-1" |
            SceneManager.GetActiveScene().name == "4-2" |
            SceneManager.GetActiveScene().name == "4-3"
        )
        {
            nowScene = BGMSoundData.BGM.Stage2;
        }
        else if (
           SceneManager.GetActiveScene().name == "5-1" |
           SceneManager.GetActiveScene().name == "5-2" |
           SceneManager.GetActiveScene().name == "5-3" |
           SceneManager.GetActiveScene().name == "6-1" |
           SceneManager.GetActiveScene().name == "6-2" |
           SceneManager.GetActiveScene().name == "6-3"

       )
        {
            nowScene = BGMSoundData.BGM.Stage3;
        }
        else if (
           SceneManager.GetActiveScene().name == "7-1" |
           SceneManager.GetActiveScene().name == "7-2" |
           SceneManager.GetActiveScene().name == "7-3" |
           SceneManager.GetActiveScene().name == "7-4" |
           SceneManager.GetActiveScene().name == "7-5" |
           SceneManager.GetActiveScene().name == "7-6"
       )
        {
            nowScene = BGMSoundData.BGM.Stage4;
        }
        else if (SceneManager.GetActiveScene().name == "title")
        {
            nowScene = BGMSoundData.BGM.Title;
        }
        else if (
            SceneManager.GetActiveScene().name == "select3D")
        {
            nowScene = BGMSoundData.BGM.Select;
        }




        // 前回と異なれば
        if (nowScene != lastScene)
        {
            // 現在のシーンのBGM再生
            SoundManager.Instance.PlayBGM(nowScene);
            lastScene = nowScene;
        }

        // リザルト画面
        if (SceneManager.GetActiveScene().name == "Result")
        {
            // ジングル再生済みかつ再生が終了したら
            if (!SoundManager.Instance.GetIsPlayingSE() && isJingleBegin)
            {
                // 止めていたBGMを再生する
                SoundManager.Instance.SetTimeBGM(bgmTime);
                SoundManager.Instance.PlayBGM(lastScene);
                bgmTime = 0;
                SoundManager.Instance.SetTimeBGM(bgmTime);

                isJingleBegin = false;  // ジングル未再生状態に戻す
            }
        }
        else
        {
            // 再生終了を待たずにシーン遷移すると状態を戻せないので
            isJingleBegin = false;
        }


    }
    public void PlayJingle()
    {

        // ジングルがまだ再生されていない
        if (!isJingleBegin)
        {
            bgmTime = SoundManager.Instance.GetTimeBGM();
            SoundManager.Instance.StopBGM();// BGMを止める
            SoundManager.Instance.PlaySE(SESoundData.SE.Jingle);// ジングルを再生
            isJingleBegin = true;
        }
    }
}


