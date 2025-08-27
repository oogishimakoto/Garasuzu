using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]   // �C���X�^���X��ۑ����邽�߂ɕK�v

public class ScoreItem : MonoBehaviour
{
    //UIText�w��p
    public Text Textscore;
    //�\���p�ϐ�
    public int score;
    private int DisplayScore = 0;
    private int TargetScore = 0;
    private int DifferenceScore = 0;
    private float ElapsedTime = 0;

    private SaveSystem System => SaveSystem.Instance;  //���\�b�h�ȗ�
    private UserData Data => System.UserData;          //���\�b�h�ȗ�


    // Start is called before the first frame update
    void Start()
    {
        //�X�R�A�̏�����
        score = 0;
        Data.ScoreOver = false;

    }

    // ------------------------------------
    // ��������

    private void FixedUpdate()
    {

        // �ڕW�X�R�A���Z�b�g
        if (TargetScore != score)
        {
            TargetScore = score;
            // �������Čv�Z
            DifferenceScore = TargetScore - DisplayScore;
            //���Ԃ����Z�b�g
            ElapsedTime = 0;
        }

        if (DisplayScore < score)
        {
            DisplayScore += (int)(DifferenceScore * ElapsedTime);
            ElapsedTime += Time.fixedDeltaTime;

            //�X�R�A�𐮂���
            if (score <= DisplayScore)
            {
                DisplayScore = score;
            }
        }

        Textscore.text = string.Format("{0}", DisplayScore);
    }

    // ------------------------------------
    // �����܂ł�4-1�̏�ɂ���Textscore�������܂�

    // Update is called once per frame
    void Update()
    {
        //-------------------------------------------------------------
        //1

        //Textscore.text = string.Format("{0}", score);


        if (SceneManager.GetActiveScene().name == "1-1")
        {
            if (Data.StageScore[0, 0] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[0, 0] = score;
                Data.ScoreOver = true;
                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "1-2")
        {
            if (Data.StageScore[0, 1] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[0, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "1-3")
        {
            if (Data.StageScore[0, 2] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[0, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        //----------------------------------------------------------
        //2
        if (SceneManager.GetActiveScene().name == "2-1")
        {
            if (Data.StageScore[1, 0] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[1, 0] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "2-2")
        {
            if (Data.StageScore[1, 1] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[1, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "2-3")
        {
            if (Data.StageScore[1, 2] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[1, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        //------------------------------------------------------------
        //3
        if (SceneManager.GetActiveScene().name == "3-1")
        {
            if (Data.StageScore[2, 0] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[2, 0] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "3-2")
        {
            if (Data.StageScore[2, 1] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[2, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "3-3")
        {
            if (Data.StageScore[2, 2] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[2, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        //-------------------------------------------------------------
        //4
        if (SceneManager.GetActiveScene().name == "4-1")
        {
            if (Data.StageScore[3, 0] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[3, 0] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "4-2")
        {
            if (Data.StageScore[3, 1] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[3, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "4-3")
        {
            if (Data.StageScore[3, 2] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[3, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        //----------------------------------------------------------
        //5
        if (SceneManager.GetActiveScene().name == "5-1")
        {
            if (Data.StageScore[4, 0] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[4, 0] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "5-2")
        {
            if (Data.StageScore[4, 1] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[4, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "5-3")
        {
            if (Data.StageScore[4, 2] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[4, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        //------------------------------------------------------------
        //6
        if (SceneManager.GetActiveScene().name == "6-1")
        {
            if (Data.StageScore[5, 0] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[5, 0] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "6-2")
        {
            if (Data.StageScore[5, 1] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[5, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "6-3")
        {
            if (Data.StageScore[5, 2] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[5, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        //------------------------------------------------------------
        //7
        if (SceneManager.GetActiveScene().name == "7-1")
        {
            if (Data.StageScore[6, 0] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[6, 0] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "7-2")
        {
            if (Data.StageScore[6, 1] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[6, 1] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }

        if (SceneManager.GetActiveScene().name == "7-3")
        {
            if (Data.StageScore[6, 2] < score)                    // �Z�[�u���鎞��keyCord
            {
                Data.GameScore = score;  // �X�R�A��ۑ�
                Data.StageScore[6, 2] = score;
                Data.ScoreOver = true;

                SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
            }
        }


    }
}
