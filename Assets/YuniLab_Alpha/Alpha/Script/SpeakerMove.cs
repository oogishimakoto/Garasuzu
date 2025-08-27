using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerMove : Characte
{
    // Start is called before the first frame update

    [Header("自動で動く距離(X)")]
    public float HalfDisX;
    [Header("自動で動く距離(Y)")]
    public float HalfDisY;
    [Header("自動で動く距離(Z)")]
    public float HalfDisZ;

    [Header("1fでどれだけ移動するか(X)")]
    public float SpeedX;
    [Header("1fでどれだけ移動するか(Y)")]
    public float SpeedY;
    [Header("1fでどれだけ移動するか(Z)")]
    public float SpeedZ;

    private Vector3 DefaultPosition;
    private Animator animator;//アニメーター用
    [Header("右に動いてるかどうか")]
    private bool RightMove = true;
    private bool ForwardMove = true;
    [Header("所定の位置から正の方向に動くかどうか")]
    [SerializeField]
    bool Xswitch = true, Yswitch = true, Zswitch = true;
    [Header("向きを変更しないとき用")]
    public bool AngleF = true;

    void Start()
    {
        DefaultPosition = this.transform.position;
        animator = GetComponent<Animator>();//アニメーターコンポーネント取得
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        //////↓現在位置と所定の位置のif文
        if (DefaultPosition.x + HalfDisX < transform.position.x)
        {
            Xswitch = false;
        }
        else if (DefaultPosition.x - HalfDisX > transform.position.x)
        {
            Xswitch = true;
        }
        if (DefaultPosition.y + HalfDisY < transform.position.y)
        {
            Yswitch = false;
        }
        else if (DefaultPosition.y - HalfDisY > transform.position.y)
        {
            Yswitch = true;
        }
        if (DefaultPosition.z + HalfDisZ < transform.position.z)
        {
            Zswitch = false;
        }
        else if (DefaultPosition.z - HalfDisZ > transform.position.z)
        {
            Zswitch = true;
        }

        //////↑ここまで

        //////移動処理↓
        if (Xswitch == true)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x + SpeedX, transform.position.y, transform.position.z);
            animator.SetBool("Walk", true);
            RightMove = true;
        }
        else if (Xswitch == false)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x - SpeedX, transform.position.y, transform.position.z);
            RightMove = false;
        }
        if (Yswitch == true)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + SpeedY, transform.position.z);
        }
        else if (Yswitch == false)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - SpeedY, transform.position.z);
        }

        if (Zswitch == true)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + SpeedZ);
            ForwardMove = true;

        }
        else if (Zswitch == false)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - SpeedZ);
            ForwardMove = false;

        }

        if (AngleF == true)
        {
            //右を向いている時
            if (RightMove == true && SpeedX > 0.01f)
            {

                startAngle = this.transform.eulerAngles.y;  // 開始角度セット
                targetAngle = 90.0f + 0.01f;  // 目標角度をセット（角度がおかしくならないよう0.01fを加算）
                angleCount = 0;             // 回転状態を0に
            }
            //右を向いていない時
            else if (RightMove == false && SpeedX > 0.01f)
            {
                moveForward.x = -1; // 移動
                startAngle = this.transform.eulerAngles.y;  // 開始角度セット
                targetAngle = 270.0f;   // 目標角度をセット
                angleCount = 0;         // 回転状態を0に
            }

            //前を向いている時
            else if (ForwardMove == true && SpeedZ > 0.01f)
            {
                startAngle = this.transform.eulerAngles.y;  // 開始角度セット
                targetAngle = 360.0f;   // 目標角度をセット
                angleCount = 0;             // 回転状態を0に
            }
            //後ろを向いている
            else if (ForwardMove == false && SpeedZ > 0.01f)
            {
                moveForward.y = -1; // 移動
                startAngle = this.transform.eulerAngles.y;  // 開始角度セット
                targetAngle = 180.0f + 0.01f;  // 目標角度をセット（角度がおかしくならないよう0.01fを加算）
                angleCount = 0;         // 回転状態を0に
            }
            else
            {

                targetAngle = 180.0f;

            }
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
        }
    }
}

