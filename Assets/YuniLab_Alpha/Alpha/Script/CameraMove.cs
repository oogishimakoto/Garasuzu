using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public string charaName = "Player"; // オブジェクト名を追尾する。
    public float VecX = 0;
    [Header("1を入力")]
    public float VecY = 0;
    [Header("-10を入力")]
    public float VecZ = 0;
    public float CameraPosX = 0;
    public float CameraPosY = 0;
    public float AnglX = 0;
    public float AnglY = 0;
    public float AnglZ = 0;
    [Header("カメラ座標左限(ステージ端に合わせる)")]
    public float CamRimitL = 0;
    [Header("カメラ座標右限(ステージ端に合わせる)")]
    public float CamRimitR = 0;
    [Header("カメラ座標上限(ステージ端に合わせる)")]
    public float CamRimitT = 0;
    [Header("カメラ座標下限(ステージ端に合わせる)")]
    public float CamRimitB = 0;
    [Header("ズームフラグ")]
    public bool ZoomFlg = false;

    GameObject charaObj;          // キャラクターオブジェクト
    GameObject cameraObj;         // カメラオブジェクト取得
    Vector3 cameraVec;            // カメラの位置
    Vector3 cameraAngl;           // カメラの角度
    // Start is called before the first frame update
    void Start()
    {
        // 名前検索でScene中からオブジェクトを見つける
        charaObj = GameObject.Find(charaName);
        cameraVec = new Vector3(0.0f, 0.0f, 0.0f);
        cameraAngl = new Vector3(0.0f, 0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        // カメラの座標を代入する。
        cameraVec.x = charaObj.transform.position.x + VecX + CameraPosX;         // X座標はキャラと同じ
        if (cameraVec.x < CamRimitL)
        {
            cameraVec.x = CamRimitL;
        }
        if (cameraVec.x > CamRimitR)
        {
            cameraVec.x = CamRimitR;
        }
        cameraVec.y = charaObj.transform.position.y + VecY + CameraPosY;         // Y座標はキャラと同じ
        if (cameraVec.y < CamRimitB)
        {
            cameraVec.y = CamRimitB;
        }
        if (cameraVec.y > CamRimitT)
        {
            cameraVec.y = CamRimitT;
        }

        //ズーム
        if (ZoomFlg == true)
        {
            VecZ = VecZ += 0.02f;
            if (VecZ > -5)
            {
                VecZ = -5;
            }
        }


        cameraVec.z = VecZ;                                                      // Z座標はキャラと距離
        cameraAngl.x = AnglX;                                                    // カメラの角度
        cameraAngl.y = AnglY;                                                    // カメラの角度
        cameraAngl.z = AnglZ;                                                    // カメラの角度
        this.transform.position = cameraVec;                                     // カメラの座標適用
        this.transform.localEulerAngles = cameraAngl;
    }
}
