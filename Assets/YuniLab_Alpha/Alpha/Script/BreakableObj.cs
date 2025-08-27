using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class BreakableObj : MonoBehaviour
{
    [Header("対象のタグの種類")]
    [SerializeField]
    BeatType BlockType;
    [Header("選択されたプレハブに置き換える")]
    [SerializeField] private Transform brokenPrefab;// プレハブ
    [Header("角度は0でにしといてください")]
    [SerializeField] private float MinRotationZ = 0; // 0度~入力数値まで
    [Header("角度は0でにしといてください")]
    [SerializeField] private float MaxRotationZ = 0; // 入力値~359度まで
    [Header("最低の力")]
    public int MinPow = 10;
    [Header("最大の力")]
    public int MaxPow = 200;
    [Header("散らばる範囲の最低値")]
    public float MinScatter = 0.1f;
    [Header("散らばる範囲の最大値")]
    public float MaxScatter = 0.2f;
    [Header("復活時間（0入れると無効）")]
    public float CoolTime = 0;
    float DelteCoolTime = 0;

    MeshRenderer Mesh;
    BoxCollider Box;
    bool once = true;

    [Header("デフォルトマテリアル")]
    public Material Dmat;

    [Header("しゅわーんマテリアル")]
    public Material Nmat;

    float Syuwan;//使わんかった
    float AmCount;//現在のアムカウントの値

    //////////////////////////////////////////////追記部分↓(澤野)
    [Header("復活地点にプレイヤーが接触しているか")]
    public bool PlayerTriggerflg = false;
    string PlayerTag = "Player";//プレイヤーのタグを格納しておく
    bool Broken_flg = false;//falseで割れてない、trueで割れている
    [Header("待ち時間をいれる/秒(デフォルトは1)")]
    public float WaitTime;

    float warizan;//Syuwanを計算するのに使ってたけど使わんかった

    /// 追記：今村
    public bool ScoreCflg = true;//既にこのオブジェクトが一度破壊されてスコアが獲得できるか　true->未破壊
    ///

    /// //////////////////////////////////////////ここまで

    // Start is called before the first frame update
    enum BeatType
    {
        None,
        SWW,
        SWBl,
        SWR,
        SWB,
        SWG,
    }
    string BType;

    void Start()
    {
        Mesh = GetComponent<MeshRenderer>();
        Box = GetComponent<BoxCollider>();

        Syuwan = 1 / CoolTime;
        warizan = 60 * CoolTime;
        Syuwan=Syuwan/warizan;
        switch (BlockType)
        {
            case BeatType.SWW:
                BType = "SWW";
                break;
            case BeatType.SWBl:
                BType = "SWBl";
                break;
            case BeatType.SWR:
                BType = "SWR";
                break;
            case BeatType.SWB:
                BType = "SWB";
                break;
            case BeatType.SWG:
                BType = "SWG";
                break;

        }
        if (WaitTime == 0.0)//入力されていなければ初期値を入れる
        {
            WaitTime = 1.0f;
        }
    }
    void Update()
    {
        // クールタイム加算
        if (DelteCoolTime < CoolTime)
        {
            DelteCoolTime += Time.deltaTime;
        }

        if(PlayerTriggerflg==false&& AmCount > Syuwan)
        {
            AmCount = 1-DelteCoolTime / CoolTime;
            GetComponent<MeshRenderer>().material.SetFloat("_Amcount", AmCount);
            //AmCount = Syuwan;
        }
        if(AmCount< Syuwan)
        {
            GetComponent<MeshRenderer>().material = Dmat;
            Box.isTrigger = false;
            Broken_flg = false;
            //gameObject.AddComponent<BoxCollider>();
            //this.gameObject.SetActive(true);
            once = true;
        }

        if (PlayerTriggerflg == true && DelteCoolTime >= CoolTime - WaitTime)//復活地点がプレイヤーと重なっていると復活を待つ
        {
            DelteCoolTime = CoolTime - WaitTime;
        }
        else if (DelteCoolTime >= CoolTime && !once)
        {
            Mesh.enabled = true;
            Box.isTrigger = false;
            Broken_flg = false;
            //gameObject.AddComponent<BoxCollider>();
            //this.gameObject.SetActive(true);
            once = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(BType))
        {
            /////追記：今村
            ScoreItem scoreItem;
            GameObject obj = GameObject.Find("StageUI/score");//オブジェクト名"Text (Legacy)"から探してくる
                                                            // Debug.log(obj);

            scoreItem = obj.GetComponent<ScoreItem>();//ScoreItemの中身を見る
            if ((scoreItem.score < 100000000) && (ScoreCflg == true))
            {
                scoreItem.score += 100;//スコアを加算
                if (scoreItem.score >= 100000000)
                {
                    scoreItem.score = 99999999;
                }
                ScoreCflg = false;
            }

            if (Broken_flg == false)
            {
                Transform brokenTransform = Instantiate(brokenPrefab, transform.position, transform.rotation);             //  自分自身の位置と向きと回転
                brokenTransform.localScale = transform.localScale * 20;                                                   //  自身の大きさも合わせる
                foreach (MeshCollider meshCollider in brokenTransform.GetComponentsInChildren<MeshCollider>())                      //  子供のRigidbodyを取得
                {

                    meshCollider.enabled = false;                          //  子供10のRigidbodyの力、場所、範囲を設定する。
                }

                foreach (Rigidbody rigidbody in brokenTransform.GetComponentsInChildren<Rigidbody>())                      //  子供のRigidbodyを取得
                {

                    rigidbody.AddExplosionForce(Random.Range(MinPow, MaxPow), transform.position + Vector3.up * Random.Range(MinScatter, MaxScatter), 5f);                          //  子供10のRigidbodyの力、場所、範囲を設定する。
                }
                // クールタイムが設定されていたら復活する
                if (CoolTime != 0)
                {
                    //Mesh.enabled = false;
                    Box.isTrigger = true;
                    Broken_flg = true;
                    //Destroy(GetComponent<BoxCollider>());
                    //this.gameObject.SetActive(false);


                    once = false;
                    DelteCoolTime = 0.0f;
                    GetComponent<MeshRenderer>().material = Nmat;
                    GetComponent<MeshRenderer>().material.SetFloat("_Amcount",1.0f);
                    AmCount = 1.0f;
                    //Debug.Log("とおてるよ");

                    //////////SE追加に伴う変更点
                    // 1～3の乱数に応じてSEを再生
                    int rand = Random.Range(1, 4);
                    switch (rand)
                    {
                        case 1:
                            SoundManager.Instance.PlaySE(SESoundData.SE.GlassBrake_1);
                            break;

                        case 2:
                            SoundManager.Instance.PlaySE(SESoundData.SE.GlassBrake_2);
                            break;

                        case 3:
                            SoundManager.Instance.PlaySE(SESoundData.SE.GlassBrake_3);
                            break;
                    }
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
        if (other.gameObject.CompareTag(PlayerTag))
        {
            PlayerTriggerflg = true;
        }
    }
    private void OnTriggerExit(Collider other)//プレイヤーが出たら復活準備を再開する
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            PlayerTriggerflg = false;
        }
    }
}