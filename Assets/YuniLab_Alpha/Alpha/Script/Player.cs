using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Player : Characte
{
    // Playerはシングルトンにしとく
    #region Singleton
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<Player>();
            {
                return instance;
            }
        }
    }
    #endregion
    private SaveSystem System => SaveSystem.Instance;  //メソッド省略
    private UserData Data => System.UserData;          //メソッド省略
    private int stopTimer = 0;  // プレイヤーの動きを一定時間止めるためのタイマー
    private Animator animator;//アニメーター用


    [Header("ジャンプ総時間(1)")]
    public float JumpallTime = 1.00f;
    [Header("チャージにかかる時間(0.1)")]
    public float CcargeTime = 0.1f;
    [Header("上昇にかかる時間(0.2)")]
    public float UpTime = 0.2f;
    [Header("落下にかかる時間(0.6)")]
    public float foleTime = 0.6f;
    [Header("着地後硬直時間(0.1)")]
    public float tyakutiTime = 0.1f;
    [Header("現在時間(テスト用)")]
    public float nowtime = 0.0f;

    [Header("ショックタイム(最大)")]
    public float Maxshocktime;

    [Header("ショックタイム(現在)")]
    public float Nowshocktime = 0.0f;

    public bool UseKey = true;

    //////////SE追加に伴う変更点
    private bool lastGroundTouch = false;
    private bool deadFlg = false;

    [Header("右を向いているか否か")]
    public bool Right = false;
    ///////澤野追記(4/25)
    [Header("ポーズしているか否か")]
    public bool The_World = false;

    ////////////澤野追記
    private PlayerInput PInput;
    private InputActionMap PlayerSet;
    private InputAction _RightMove;
    private InputAction _LeftMove;
    private InputAction _Jump;
    private InputAction _Beat;
    private InputAction _Pause;

    public void SetTheWorld(bool flg)
    {
        The_World = flg;
    }

    protected override void Start()         　// オーバーライド
    {
        base.Start();                        // 親のStart呼び出し

        ////////澤野追記
        PInput = GetComponent<PlayerInput>();
        PlayerSet = PInput.currentActionMap;
        _RightMove = PlayerSet["MoveRight"];
        _LeftMove = PlayerSet["MoveLeft"];
        _Jump = PlayerSet["Jump"];
        _Beat = PlayerSet["Beat"];
        _Pause = PlayerSet["The_World"];

        animator = GetComponent<Animator>();//アニメーターコンポーネント取得
        //this.transform.position = Data.Pos;  // ロードした位置にCharacterを移動させる
        Data.Pos = Player.Instance.transform.position;  // ポジションを保存
        SaveSystem.Instance.Save();                     // メソッド保存
    }
    // Update is called once per frame
    void Update()
    {
        //澤野追記
        bool rightflg = _RightMove.IsPressed();
        bool leftflg = _LeftMove.IsPressed();
        bool _jumpflg = _Jump.triggered;
        bool beatflg = _Beat.triggered;
        bool pauseflg = _Pause.triggered;

        //キーが使える状態であれば

        /////////澤野追記(4/25)ポーズするフラグをtrueにしたり、状況に応じてrigidbodyのFreezePositionをtrueにしたりする
        if ((pauseflg == true ) && SceneManager.GetActiveScene().name != "title")//|| pauseflg == true)
        {
            if (The_World == true)
            {
                The_World = false;
                rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                Time.timeScale = 1;
            }
            else if (The_World == false)
            {
                The_World = true;
                rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
                Time.timeScale = 0;
            }
        }


        //if (Input.GetKeyDown(KeyCode.Q))                    // セーブする時のkeyCord
        //{
        //    Data.Pos = Player.Instance.transform.position;  // ポジションを保存
        //    SaveSystem.Instance.Save();                     // メソッド保存
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    this.transform.position = Data.Pos;
        //    SaveSystem.Instance.Load();                     // scriptの参照
        //}

        if (The_World == false & UseKey == true)//ポーズ中はこの中は通らない
        {
            if (stopTimer <= 0)
            {
                //=================================================
                //プレイヤーの移動処理
                //=================================================
                moveForward = new Vector3(0.0f, 0.0f, 0.0f);    // 移動度セット 

                // 右キーが押された
                // 壁に接触中は移動を制限してめり込まないようにする
                if (/*Input.GetKey(rightkey) ||*/ rightflg == true && rightWallTouch != true)
                {
                    moveForward.x = 1;  // 移動
                    Right = true;
                    startAngle = this.transform.eulerAngles.y;  // 開始角度セット
                    targetAngle = 90.0f + 0.01f;  // 目標角度をセット（角度がおかしくならないよう0.01fを加算）
                    angleCount = 0;             // 回転状態を0に
                    animator.SetBool("Run", true);
                }
                // 左キーが押された
                // 壁に接触中は移動を制限してめり込まないようにする
                else if (/*Input.GetKey(leftkey) ||*/ leftflg == true && leftWallTouch != true)
                {
                    moveForward.x = -1; // 移動
                    Right = false;
                    startAngle = this.transform.eulerAngles.y;  // 開始角度セット
                    targetAngle = 270.0f;   // 目標角度をセット
                    angleCount = 0;         // 回転状態を0に
                    animator.SetBool("Run", true);
                }
                else
                {
                    animator.SetBool("Run", false);
                    if (Right == false)
                    {
                        targetAngle = 180.0f;
                    }
                }
                //=================================================
                // プレイヤーのジャンプ処理
                //=================================================
                jumpForward = new Vector3(0.0f, 0.0f, 0.0f);                    // 移動度セット

                if (/*(Input.GetKeyDown(jumpKey) && groundTouch == true) ||*/ (_jumpflg == true && groundTouch == true) )           // スペースを押すと&&Touchフラグがtrueなら
                {
                    jumpForward.y = 3.0f;
                    lastGroundTouch = true;
                    rb.AddForce(jumpForward * jumpPower, ForceMode.Impulse);    //移動方向にスピードを掛けてAddForce関数を実行(Impulse)一瞬で力を掛ける。
                    jumpflg = true;
                    //////////SE追加に伴う変更点
                    SoundManager.Instance.PlaySE(SESoundData.SE.Jump);
                }


                if (jumpflg == true)
                {
                    nowtime += Time.deltaTime;
                    if (nowtime <= CcargeTime)
                    {
                        animator.SetBool("Charge", true);
                    }
                    else if (nowtime <= CcargeTime + UpTime)
                    {
                        animator.SetBool("Charge", false);
                        animator.SetBool("Up", true);

                    }
                    else if (nowtime <= CcargeTime + UpTime + foleTime)
                    {
                        animator.SetBool("Up", false);
                        animator.SetBool("Down", true);
                    }
                    else if (nowtime <= CcargeTime + UpTime + foleTime + tyakutiTime)
                    {
                        animator.SetBool("Down", false);
                        animator.SetBool("Landing", true);

                    }
                }

                if (nowtime >= JumpallTime)
                {
                    animator.SetBool("Landing", false);
                    lastGroundTouch = false;
                    jumpflg = false;
                    nowtime = 0.0f;
                    SoundManager.Instance.PlaySE(SESoundData.SE.Lading);
                }


            }

        }



        if (UseKey == false)
        {
            animator.SetBool("Shock", true);
            Nowshocktime += Time.deltaTime;
            if (Maxshocktime < Nowshocktime)
            {

                //SceneManager.LoadScene("1-1"); //シーンを読み込む
                Nowshocktime = 0.0f;
                this.transform.position = Data.Pos;
                SaveSystem.Instance.Load();                     // scriptの参照
                UseKey = true;
                animator.SetBool("Shock", false);
            }
        }

        //=================================================
        // プレイヤーの角度処理
        //=================================================
        if (angleCount <= 1.0f)
        {
            // 回転度合を増加させる
            angleCount += Time.deltaTime / turnTime;
        }
        else
        {
            angleCount = 1.0f;
        }
        float angle = Mathf.LerpAngle(startAngle, targetAngle, angleCount);  // 回転開始角度と回転目標角度から現在の角度を計算する
        this.transform.eulerAngles = new Vector3(0.0f, angle, 0.0f);   // 現在の角度を設定する
                                                                       //=================================================
                                                                       // レイを飛ばす
                                                                       //=================================================
                                                                       // 地面との判定
        Vector3 rayOri = new Vector3(0.0f, 0.05f, 0.0f);    // レイの開始位置
        Vector3 rayDir = new Vector3(0.0f, -1.0f, 0.0f);    // レイの方向
        float rayDist = 0.1f;   // オブジェクトとの距離
        groundTouch = FlgRayCheck(groundTouch, rayOri, rayDir, rayDist);


        // 右の壁
        rayOri = new Vector3(0.0f, 0.1f, 0.0f);    // レイの開始位置
        rayDir = new Vector3(1.0f, 0.0f, 0.0f);   // レイの方向
        rayDist = 0.3f;   // オブジェクトとの距離
        rightWallTouch = FlgRayCheck(rightWallTouch, rayOri, rayDir, rayDist);
        if (rightWallTouch == true)
        {

        }
        // 下部が触れていない場合上部を調べる
        else
        {
            rayOri = new Vector3(0.0f, 0.9f, 0.0f);    // レイの開始位置
            rightWallTouch = FlgRayCheck(rightWallTouch, rayOri, rayDir, rayDist);
        }

        // 左の壁
        rayOri = new Vector3(0.0f, 0.1f, 0.0f);    // レイの開始位置
        rayDir = new Vector3(-1.0f, 0.0f, 0.0f);   // レイの方向
        rayDist = 0.3f;   // オブジェクトとの距離
        leftWallTouch = FlgRayCheck(leftWallTouch, rayOri, rayDir, rayDist);
        if (leftWallTouch == true)
        {

        }
        // 下部が触れていない場合上部を調べる
        else
        {
            rayOri = new Vector3(0.0f, 0.9f, 0.0f);    // レイの開始位置
            leftWallTouch = FlgRayCheck(leftWallTouch, rayOri, rayDir, rayDist);
        }


        //==================================================
        // アニメーション処理
        //==================================================
        // 歩行アニメーション処理
        //if (moveForward != Vector3.zero)     // moveForwardがゼロでなければ

        //{
        //    anim.SetBool("running", true);  //runningをtrueにする。
        //}
        //else
        //{
        //    anim.SetBool("running", false);  //runningをfalseにする
        //}
        //// ジャンプアニメーション処理
        //if (Input.GetKeyDown(jumpKey) && groundTouch == true)
        //{
        //    anim.SetBool("jumping", true);  // jumpingをtrueにする
        //}
        //else
        //{
        //    anim.SetBool("jumping", false);  // junpingをfalseにする
        //}

        //==================================================
        // SEの設定
        //==================================================
        if (Input.GetKeyDown(jumpKey) && groundTouch == true)
        {
            // asou.Play();                    // ジャンプ効果音再生
        }

        //==================================================
        // パーティクル
        //==================================================
        // 歩行パーティクル
        //if (rb.velocity != Vector3.zero && groundTouch == true)             // 条件：rb.velocityがゼロでなく&&地上にいれば
        //{
        //    if (!psys.isEmitting)                                           // 条件：パーティクル再生中でなければ
        //    {
        //        psys.Play();                                                // パーティクル再生
        //    }
        //    else
        //    {
        //        if (psys.isEmitting)                                        // パーティクル再生中なら
        //        {
        //            psys.Stop();                                            // パーティクル停止する。
        //        }
        //    }
        //}

        //==================================================
        // プレイヤーを行動不能にする
        //==================================================
        if (Input.GetKeyDown(KeyCode.M))
        {
            stopTimer = 180;        // 180フレームのタイマー
            moveForward.x = 0.0f;   // 現在の移動度をリセットする
        }
        if (stopTimer > 0)
        {
            stopTimer--;    // タイマーを減らす
        }



    }
    //==================================================
    // 敵との衝突判定
    //==================================================
    private void OnCollisionEnter(Collision collision)
    {
        // ぶつかってきたオブジェクトが敵なら
        if (collision.gameObject.tag == "Enemy")
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Fall);
            UseKey = false;
            moveForward.x = 0.0f;
            moveForward.y = 0.0f;

        }
    }

    private bool FlgRayCheck(bool flg, Vector3 ori, Vector3 dir, float dist)
    {
        Ray ray = new Ray(
            this.transform.position +
            ori,     // レイの開始位置
            dir);    // レイの方向
        RaycastHit hit;         // 当たったと結果を代入する変数
        flg = false;    // とりあえず地面に触れてないことにする
        if (Physics.Raycast(ray, out hit, 10.0f))
        {
            // レイの開始位置と当たったオブジェクトの距離が一定以下なら
            if (hit.distance < dist)
            {
                flg = true; // 地面に接触している。
            }
            if (hit.collider.isTrigger == true)//すり抜けるオブジェクトならfalseにする
            {
                flg = false;
            }
        }
        return flg; // 現在のフラグの状態を返す
    }
    public void PlayFootstepSound01()
    {
        if (groundTouch == true)
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Footstep_1);
        }
    }

    public void PlayFootstepSound02()
    {
        if (groundTouch == true)
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Footstep_2);
        }
    }
}