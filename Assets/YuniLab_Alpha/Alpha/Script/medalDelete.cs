using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

[System.Serializable]   // インスタンスを保存するために必要

public class medalDelete : MonoBehaviour
{
    public int CollectItem = 0;

    private SaveSystem System => SaveSystem.Instance;  //メソッド省略
    private UserData Data => System.UserData;          //メソッド省略

    private void Start()
    {
        Data.CollectItemNow[0] = 0;
        Data.CollectItemNow[1] = 0;
        Data.CollectItemNow[2] = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        //プレイヤーtagのオブジェクトに触れたら
        if (collision.gameObject.tag == "Player")
        {
            if (this.name == "bell")
            {
                Destroy(gameObject, 0.2f);//0.2秒後に自身を消去

                CollectItem++;
                Data.CollectItemNow[0] = 1;

                BellColStage();
            }

            if (this.name == "stick")
            {
                Destroy(gameObject, 0.2f);//0.2秒後に自身を消去

                CollectItem++;
                Data.CollectItemNow[1] = 1;
                StickColStage();

            }

            if (this.name == "ribbon")
            {
                Destroy(gameObject, 0.2f);//0.2秒後に自身を消去

                CollectItem++;
                Data.CollectItemNow[2] = 1;
                RibbonColStage();
            }

            //////////SE追加に伴う変更点
            // SE再生
            SoundManager.Instance.PlaySE(SESoundData.SE.GetSuzu);
        }

        ////プレイヤーtagのオブジェクトに触れたら
        //if (collision.gameObject.tag == "Player")
        //{
        //    Destroy(gameObject, 0.2f);//0.2秒後に自身を消去

        //    ScoreItem scoreItem;
        //    GameObject obj = GameObject.Find("score/score");//オブジェクト名"Text (Legacy)"から探してくる
        //    // Debug.log(obj);
        //    if (obj != null)
        //    {
        //        scoreItem = obj.GetComponent<ScoreItem>();//ScoreItemの中身を見る
        //        if (scoreItem.score < 100000000)
        //        {
        //            scoreItem.score += 100;//スコアを加算
        //            if (scoreItem.score >= 100000000)
        //            {
        //                scoreItem.score = 99999999;
        //            }
        //        }
        //    }

        //}
    }

    private void BellColStage()
    {
        if (SceneManager.GetActiveScene().name == "1-1")
        {
            Data.CollectItemOne[0, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "1-2")
        {
            Data.CollectItemOne[1, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "1-3")
        {
            Data.CollectItemOne[2, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //----------------------------------------------------------
        //2
        if (SceneManager.GetActiveScene().name == "2-1")
        {
            Data.CollectItemTwo[0, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "2-2")
        {
            Data.CollectItemTwo[1, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "2-3")
        {
            Data.CollectItemTwo[2, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //------------------------------------------------------------
        //3
        if (SceneManager.GetActiveScene().name == "3-1")
        {
            Data.CollectItemThree[0, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "3-2")
        {
            Data.CollectItemThree[1, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "3-3")
        {
            Data.CollectItemThree[2, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //-------------------------------------------------------------
        //4
        if (SceneManager.GetActiveScene().name == "4-1")
        {
            Data.CollectItemFour[0, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "4-2")
        {
            Data.CollectItemFour[1, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "4-3")
        {
            Data.CollectItemFour[2, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //----------------------------------------------------------
        //5
        if (SceneManager.GetActiveScene().name == "5-1")
        {
            Data.CollectItemFive[0, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "5-2")
        {
            Data.CollectItemFive[1, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "5-3")
        {
            Data.CollectItemFive[2, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //------------------------------------------------------------
        //6
        if (SceneManager.GetActiveScene().name == "6-1")
        {
            Data.CollectItemSix[0, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "6-2")
        {
            Data.CollectItemSix[1, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "6-3")
        {
            Data.CollectItemSix[2, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //------------------------------------------------------------
        //7
        if (SceneManager.GetActiveScene().name == "7-1")
        {
            Data.CollectItemSeven[0, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "7-2")
        {
            Data.CollectItemSeven[1, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "7-3")
        {
            Data.CollectItemSeven[2, 0] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }
    }

    private void StickColStage()
    {
        if (SceneManager.GetActiveScene().name == "1-1")
        {
            Data.CollectItemOne[0, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "1-2")
        {
            Data.CollectItemOne[1, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "1-3")
        {
            Data.CollectItemOne[2, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //----------------------------------------------------------
        //2
        if (SceneManager.GetActiveScene().name == "2-1")
        {
            Data.CollectItemTwo[0, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "2-2")
        {
            Data.CollectItemTwo[1, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "2-3")
        {
            Data.CollectItemTwo[2, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //------------------------------------------------------------
        //3
        if (SceneManager.GetActiveScene().name == "3-1")
        {
            Data.CollectItemThree[0, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "3-2")
        {
            Data.CollectItemThree[1, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "3-3")
        {
            Data.CollectItemThree[2, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //-------------------------------------------------------------
        //4
        if (SceneManager.GetActiveScene().name == "4-1")
        {
            Data.CollectItemFour[0, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "4-2")
        {
            Data.CollectItemFour[1, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "4-3")
        {
            Data.CollectItemFour[2, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //----------------------------------------------------------
        //5
        if (SceneManager.GetActiveScene().name == "5-1")
        {
            Data.CollectItemFive[0, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "5-2")
        {
            Data.CollectItemFive[1, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "5-3")
        {
            Data.CollectItemFive[2, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //------------------------------------------------------------
        //6
        if (SceneManager.GetActiveScene().name == "6-1")
        {
            Data.CollectItemSix[0, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "6-2")
        {
            Data.CollectItemSix[1, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "6-3")
        {
            Data.CollectItemSix[2, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //------------------------------------------------------------
        //7
        if (SceneManager.GetActiveScene().name == "7-1")
        {
            Data.CollectItemSeven[0, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "7-2")
        {
            Data.CollectItemSeven[1, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "7-3")
        {
            Data.CollectItemSeven[2, 1] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }
    }

    private void RibbonColStage()
    {
        if (SceneManager.GetActiveScene().name == "1-1")
        {
            Data.CollectItemOne[0, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "1-2")
        {
            Data.CollectItemOne[1, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "1-3")
        {
            Data.CollectItemOne[2, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //----------------------------------------------------------
        //2
        if (SceneManager.GetActiveScene().name == "2-1")
        {
            Data.CollectItemTwo[0, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "2-2")
        {
            Data.CollectItemTwo[1, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "2-3")
        {
            Data.CollectItemTwo[2, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //------------------------------------------------------------
        //3
        if (SceneManager.GetActiveScene().name == "3-1")
        {
            Data.CollectItemThree[0, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "3-2")
        {
            Data.CollectItemThree[1, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "3-3")
        {
            Data.CollectItemThree[2, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //-------------------------------------------------------------
        //4
        if (SceneManager.GetActiveScene().name == "4-1")
        {
            Data.CollectItemFour[0, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "4-2")
        {
            Data.CollectItemFour[1, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "4-3")
        {
            Data.CollectItemFour[2, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //----------------------------------------------------------
        //5
        if (SceneManager.GetActiveScene().name == "5-1")
        {
            Data.CollectItemFive[0, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "5-2")
        {
            Data.CollectItemFive[1, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "5-3")
        {
            Data.CollectItemFive[2, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //------------------------------------------------------------
        //6
        if (SceneManager.GetActiveScene().name == "6-1")
        {
            Data.CollectItemSix[0, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "6-2")
        {
            Data.CollectItemSix[1, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "6-3")
        {
            Data.CollectItemSix[2, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        //------------------------------------------------------------
        //7
        if (SceneManager.GetActiveScene().name == "7-1")
        {
            Data.CollectItemSeven[0, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "7-2")
        {
            Data.CollectItemSeven[1, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }

        if (SceneManager.GetActiveScene().name == "7-3")
        {
            Data.CollectItemSeven[2, 2] = 1;  // アイテムを保存

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // メソッド保存
        }
    }
}
