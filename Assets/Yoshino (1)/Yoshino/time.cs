using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    public Text TextTime;
    public float nowtime = 0.0f;
    private float startTime = 0.0f;

    public int keta = 10;

    private SaveSystem System => SaveSystem.Instance;  //���\�b�h�ȗ�
    private UserData Data => System.UserData;          //���\�b�h�ȗ�

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        Data.StageClear = false;
        SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        Data.StageClear = false;
    }

    // Update is called once per frame
    void Update()
    {

        //�e�L�X�g�\��
        TextTime.text = string.Format("{0}", (Time.time - startTime).ToString("f1"));

        if (Data.StageClear)
        {
            //�������܂Ŏ��o���ĕۑ�����
            nowtime = (Time.time - startTime) * keta;
            nowtime = Mathf.Floor(nowtime) / keta;
        }

        if (Data.StageClear)
        {
            TimeKeep();
        }



    }

    private void TimeKeep()
    {
        //----------------------------------------------------------
        //1
        if (SceneManager.GetActiveScene().name == "1-1")
        {
            if (Data.StageTime[0, 0] < nowtime)
            {
                Data.StageTime[0, 0] = nowtime;
                SaveSystem.Instance.Save();

            }

            Data.nowStage = 11;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "1-2")
        {
            if (Data.StageTime[0, 1] < nowtime)
            {
                Data.StageTime[0, 1] = nowtime;
            }

            Data.nowStage = 12;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "1-3")
        {
            if (Data.StageTime[0, 2] < nowtime)
            {
                Data.StageTime[0, 2] = nowtime;
            }

            Data.nowStage = 13;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        //----------------------------------------------------------------
        //2
        if (SceneManager.GetActiveScene().name == "2-1")
        {
            if (Data.StageTime[1, 0] < nowtime)
            {
                Data.StageTime[1, 0] = nowtime;
            }

            Data.nowStage = 21;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "2-2")
        {
            if (Data.StageTime[1, 1] < nowtime)
            {
                Data.StageTime[1, 1] = nowtime;
            }

            Data.nowStage = 22;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "2-3")
        {
            if (Data.StageTime[1, 2] < nowtime)
            {
                Data.StageTime[1, 2] = nowtime;
            }

            Data.nowStage = 23;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        //------------------------------------------------------------
        //3
        if (SceneManager.GetActiveScene().name == "3-1")
        {
            if (Data.StageTime[2, 0] < nowtime)
            {
                Data.StageTime[2, 0] = nowtime;
            }

            Data.nowStage = 31;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "3-2")
        {
            if (Data.StageTime[2, 1] < nowtime)
            {
                Data.StageTime[2, 1] = nowtime;
            }

            Data.nowStage = 32;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "3-3")
        {
            if (Data.StageTime[2, 2] < nowtime)
            {
                Data.StageTime[2, 2] = nowtime;
            }

            Data.nowStage = 33;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        //----------------------------------------------------------
        //4
        if (SceneManager.GetActiveScene().name == "4-1")
        {
            if (Data.StageTime[3, 0] < nowtime)
            {
                Data.StageTime[3, 0] = nowtime;
            }

            Data.nowStage = 41;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "4-2")
        {
            if (Data.StageTime[3, 1] < nowtime)
            {
                Data.StageTime[3, 1] = nowtime;
            }

            Data.nowStage = 42;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "4-3")
        {
            if (Data.StageTime[3, 2] < nowtime)
            {
                Data.StageTime[3, 2] = nowtime;
            }

            Data.nowStage = 43;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        //----------------------------------------------------------------
        //5
        if (SceneManager.GetActiveScene().name == "5-1")
        {
            if (Data.StageTime[4, 0] < nowtime)
            {
                Data.StageTime[4, 0] = nowtime;
            }

            Data.nowStage = 51;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "5-2")
        {
            if (Data.StageTime[4, 1] < nowtime)
            {
                Data.StageTime[4, 1] = nowtime;
            }

            Data.nowStage = 52;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "5-3")
        {
            if (Data.StageTime[4, 2] < nowtime)
            {
                Data.StageTime[4, 2] = nowtime;
            }

            Data.nowStage = 53;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        //------------------------------------------------------------
        //6
        if (SceneManager.GetActiveScene().name == "6-1")
        {
            if (Data.StageTime[5, 0] < nowtime)
            {
                Data.StageTime[5, 0] = nowtime;
            }

            Data.nowStage = 61;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "6-2")
        {
            if (Data.StageTime[5, 1] < nowtime)
            {
                Data.StageTime[5, 1] = nowtime;
            }

            Data.nowStage = 62;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "6-3")
        {
            if (Data.StageTime[5, 2] < nowtime)
            {
                Data.StageTime[5, 2] = nowtime;
            }

            Data.nowStage = 63;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        //------------------------------------------------------------
        //7
        if (SceneManager.GetActiveScene().name == "7-1")
        {
            if (Data.StageTime[6, 0] < nowtime)
            {
                Data.StageTime[6, 0] = nowtime;
            }

            Data.nowStage = 71;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "7-2")
        {
            if (Data.StageTime[6, 1] < nowtime)
            {
                Data.StageTime[6, 1] = nowtime;
            }

            Data.nowStage = 72;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "7-3")
        {
            if (Data.StageTime[6, 2] < nowtime)
            {
                Data.StageTime[6, 2] = nowtime;
            }

            Data.nowStage = 73;
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        }


    }
}
