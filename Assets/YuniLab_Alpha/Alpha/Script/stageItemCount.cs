using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class stageItemCount : MonoBehaviour
{
    public GameObject bell;
    public GameObject stick;
    public GameObject ribbon;

    private bool bellFlg = true;
    private bool stickFlg = true;
    private bool ribbonFlg = true;

    private SaveSystem System => SaveSystem.Instance;  //メソッド省略
    private UserData Data => System.UserData;          //メソッド省略

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Data.CollectItemNow[0] == 1 && bellFlg)
        {
            //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

            bell.SetActive(true);
            bellFlg = false;
        }

        if (Data.CollectItemNow[1] == 1 && stickFlg)
        {
            //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
            stick.SetActive(true);
            stickFlg = false;
        }

        if (Data.CollectItemNow[2] == 1 && ribbonFlg)
        {
            //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
            ribbon.SetActive(true);
            ribbonFlg = false;
        }

        //-------------------------------------------------------------
        //1
        //if (SceneManager.GetActiveScene().name == "1-1")
        //{
        //    if (Data.CollectItemOne[0, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemOne[0, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemOne[0, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "1-2")
        //{
        //    if (Data.CollectItemOne[1, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemOne[1, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemOne[1, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "1-3")
        //{
        //    if (Data.CollectItemOne[2, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemOne[2, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemOne[2, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        ////----------------------------------------------------------
        ////2
        //if (SceneManager.GetActiveScene().name == "2-1")
        //{
        //    if (Data.CollectItemTwo[0, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemTwo[0, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemTwo[0, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "2-2")
        //{
        //    if (Data.CollectItemTwo[1, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemTwo[1, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemTwo[1, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "2-3")
        //{
        //    if (Data.CollectItemTwo[2, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemTwo[2, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemTwo[2, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        ////------------------------------------------------------------
        ////3
        //if (SceneManager.GetActiveScene().name == "3-1")
        //{
        //    if (Data.CollectItemThree[0, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemThree[0, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemThree[0, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "3-2")
        //{
        //    if (Data.CollectItemThree[1, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemThree[1, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemThree[1, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "3-3")
        //{
        //    if (Data.CollectItemThree[2, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemThree[2, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemThree[2, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        ////-------------------------------------------------------------
        ////4
        //if (SceneManager.GetActiveScene().name == "4-1")
        //{
        //    if (Data.CollectItemFour[0, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemFour[0, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemFour[0, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "4-2")
        //{
        //    if (Data.CollectItemFour[1, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemFour[1, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemFour[1, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "4-3")
        //{
        //    if (Data.CollectItemFour[2, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemFour[2, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemFour[2, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        ////----------------------------------------------------------
        ////5
        //if (SceneManager.GetActiveScene().name == "5-1")
        //{
        //    if (Data.CollectItemFive[0, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemFive[0, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemFive[0, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "5-2")
        //{
        //    if (Data.CollectItemFive[1, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemFive[1, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemFive[1, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "5-3")
        //{
        //    if (Data.CollectItemFive[2, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemFive[2, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemFive[2, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        ////------------------------------------------------------------
        ////6
        //if (SceneManager.GetActiveScene().name == "6-1")
        //{
        //    if (Data.CollectItemSix[0, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemSix[0, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemSix[0, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "6-2")
        //{
        //    if (Data.CollectItemSix[1, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemSix[1, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemSix[1, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "6-3")
        //{
        //    if (Data.CollectItemSix[2, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemSix[2, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemSix[2, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        ////------------------------------------------------------------
        ////7
        //if (SceneManager.GetActiveScene().name == "7-1")
        //{
        //    if (Data.CollectItemSeven[0, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemSeven[0, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemSeven[0, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "7-2")
        //{
        //    if (Data.CollectItemSeven[1, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemSeven[1, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemSeven[1, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}

        //if (SceneManager.GetActiveScene().name == "7-3")
        //{
        //    if (Data.CollectItemSeven[2, 0] == 1 && bellFlg)
        //    {
        //        //bell.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);

        //        bell.SetActive(true);
        //        bellFlg = false;
        //    }

        //    if (Data.CollectItemSeven[2, 1] == 1 && stickFlg)
        //    {
        //        //stick.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        stick.SetActive(true);
        //        stickFlg = false;
        //    }

        //    if (Data.CollectItemSeven[2, 2] == 1 && ribbonFlg)
        //    {
        //        //ribbon.GetComponent<Image>().material.color = new Color(255, 255, 255, 255);
        //        ribbon.SetActive(true);
        //        ribbonFlg = false;
        //    }
        //}
    }
}
