using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]   // インスタンスを保存するために必要

public class Characte : MonoBehaviour
{
    protected Rigidbody rb;                        // リギットボディ
    protected Animator anim;                       // アニメーション
    protected AudioSource asou;                    // サウンド
    protected ParticleSystem psys;                 // パーティクルシステム
    public Vector3 moveForward;                    // 移動度
    protected Vector3 jumpForward;                 // ジャンプの移動度
    //=================================================
    // キーコードの変数
    //=================================================
    public KeyCode leftkey = KeyCode.A;            // キーコードの変数
    public KeyCode rightkey = KeyCode.D;           // キーコードの変数
    public KeyCode jumpKey = KeyCode.Space;        // キーコードの変数
    //=================================================
    // キャラクターの変数
    //=================================================
    public Vector3 Pos = Vector3.zero;
    [Header("移動速度(15)")]
    public float speed = 15.0f;                    // キャラクターの移動スピード
    [Header("ジャンプ力(8)")]
    public float jumpPower = 8.0f;                 // キャラクターのジャンプ力
    [Header("観点角度(0,180)")]
    public float startAngle = 0.0f;                 // 観点開始角度
    public float targetAngle = 180.0f;              // 観点目標角度
    [Header("振り向きにかかる時間(0.05)")]
    public float turnTime = 0.05f;                     
    [Header("移動速度制限(3)")]
    public float limitRunSpeed = 3;                // 移動速度の制限
    [Header("上昇速度制限(1)")]
    public float limitRiseSpeed = 1;              // 上昇速度の制限
    [Header("レイの長さ(0.1,0.6)")]
    public float rayGroundDist = 0.1f;  // 地面に飛ばすレイ
    public float rayWallDist = 0.6f;    // 壁に飛ばすレイ
    public bool rightWallTouch = false; // 右側が壁に触れているかのフラグ
    public bool leftWallTouch = false;  // 左側が壁に触れているかのフラグ
    public bool groundTouch = false;    // 地面に触れているかどうか
    public bool jumpflg = false;    // ジャンプしたかどうか
    public float angleCount = 0;        // Playerの角度のカウント

    

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = this.GetComponent<Rigidbody>();        // コンポーネントを取得
        anim = this.GetComponent<Animator>();       // Animatorコンポーネントを取得
        asou = this.GetComponent<AudioSource>();    // AudioSouceコンポーネントを取得
        psys = this.GetComponent<ParticleSystem>(); // ParticleSystemコンポーネントを取得
    }



    void FixedUpdate()
    {
        // x軸の速度制限
        if (rb.velocity.magnitude > limitRunSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x / 1.1f, rb.velocity.y, rb.velocity.z);
        }
        // y軸の速度制限
        if (rb.velocity.y > limitRiseSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y / 1.1f, rb.velocity.z);
        }
        rb.AddForce(moveForward * speed, ForceMode.Force);  //移動方向にスピードを掛けてAddForce関数を実行
    }
}
