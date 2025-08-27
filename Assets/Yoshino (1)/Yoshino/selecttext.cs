using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selecttext : MonoBehaviour
{
    //UIText指定用
    public Text Textscore;
    public Text TextTime;
    public GameObject bell;
    public GameObject stick;
    public GameObject ribbon;

    private GameObject select;
    private ayaSelect3D selectStage;

    private SaveSystem System => SaveSystem.Instance;  //メソッド省略
    private UserData Data => System.UserData;          //メソッド省略

    // Start is called before the first frame update
    void Start()
    {
        select = GameObject.Find("cursor");
        selectStage = select.GetComponent<ayaSelect3D>();
    }

    // Update is called once per frame
    void Update()
    {

        //アイテムの獲得状況
        ItemCollect();
    }

    public void ItemCollect()
    {
        //------------------------------------------------------------------
        //1
        if (selectStage.GetSelectStage() == 11)
        {
            deleteItem();

            if (Data.CollectItemOne[0, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemOne[0, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemOne[0, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[0, 0]);
            TextTime.text = string.Format("{0}", Data.StageTime[0, 0]);
        }

        if (selectStage.GetSelectStage() == 12)
        {
            deleteItem();

            if (Data.CollectItemOne[1, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemOne[1, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemOne[1, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[0, 1]);
            TextTime.text = string.Format("{0}", Data.StageTime[0, 1]);
        }

        if (selectStage.GetSelectStage() == 13)
        {
            deleteItem();

            if (Data.CollectItemOne[2, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemOne[2, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemOne[2, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[0, 2]);
            TextTime.text = string.Format("{0}", Data.StageTime[0, 2]);
        }

        //------------------------------------------------------------------
        //2
        if (selectStage.GetSelectStage() == 21)
        {
            deleteItem();

            if (Data.CollectItemTwo[0, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemTwo[0, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemTwo[0, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[1, 0]);
            TextTime.text = string.Format("{0}", Data.StageTime[1, 0]);
        }

        if (selectStage.GetSelectStage() == 22)
        {
            deleteItem();

            if (Data.CollectItemTwo[1, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemTwo[1, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemTwo[1, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[1, 1]);
            TextTime.text = string.Format("{0}", Data.StageTime[1, 1]);
        }

        if (selectStage.GetSelectStage() == 23)
        {
            deleteItem();

            if (Data.CollectItemTwo[2, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemTwo[2, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemTwo[2, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[1, 2]);
            TextTime.text = string.Format("{0}", Data.StageTime[1, 2]);
        }

        //------------------------------------------------------------------
        //3
        if (selectStage.GetSelectStage() == 31)
        {
            deleteItem();

            if (Data.CollectItemThree[0, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemThree[0, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemThree[0, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[2, 0]);
            TextTime.text = string.Format("{0}", Data.StageTime[2, 0]);
        }

        if (selectStage.GetSelectStage() == 32)
        {
            deleteItem();

            if (Data.CollectItemThree[1, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemThree[1, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemThree[1, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[2, 1]);
            TextTime.text = string.Format("{0}", Data.StageTime[2, 1]);
        }

        if (selectStage.GetSelectStage() == 33)
        {
            deleteItem();

            if (Data.CollectItemThree[2, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemThree[2, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemThree[2, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[2, 2]);
            TextTime.text = string.Format("{0}", Data.StageTime[2, 2]);
        }

        //------------------------------------------------------------------
        //4
        if (selectStage.GetSelectStage() == 41)
        {
            deleteItem();

            if (Data.CollectItemFour[0, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemFour[0, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemFour[0, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[3, 0]);
            TextTime.text = string.Format("{0}", Data.StageTime[3, 0]);
        }

        if (selectStage.GetSelectStage() == 42)
        {
            deleteItem();

            if (Data.CollectItemFour[1, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemFour[1, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemFour[1, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[3, 1]);
            TextTime.text = string.Format("{0}", Data.StageTime[3, 1]);
        }

        if (selectStage.GetSelectStage() == 43)
        {
            deleteItem();

            if (Data.CollectItemFour[2, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemFour[2, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemFour[2, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[3, 2]);
            TextTime.text = string.Format("{0}", Data.StageTime[3, 2]);
        }

        //------------------------------------------------------------------
        //5
        if (selectStage.GetSelectStage() == 51)
        {
            deleteItem();

            if (Data.CollectItemFive[0, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemFive[0, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemFive[0, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[4, 0]);
            TextTime.text = string.Format("{0}", Data.StageTime[4, 0]);
        }

        if (selectStage.GetSelectStage() == 52)
        {
            deleteItem();

            if (Data.CollectItemFive[1, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemFive[1, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemFive[1, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[4, 1]);
            TextTime.text = string.Format("{0}", Data.StageTime[4, 1]);
        }   

        if (selectStage.GetSelectStage() == 53)
        {
            deleteItem();

            if (Data.CollectItemFive[2, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemFive[2, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemFive[2, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[4, 2]);
            TextTime.text = string.Format("{0}", Data.StageTime[4, 2]);
        }

        //------------------------------------------------------------------
        //6
        if (selectStage.GetSelectStage() == 61)
        {
            deleteItem();

            if (Data.CollectItemSix[0, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemSix[0, 1] == 1)
            {
                stick.SetActive(true);
            }
            
            if (Data.CollectItemSix[0, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[5, 0]);
            TextTime.text = string.Format("{0}", Data.StageTime[5, 0]);
        }

        if (selectStage.GetSelectStage() == 62)
        {
            deleteItem();

            if (Data.CollectItemSix[1, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemSix[1, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemSix[1, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[5, 1]);
            TextTime.text = string.Format("{0}", Data.StageTime[5, 1]);
        }

        if (selectStage.GetSelectStage() == 63)
        {
            deleteItem();

            if (Data.CollectItemSix[2, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemSix[2, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemSix[2, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[5, 2]);
            TextTime.text = string.Format("{0}", Data.StageTime[5, 2]);
        }

        //------------------------------------------------------------------
        //7
        if (selectStage.GetSelectStage() == 71)
        {
            deleteItem();

            if (Data.CollectItemSeven[0, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemSeven[0, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemSeven[0, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[6, 0]);
            TextTime.text = string.Format("{0}", Data.StageTime[6, 0]);
        }

        if (selectStage.GetSelectStage() == 72)
        {
            deleteItem();

            if (Data.CollectItemSeven[1, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemSeven[1, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemSeven[1, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[6, 1]);
            TextTime.text = string.Format("{0}", Data.StageTime[6, 1]);
        }

        if (selectStage.GetSelectStage() == 73)
        {
            deleteItem();

            if (Data.CollectItemSeven[2, 0] == 1)
            {
                bell.SetActive(true);
            }

            if (Data.CollectItemSeven[2, 1] == 1)
            {
                stick.SetActive(true);
            }

            if (Data.CollectItemSeven[2, 2] == 1)
            {
                ribbon.SetActive(true);
            }

            //テキスト表示
            Textscore.text = string.Format("{0}", Data.StageScore[6, 2]);
            TextTime.text = string.Format("{0}", Data.StageTime[6, 2]);
        }
    }

    public void deleteItem()
    {
        bell.SetActive(false);
        stick.SetActive(false);
        ribbon.SetActive(false);
    }
}
