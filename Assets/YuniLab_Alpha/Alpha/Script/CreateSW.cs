using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using static UnityEngine.ParticleSystem;
using UnityEngine.InputSystem;

public class CreateSW : MonoBehaviour
{
    //=================================================
    //変数
    //=================================================

    Rigidbody rb;
    Transform tr;
    float FPS = 0.0f;
    private Animator animator;//アニメーター用

    // プレハブ格納用
    [Header("音プレハブ")]
    public GameObject HeartPrefab;
    [Header("音を出すキーコード")]
    public KeyCode key;

    private bool Death = false;
    public ParticleSystem RingBell;

    [Header("ポーズのスクリプトが入ってるオブジェクト")]
    public GameObject Pauseobj;

    Pause Ppause;
    bool beforpause = false;

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

    private PlayerInput PI;
    private InputActionMap BeatSet;
    private InputAction _beat;

    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody>();
        RingBell = this.GetComponentInChildren<ParticleSystem>();
        tr = this.GetComponent<Transform>();
        animator = GetComponent<Animator>();//アニメーターコンポーネント取得

        /////澤野追記
        PI = GetComponent<PlayerInput>();
        BeatSet = PI.currentActionMap;
        _beat = BeatSet["Beat"];
        Ppause = Pauseobj.GetComponent<Pause>();
        if (Ppause == null) { Debug.LogError("ないでええ"); }
    }


    // Update is called once per frame
    void Update()
    {
        // フレームレート
        //FPS += Time.deltaTime;
        /////澤野追記
        bool beatflg = _beat.triggered;

        // クールタイム加算
        if (DelteCoolTime < CoolTime)
        {
            DelteCoolTime += Time.deltaTime;
        }


        if (/*(Input.GetKeyDown(key) && DelteCoolTime >= CoolTime && Death == false )|| */((beatflg == true && beforpause == false && DelteCoolTime >= CoolTime && Death == false)) )
        {
            RingBell.Play();
            animator.SetTrigger("SoundMake");
            // 生成位置
            Vector3 GenePos = new Vector3(tr.position.x, tr.position.y + 0.5f, tr.position.z);
            // プレハブを指定位置に生成
            GameObject Obj = Instantiate(HeartPrefab, GenePos, Quaternion.identity);
            //Obj.GetComponent<CircleResize_Aya>().SinLevel = 1;
            Obj.GetComponent<CircleResize>().SinSize = Size1;
            Obj.GetComponent<CircleResize>().SinTime = Time1;

            DelteCoolTime = 0.0f;

            //////////SE追加に伴う変更点
            SoundManager.Instance.PlaySE(SESoundData.SE.SoundW_W);
        }




        //FPSリセット
        //if (FPS >= 60 / 60.0f)
        //{
        //    FPS %= 1;
        //}
        beforpause = Ppause.pauseflg;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // ぶつかってきたオブジェクトが敵なら
        if (collision.gameObject.tag == "Enemy")
        {

            Death = true;


        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // ぶつかってきたオブジェクトが敵なら
        if (collision.gameObject.tag == "Enemy")
        {

            Death = false;


        }
    }
}
