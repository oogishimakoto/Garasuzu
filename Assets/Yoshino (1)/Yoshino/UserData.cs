using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   // インスタンスを保存するために必要
public class UserData
{
    //==================================================
    // 保存したい変数を書く
    //==================================================
    public Vector3 Pos = Vector3.zero;
    public int GameScore = 0;   //スコア
    public int CollectItemNumber = 0;   //ステージでアイテムを獲得した個数
    //現在のシーンで獲得したアイテムの数
    public int[] CollectItemNow = new int[3] { 0, 0, 0 };
    public bool ScoreOver = false; //score超えたか
    //ステージで獲得したアイテム
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
    { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }; //配列の宣言 

    public bool StageClear = false; //ステージクリアしたか
    public bool[,] StageClearAll = new bool[7, 3]
    { {false,false,false },{false,false,false },{false,false,false },{false,false,false },{false,false,false },{false,false,false },{false,false,false } };
}
