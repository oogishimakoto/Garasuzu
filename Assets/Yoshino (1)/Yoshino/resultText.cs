using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class resultText : MonoBehaviour
{
    //UIText指定用
    public UnityEngine.UI.Text Textscore;
    public UnityEngine.UI.Text TextTime;

    //アイテム表示用
    public GameObject bell;
    public GameObject stick;
    public GameObject ribbon;

    public GameObject pointbell;
    public GameObject pointstick;
    public GameObject pointribbon;

    public GameObject stageSelect;

    [Header("スコアを出すフレーム")]
    public float scoreFrame = 1.0f;

    //何回に分けてスコアを表示するか
    private int countMax = 4;

    private SaveSystem System => SaveSystem.Instance;  //メソッド省略
    private UserData Data => System.UserData;          //メソッド省略

    private string words;
    private string[] wordArray;
    private int count;

    private float startTime = 0.0f;

    bool seniaflg;

    /////////////////////澤野追記
    private PlayerInput RP;
    private InputActionMap ResultSet;
    private InputAction _Kettei;

    // Start is called before the first frame update
    void Start()
    {
        //words = string.Format("リザルト,\nScore:{0},\nタイム：{1}", Data.StageScore[0, 0], Data.StageTime[0, 0]);
        //nowStageTime();
        startTime = Time.time;
        seniaflg = false;
        count = 0;

        //////////////////////////////澤野追記
        RP = GetComponent<PlayerInput>();
        ResultSet = RP.currentActionMap;
        _Kettei = ResultSet["Kettei"];
    }

    // Update is called once per frame
    void Update()
    {
        ////////////////////////澤野追記
        bool _kettei = _Kettei.triggered;
        //スコア表示
        if ((Time.time - startTime) > scoreFrame)
        {
            SetText();
            count++;
            startTime = Time.time;
        }

        if (seniaflg)
        {
            if (Input.GetKeyDown(KeyCode.Return) || _kettei == true)
            {
                SceneManager.LoadScene("select3D");
            }
        }

        //nowStageTime();
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    SetText();
        //    count++;
        //}
        //Textscore.text = string.Format("リザルト\n\nScore:{0}\n\nタイム：{0}", Data.StageScore[0, 0], Data.StageTime[0, 0]);
        //アイテムの獲得状況

    }
    void SetText()
    {
        //スコア表示
        nowStageTime();

        //
        if (count == 3)
        {
            ItemCollect();
        }
        Debug.Log(Data.nowStage);
        if (count >= countMax)
        {
            seniaflg = true;
            stageSelect.SetActive(true);
        }



    }

    private void nowStageTime()
    {
        //-----------------------------------------------------------------------
        //1
        if (Data.nowStage == 11)
        {
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[0, 0]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[0, 0]);
            }

        }

        if (Data.nowStage == 12)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[0, 1]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[0, 1]);
            }
        }

        if (Data.nowStage == 13)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[0, 2]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[0, 2]);
            }
        }

        //--------------------------------------------------------------------------
        //2
        if (Data.nowStage == 21)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[1, 0]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[1, 0]);
            }
        }

        if (Data.nowStage == 22)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[1, 1]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[1, 1]);
            }
        }

        if (Data.nowStage == 23)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[1, 2]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[1, 2]);
            }
        }

        //-------------------------------------------------------------------------
        //3
        if (Data.nowStage == 31)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[2, 0]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[2, 0]);
            }
        }

        if (Data.nowStage == 32)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[2, 1]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[2, 1]);
            }
        }

        if (Data.nowStage == 33)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[2, 2]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[2, 2]);
            }
        }

        //-----------------------------------------------------------------------
        //4
        if (Data.nowStage == 41)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[3, 0]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[3, 0]);
            }
        }

        if (Data.nowStage == 42)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[3, 1]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[3, 1]);
            }
        }

        if (Data.nowStage == 43)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[3, 2]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[3, 2]);
            }
        }

        //--------------------------------------------------------------------------
        //5
        if (Data.nowStage == 51)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[4, 0]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[4, 0]);
            }
        }

        if (Data.nowStage == 52)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[4, 1]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[4, 1]);
            }
        }

        if (Data.nowStage == 53)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[4, 2]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[4, 2]);
            }
        }

        //-------------------------------------------------------------------------
        //6
        if (Data.nowStage == 61)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[5, 0]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[5, 0]);
            }
        }

        if (Data.nowStage == 62)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[5, 1]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[5, 1]);
            }
        }

        if (Data.nowStage == 63)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[5, 2]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[5, 2]);
            }
        }

        //-------------------------------------------------------------------------
        //7
        if (Data.nowStage == 71)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[6, 0]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[6, 0]);
            }
        }

        if (Data.nowStage == 72)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[6, 1]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[6, 1]);
            }
        }

        if (Data.nowStage == 73)
        {
            //テキスト表示
            if (count == 1)
            {
                Textscore.text = string.Format("{0}", Data.StageScore[6, 2]);
            }
            //テキスト表示
            if (count == 2)
            {
                TextTime.text = string.Format("{0}", Data.StageTime[6, 2]);
            }
        }
    }

    public void ItemCollect()
    {
        //------------------------------------------------------------------
        //1
        if (Data.nowStage == 11)
        {
            if (Data.CollectItemOne[0, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemOne[0, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemOne[0, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 12)
        {
            if (Data.CollectItemOne[1, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemOne[1, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemOne[1, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 13)
        {
            if (Data.CollectItemOne[2, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemOne[2, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemOne[2, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        //----------------------------------------------------------
        //2
        if (Data.nowStage == 21)
        {
            if (Data.CollectItemTwo[0, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemTwo[0, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemTwo[0, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 22)
        {
            if (Data.CollectItemTwo[1, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemTwo[1, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemTwo[1, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 23)
        {
            if (Data.CollectItemTwo[1, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemTwo[1, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemTwo[1, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        //-----------------------------------------------------------
        //3
        if (Data.nowStage == 31)
        {
            if (Data.CollectItemThree[0, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemThree[0, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemThree[0, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 32)
        {
            if (Data.CollectItemThree[1, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemThree[1, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemThree[1, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 33)
        {
            if (Data.CollectItemThree[2, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemThree[2, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemThree[2, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        //--------------------------------------------------------------
        //4
        if (Data.nowStage == 41)
        {
            if (Data.CollectItemFour[0, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemFour[0, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemFour[0, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 42)
        {
            if (Data.CollectItemFour[1, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemFour[1, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemFour[1, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 43)
        {
            if (Data.CollectItemFour[2, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemFour[2, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemFour[2, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        //--------------------------------------------------------------------
        //5
        if (Data.nowStage == 51)
        {
            if (Data.CollectItemFive[0, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemFive[0, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemFive[0, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 52)
        {
            if (Data.CollectItemFive[1, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemFive[1, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemFive[1, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 53)
        {
            if (Data.CollectItemFive[1, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemFive[1, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemFive[1, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        //----------------------------------------------------------------------------
        //6
        if (Data.nowStage == 61)
        {
            if (Data.CollectItemSix[0, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemSix[0, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemSix[0, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 62)
        {
            if (Data.CollectItemSix[1, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemSix[1, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemSix[1, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 63)
        {
            if (Data.CollectItemSix[2, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemSix[2, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemSix[2, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        //----------------------------------------------------------------------------
        //7
        if (Data.nowStage == 71)
        {
            if (Data.CollectItemSeven[0, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemSeven[0, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemSeven[0, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 72)
        {
            if (Data.CollectItemSeven[1, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemSeven[1, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemSeven[1, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }

        if (Data.nowStage == 73)
        {
            if (Data.CollectItemSeven[2, 0] == 1)
            {
                bell.SetActive(true);
                pointbell.SetActive(false);
            }

            if (Data.CollectItemSeven[2, 1] == 1)
            {
                stick.SetActive(true);
                pointstick.SetActive(false);
            }

            if (Data.CollectItemSeven[2, 2] == 1)
            {
                ribbon.SetActive(true);
                pointribbon.SetActive(false);
            }
        }
    }
}
