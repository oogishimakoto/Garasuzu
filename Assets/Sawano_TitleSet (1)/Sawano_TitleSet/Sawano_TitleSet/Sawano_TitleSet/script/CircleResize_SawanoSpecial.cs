using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using static UnityEngine.ParticleSystem;

public class CircleResize_SawanoSpecial : MonoBehaviour
{
    //=================================================
    //変数
    //=================================================
    float ScaleSize = 0.0f;                 // 円の拡大縮小
    public AnimationCurve curve;        //アニメーション速度
    float FPS = 0.0f;   //FPS

    float startTime = 0;

    //public int SinLevel = 0;
    public float SinSize = 2000.0f;
    public float SinTime = 20000.0f;

    [Header("ヒット管理用変数")]
    public int HitTuningFg = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 生成時間を記憶
        startTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        // フレームレート
        //FPS += Time.deltaTime;

        // 心音を広げる処理
        //gameObject.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Color.white);
        ScaleSize = SinSize * curve.Evaluate((Time.time - startTime) / (SinTime / 60.0f));


        //円が最大の大きさになったら消す
        if (ScaleSize >= SinSize)
        {
            //Debug.Log("削除");
            Destroy(this.gameObject);
        }

        //FPSリセット
        //if (FPS >= 60 / 60.0f)
        //{
            //FPS %= 1;
        //}

        this.transform.localScale = new Vector3(ScaleSize, ScaleSize, ScaleSize);

    }

    public bool HitTuning(int _value)
    {
        // 現状TypeNは前のやつとか関係ないのでスルー
        //if (LayerMask.LayerToName(gameObject.layer) == "TypeN_Oto") return false; 

        // ビット演算用に数値を補正する
        _value = 1 << _value;

        // 規定の番号にフラグが立っているかチェック
        if ((HitTuningFg & _value) == _value)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void SetHitTuning(int _value)
    {
        // ビット演算用に数値を補正する
        _value = 1 << _value;

        // 数値を入れる
        HitTuningFg |= _value;
    }


}
