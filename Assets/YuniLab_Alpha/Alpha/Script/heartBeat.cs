using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
//using UTJ;
using static UnityEngine.ParticleSystem;

public class heartBeat : MonoBehaviour
{
    //=================================================
    //変数
    //=================================================
    //public AnimationCurve curve;
    float startTime; //初まった時の時間

    GameObject player;

    Vector3 playerVec;

    GameObject Circle;                       //心音範囲の上限の円の大きさを
    beat circle;

    [Header("生成する音オブジェクト")]
    public GameObject HeartPrefab;  //プレイヤーから出す音の形

    [Header("音発生ボタン")]
    public KeyCode MakeBeat = KeyCode.B;            // キーコードの変数

    [Header("音角度変更関係")]
    public KeyCode AngleChangeLeft = KeyCode.N;            // キーコードの変数
    public KeyCode AngleChangeRight = KeyCode.M;            // キーコードの変数

    public Quaternion nowAngle = Quaternion.Euler(0f, 0f, 0f);  //角度変更用
    public Quaternion nowAngleCapsule = Quaternion.Euler(90f, 0f, 90f); //角度変更用

    [Header("1回で変わる角度")]
    public float changeAngle = 90f;

    float angleZ = 0f;
    float CapsuleAngleZ = 90f;

    //=================================================
    //パラメーター変数
    //=================================================
    float FPS = 0.0f;

    [Header("音のクールタイム")]
    public float coolTime = 5.0f;   //初期値は「5.0f」
    float coolTimecount = 0.0f;

    //bool hlk = true;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerVer1.01");
        startTime = Time.time;
        coolTimecount = coolTime * Time.deltaTime;
        CapsuleAngleZ = 90f;
    }


    // Update is called once per frame
    void Update()
    {
        coolTimecount++;

        playerVec = player.GetComponent<Player>().moveForward;  //プレイヤーの移動を取得する

        //フレームレート
        FPS += Time.deltaTime;
        
        // bを押せばにプレハブを生成
        if (Input.GetKeyDown(MakeBeat) && coolTimecount >= coolTime)
        {
             // 生成位置
             Vector3 pos = player.transform.position;
             // プレハブを指定位置に生成
             GameObject Obj = Instantiate(HeartPrefab, new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z), Quaternion.identity);

             startTime = Time.time;

            coolTimecount = 0.0f;
        }

        //---------------------------------------------------------------
        //角度変更
        if (Input.GetKeyDown(AngleChangeLeft))
        {
            angleZ += changeAngle;

            if(angleZ >= 360 || angleZ <= 0)
            {
                angleZ = 0f;
            }

           
            CapsuleAngleZ += changeAngle;

            if (CapsuleAngleZ >= 360 || CapsuleAngleZ <= 0)
            {
                CapsuleAngleZ = 0f;
            }

            nowAngle = Quaternion.Euler(0f, 0f, angleZ);
            nowAngleCapsule = Quaternion.Euler(0f, 0f, CapsuleAngleZ);
        }

        if (Input.GetKeyDown(AngleChangeRight))
        {
            if (angleZ >= 360 || angleZ <= 0)
            {
                angleZ = 360f;
            }

            angleZ -= changeAngle;
           

            if (CapsuleAngleZ >= 360 || CapsuleAngleZ <= 0)
            {
                CapsuleAngleZ = 360f;
            }

            CapsuleAngleZ -= changeAngle;

            nowAngle = Quaternion.Euler(0f, 0f, angleZ);
            nowAngleCapsule = Quaternion.Euler(0f, 0f, CapsuleAngleZ);
        }

        //変な値入った時の補正処理
        if(changeAngle < 0f)
        {
            changeAngle = 0f;
        }
        if (changeAngle > 360f)
        {
            changeAngle = 360f;
        }

        //FPSリセット
        if (FPS >= 60 / 60.0f)
        {
            FPS %= 1;
        }

    }




}
