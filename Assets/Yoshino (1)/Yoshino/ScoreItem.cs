using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]   // インスタンスを保存するために必要

public class ScoreItem : MonoBehaviour
{
    //UIText指定用
    public Text Textscore;
    //表示用変数
    public int score;
    private int DisplayScore = 0;
    private int TargetScore = 0;
    private int DifferenceScore = 0;
    private float ElapsedTime = 0;

    private SaveSystem System => SaveSystem.Instance;  //メソッド省略
    private UserData Data => System.UserData;          //メソッド省略


    // Start is called before the first frame update
    void Start()
    {
        //スコアの初期化
        score = 0;
        Data.ScoreOver = false;

    }

    // ------------------------------------
    // ここから

    private void FixedUpdate()
    {

        // 目標スコアをセット
        if (TargetScore != score)
        {
            TargetScore = score;
            // 差分を再計算
            DifferenceScore = TargetScore - DisplayScore;
            //時間をリセット
            ElapsedTime = 0;
        }

        if (DisplayScore < score)
        {
            DisplayScore += (int)(DifferenceScore * ElapsedTime);
            ElapsedTime += Time.fixedDeltaTime;

            //スコアを整える
            if (score <= DisplayScore)
            {
                DisplayScore = score;
            }
        }

        Textscore.text = string.Format("{0}", DisplayScore);
    }

    // ------------------------------------
    // ここまでと4-1の上にあるTextscoreを消します

    // Update is called once per frame
    void Update()
    {
        //-------------------------------------------------------------
        //1

        //Textscore.text = string.Format("{0}", score);


        if (SceneManager.GetActiveScene().name == "1-1")
        {
            if (Data.StageScore[0, 0] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[0, 0] = score;
                Data.ScoreOver = true;
                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "1-2")
        {
            if (Data.StageScore[0, 1] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[0, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "1-3")
        {
            if (Data.StageScore[0, 2] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[0, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        //----------------------------------------------------------
        //2
        if (SceneManager.GetActiveScene().name == "2-1")
        {
            if (Data.StageScore[1, 0] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[1, 0] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "2-2")
        {
            if (Data.StageScore[1, 1] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[1, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "2-3")
        {
            if (Data.StageScore[1, 2] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[1, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        //------------------------------------------------------------
        //3
        if (SceneManager.GetActiveScene().name == "3-1")
        {
            if (Data.StageScore[2, 0] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[2, 0] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "3-2")
        {
            if (Data.StageScore[2, 1] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[2, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "3-3")
        {
            if (Data.StageScore[2, 2] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[2, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        //-------------------------------------------------------------
        //4
        if (SceneManager.GetActiveScene().name == "4-1")
        {
            if (Data.StageScore[3, 0] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[3, 0] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "4-2")
        {
            if (Data.StageScore[3, 1] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[3, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "4-3")
        {
            if (Data.StageScore[3, 2] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[3, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        //----------------------------------------------------------
        //5
        if (SceneManager.GetActiveScene().name == "5-1")
        {
            if (Data.StageScore[4, 0] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[4, 0] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "5-2")
        {
            if (Data.StageScore[4, 1] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[4, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "5-3")
        {
            if (Data.StageScore[4, 2] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[4, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        //------------------------------------------------------------
        //6
        if (SceneManager.GetActiveScene().name == "6-1")
        {
            if (Data.StageScore[5, 0] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[5, 0] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "6-2")
        {
            if (Data.StageScore[5, 1] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[5, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "6-3")
        {
            if (Data.StageScore[5, 2] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[5, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        //------------------------------------------------------------
        //7
        if (SceneManager.GetActiveScene().name == "7-1")
        {
            if (Data.StageScore[6, 0] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[6, 0] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "7-2")
        {
            if (Data.StageScore[6, 1] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[6, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }

        if (SceneManager.GetActiveScene().name == "7-3")
        {
            if (Data.StageScore[6, 2] < score)                    // セーブする時のkeyCord
            {
                Data.GameScore = score;  // スコアを保存
                Data.StageScore[6, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // メソッド保存
            }
        }


    }
}
