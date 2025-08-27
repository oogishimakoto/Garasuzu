using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using static UnityEngine.ParticleSystem;

public class CreateSW_SawanoSpecial : MonoBehaviour
{
    //=================================================
    //変数
    //=================================================

    Rigidbody rb;
    Transform tr;
    float FPS = 0.0f;


    // プレハブ格納用
    [Header("音プレハブ")]
    public GameObject HeartPrefab;
    [Header("音を出すキーコード")]
    public KeyCode key;

    [Header("どのタイミングで出すか")]
    public float startTime; 
    private bool flg=false;

    //=================================================
    //パラメーター変数
    //=================================================

    //[Header("心音閾値")]
    //public int Sinlv1 = 5;
    //public int Sinlv2 = 15;
    //public int Sinlv3 = 25;
    //public int SinMax = 40;

    [Header("音サイズ")]
    public float Size1 = 4.0f;
    //public float Size2 = 6.0f;
    //public float Size3 = 8.0f;

    [Header("音時間")]
    public float Time1 = 60.0f;
    //public float Time2 = 120.0f;
    //public float Time3 = 180.0f;

    //[Header("心音生成間隔")]
    //public int Create1 = 60;
    //public int Create2 = 55;
    //public int Create3 = 50;
    //float CreateNowTime = 0.0f;     // 経過時間
    //float CreateDeltaNowTime = 0.0f;     // 経過時間の差分

    //float MaxSinonTime = 0.0f;      // 息切れ用経過時間
    [Header("クールタイム")]
    public float CoolTime = 0.0f;
    float DelteCoolTime;  //クールタイム


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        tr = this.GetComponent<Transform>();

    }


    // Update is called once per frame
    void Update()
    {
        // フレームレート
        //FPS += Time.deltaTime;

        // クールタイム加算
        if (DelteCoolTime < startTime)
        {
            DelteCoolTime += Time.deltaTime;
        }
        if (flg == false && startTime < DelteCoolTime)
        {
            // 生成位置
            Vector3 GenePos = new Vector3(tr.position.x, tr.position.y + 0.5f, tr.position.z);
            // プレハブを指定位置に生成
            GameObject Obj = Instantiate(HeartPrefab, GenePos, Quaternion.identity);
            //Obj.GetComponent<CircleResize_Aya>().SinLevel = 1;
            Obj.GetComponent<CircleResize_SawanoSpecial>().SinSize = Size1;
            Obj.GetComponent<CircleResize_SawanoSpecial>().SinTime = Time1;

            flg= true;

        }

        if (Input.GetKeyDown(key) && DelteCoolTime >= CoolTime)
        {
            DelteCoolTime = 0.0f;

        }

        //FPSリセット
        //if (FPS >= 60 / 60.0f)
        //{
        //    FPS %= 1;
        //}

    }
}
