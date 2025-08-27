using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

[System.Serializable]   // �C���X�^���X��ۑ����邽�߂ɕK�v

public class medalDelete : MonoBehaviour
{
    public int CollectItem = 0;

    private SaveSystem System => SaveSystem.Instance;  //���\�b�h�ȗ�
    private UserData Data => System.UserData;          //���\�b�h�ȗ�

    private void Start()
    {
        Data.CollectItemNow[0] = 0;
        Data.CollectItemNow[1] = 0;
        Data.CollectItemNow[2] = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        //�v���C���[tag�̃I�u�W�F�N�g�ɐG�ꂽ��
        if (collision.gameObject.tag == "Player")
        {
            if (this.name == "bell")
            {
                Destroy(gameObject, 0.2f);//0.2�b��Ɏ��g������

                CollectItem++;
                Data.CollectItemNow[0] = 1;

                BellColStage();
            }

            if (this.name == "stick")
            {
                Destroy(gameObject, 0.2f);//0.2�b��Ɏ��g������

                CollectItem++;
                Data.CollectItemNow[1] = 1;
                StickColStage();

            }

            if (this.name == "ribbon")
            {
                Destroy(gameObject, 0.2f);//0.2�b��Ɏ��g������

                CollectItem++;
                Data.CollectItemNow[2] = 1;
                RibbonColStage();
            }

            //////////SE�ǉ��ɔ����ύX�_
            // SE�Đ�
            SoundManager.Instance.PlaySE(SESoundData.SE.GetSuzu);
        }

        ////�v���C���[tag�̃I�u�W�F�N�g�ɐG�ꂽ��
        //if (collision.gameObject.tag == "Player")
        //{
        //    Destroy(gameObject, 0.2f);//0.2�b��Ɏ��g������

        //    ScoreItem scoreItem;
        //    GameObject obj = GameObject.Find("score/score");//�I�u�W�F�N�g��"Text (Legacy)"����T���Ă���
        //    // Debug.log(obj);
        //    if (obj != null)
        //    {
        //        scoreItem = obj.GetComponent<ScoreItem>();//ScoreItem�̒��g������
        //        if (scoreItem.score < 100000000)
        //        {
        //            scoreItem.score += 100;//�X�R�A�����Z
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
            Data.CollectItemOne[0, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "1-2")
        {
            Data.CollectItemOne[1, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "1-3")
        {
            Data.CollectItemOne[2, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //----------------------------------------------------------
        //2
        if (SceneManager.GetActiveScene().name == "2-1")
        {
            Data.CollectItemTwo[0, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "2-2")
        {
            Data.CollectItemTwo[1, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "2-3")
        {
            Data.CollectItemTwo[2, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //------------------------------------------------------------
        //3
        if (SceneManager.GetActiveScene().name == "3-1")
        {
            Data.CollectItemThree[0, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "3-2")
        {
            Data.CollectItemThree[1, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "3-3")
        {
            Data.CollectItemThree[2, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //-------------------------------------------------------------
        //4
        if (SceneManager.GetActiveScene().name == "4-1")
        {
            Data.CollectItemFour[0, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "4-2")
        {
            Data.CollectItemFour[1, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "4-3")
        {
            Data.CollectItemFour[2, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //----------------------------------------------------------
        //5
        if (SceneManager.GetActiveScene().name == "5-1")
        {
            Data.CollectItemFive[0, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "5-2")
        {
            Data.CollectItemFive[1, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "5-3")
        {
            Data.CollectItemFive[2, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //------------------------------------------------------------
        //6
        if (SceneManager.GetActiveScene().name == "6-1")
        {
            Data.CollectItemSix[0, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "6-2")
        {
            Data.CollectItemSix[1, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "6-3")
        {
            Data.CollectItemSix[2, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //------------------------------------------------------------
        //7
        if (SceneManager.GetActiveScene().name == "7-1")
        {
            Data.CollectItemSeven[0, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "7-2")
        {
            Data.CollectItemSeven[1, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "7-3")
        {
            Data.CollectItemSeven[2, 0] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }
    }

    private void StickColStage()
    {
        if (SceneManager.GetActiveScene().name == "1-1")
        {
            Data.CollectItemOne[0, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "1-2")
        {
            Data.CollectItemOne[1, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "1-3")
        {
            Data.CollectItemOne[2, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //----------------------------------------------------------
        //2
        if (SceneManager.GetActiveScene().name == "2-1")
        {
            Data.CollectItemTwo[0, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "2-2")
        {
            Data.CollectItemTwo[1, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "2-3")
        {
            Data.CollectItemTwo[2, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //------------------------------------------------------------
        //3
        if (SceneManager.GetActiveScene().name == "3-1")
        {
            Data.CollectItemThree[0, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "3-2")
        {
            Data.CollectItemThree[1, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "3-3")
        {
            Data.CollectItemThree[2, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //-------------------------------------------------------------
        //4
        if (SceneManager.GetActiveScene().name == "4-1")
        {
            Data.CollectItemFour[0, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "4-2")
        {
            Data.CollectItemFour[1, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "4-3")
        {
            Data.CollectItemFour[2, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //----------------------------------------------------------
        //5
        if (SceneManager.GetActiveScene().name == "5-1")
        {
            Data.CollectItemFive[0, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "5-2")
        {
            Data.CollectItemFive[1, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "5-3")
        {
            Data.CollectItemFive[2, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //------------------------------------------------------------
        //6
        if (SceneManager.GetActiveScene().name == "6-1")
        {
            Data.CollectItemSix[0, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "6-2")
        {
            Data.CollectItemSix[1, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "6-3")
        {
            Data.CollectItemSix[2, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //------------------------------------------------------------
        //7
        if (SceneManager.GetActiveScene().name == "7-1")
        {
            Data.CollectItemSeven[0, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "7-2")
        {
            Data.CollectItemSeven[1, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "7-3")
        {
            Data.CollectItemSeven[2, 1] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }
    }

    private void RibbonColStage()
    {
        if (SceneManager.GetActiveScene().name == "1-1")
        {
            Data.CollectItemOne[0, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "1-2")
        {
            Data.CollectItemOne[1, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "1-3")
        {
            Data.CollectItemOne[2, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //----------------------------------------------------------
        //2
        if (SceneManager.GetActiveScene().name == "2-1")
        {
            Data.CollectItemTwo[0, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "2-2")
        {
            Data.CollectItemTwo[1, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "2-3")
        {
            Data.CollectItemTwo[2, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //------------------------------------------------------------
        //3
        if (SceneManager.GetActiveScene().name == "3-1")
        {
            Data.CollectItemThree[0, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "3-2")
        {
            Data.CollectItemThree[1, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "3-3")
        {
            Data.CollectItemThree[2, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //-------------------------------------------------------------
        //4
        if (SceneManager.GetActiveScene().name == "4-1")
        {
            Data.CollectItemFour[0, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "4-2")
        {
            Data.CollectItemFour[1, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "4-3")
        {
            Data.CollectItemFour[2, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //----------------------------------------------------------
        //5
        if (SceneManager.GetActiveScene().name == "5-1")
        {
            Data.CollectItemFive[0, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "5-2")
        {
            Data.CollectItemFive[1, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "5-3")
        {
            Data.CollectItemFive[2, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //------------------------------------------------------------
        //6
        if (SceneManager.GetActiveScene().name == "6-1")
        {
            Data.CollectItemSix[0, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "6-2")
        {
            Data.CollectItemSix[1, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "6-3")
        {
            Data.CollectItemSix[2, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        //------------------------------------------------------------
        //7
        if (SceneManager.GetActiveScene().name == "7-1")
        {
            Data.CollectItemSeven[0, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "7-2")
        {
            Data.CollectItemSeven[1, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }

        if (SceneManager.GetActiveScene().name == "7-3")
        {
            Data.CollectItemSeven[2, 2] = 1;  // �A�C�e����ۑ�

            Data.CollectItemNumber++;
            SaveSystem.Instance.Save();      // ���\�b�h�ۑ�
        }
    }
}
