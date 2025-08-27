using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   // �C���X�^���X��ۑ����邽�߂ɕK�v
public class UserData
{
    //==================================================
    // �ۑ��������ϐ�������
    //==================================================
    public Vector3 Pos = Vector3.zero;
    public int GameScore = 0;   //�X�R�A
    public int CollectItemNumber = 0;   //�X�e�[�W�ŃA�C�e�����l��������
    //���݂̃V�[���Ŋl�������A�C�e���̐�
    public int[] CollectItemNow = new int[3] { 0, 0, 0 };
    public bool ScoreOver = false; //score��������
    //�X�e�[�W�Ŋl�������A�C�e��
    public int[,] CollectItemOne = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    public int[,] CollectItemTwo = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    public int[,] CollectItemThree = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    public int[,] CollectItemFour = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    public int[,] CollectItemFive = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    public int[,] CollectItemSix = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    public int[,] CollectItemSeven = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

    public float[,] StageTime = new float[7, 3]
{ { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };  //time
    public int nowStage = 0;
    public int[,] StageScore = new int[7, 3]
    { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }; //�z��̐錾 

    public bool StageClear = false; //�X�e�[�W�N���A������
    public bool[,] StageClearAll = new bool[7, 3]
    { {false,false,false },{false,false,false },{false,false,false },{false,false,false },{false,false,false },{false,false,false },{false,false,false } };
}
