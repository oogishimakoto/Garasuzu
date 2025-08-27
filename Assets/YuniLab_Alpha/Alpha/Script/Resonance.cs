using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resonance : MonoBehaviour
{
    [Header("生成心音プレハブ")]
    public GameObject SinObj;
    [Header("管理番号[0～31]")]
    [Range(0, 31)]
    public int HitNo = 0;
    Transform tr;
    CircleResize CR;
    private Animator animator;//アニメーター用

    [Header("待ち時間")]
    public float CoolTime = 0.0f;
    float DelteCoolTime = 0.0f;  //クールタイム

    [Header("スピーカーの音のサイズ")]
    public float SpeakerPower = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();//アニメーターコンポーネント取得
        tr = GetComponent<Transform>();
        // ビットはみ出し対策
        if (31 < HitNo)
        {
            HitNo = 31;
        }
        // 無限ループ対策
        if (CoolTime <= 0)
        {
            CoolTime = 1 / 60;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // クールタイム加算
        if (DelteCoolTime < CoolTime)
        {
            DelteCoolTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーでなければ
        if (other.gameObject.tag != "Player" && DelteCoolTime >= CoolTime)
        {
            CR = other.gameObject.GetComponent<CircleResize>();
            if (CR != null)
            {
                // ヒットした対象が同じTypeもしくはTypeNでなければ生成しない
                if (other.tag != SinObj.tag && !other.CompareTag("SWW"))
                {
                    return;
                }

               
                // 普通に生成モードは多分使わないと思うのでとりあえずコメントアウト
               /*
                if (HitNo < 0)
                {
                    animator.SetTrigger("Blow");
                    // 生成位置
                    Vector3 GenePos = new Vector3(tr.position.x, tr.position.y, tr.position.z);
                    // プレハブを指定位置に生成
                    GameObject Obj = Instantiate(SinObj, GenePos, Quaternion.identity);

                    CircleResize CRA = Obj.GetComponent<CircleResize>();
                    //CRA.SinLevel = 1;
                    CRA.SinSize = 6;
                    CRA.SinTime = 60;
                    
                    DelteCoolTime = 0.0f;
                    return;
                }
                */

                // 一度生成したものからは生成しないモード
                if (CR.HitTuning(HitNo))
                {
                    // 重複するので生成しない
              
                }
                else
                {
                   // animator.SetTrigger("Blow");
                    // 生成位置
                    Vector3 GenePos = new Vector3(tr.position.x, tr.position.y, tr.position.z);
                    // プレハブを指定位置に生成
                    GameObject Obj = Instantiate(SinObj, GenePos, Quaternion.identity);
                    // 音の設定
                    CircleResize CRA = Obj.GetComponent<CircleResize>();
                    CRA.SinSize = SpeakerPower;
                    CRA.SinTime = 60;
                   
                    //フラグセット
                    CRA.HitTuningFg = CR.HitTuningFg;
                    CRA.SetHitTuning(HitNo);

                    DelteCoolTime = 0.0f;

                    //////////SE追加に伴う変更点
                    // タグに応じてSEを再生
                    switch (SinObj.tag)
                    {
                        case "SWB":// 青
                            SoundManager.Instance.PlaySE(SESoundData.SE.SoundW_B);
                            break;

                        case "SWBl":// 黒    
                            SoundManager.Instance.PlaySE(SESoundData.SE.SoundW_Bl);
                            break;

                        case "SWG":// 緑
                            SoundManager.Instance.PlaySE(SESoundData.SE.SoundW_G);
                            break;

                        case "SWR":// 赤
                            SoundManager.Instance.PlaySE(SESoundData.SE.SoundW_R);
                            break;

                        case "SWW":// 白
                            SoundManager.Instance.PlaySE(SESoundData.SE.SoundW_W);
                            break;
                    }
                }
            }
        }
    }
}
