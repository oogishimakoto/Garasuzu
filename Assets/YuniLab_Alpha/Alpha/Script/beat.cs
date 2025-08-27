using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class beat : MonoBehaviour
{

    float startTime;    //生成された時間

    public enum OtherColor
    {
        White,
        Red,
        Blue,
        Black,
        Green
    }

    [Header("音の色変換用(いじらないで)")]
    public OtherColor BlackColor = OtherColor.White;
    public OtherColor RedColor = OtherColor.White;
    public OtherColor BlueColor = OtherColor.White;
    public OtherColor GreenColor = OtherColor.White;

    [Header("音パラメーター")]
    public float SinSize = 7.0f;    //初期値は「7.0f」
    public float SinTime = 60.0f;   //初期値は「60.0f」

    [Header("音アニメーション速度")]
    public AnimationCurve curve;        //アニメーション速度
    float ScaleSize = 0.0f;                 // 円の拡大縮小

    [Header("生成する音オブジェクト")]
    public GameObject CubeHeartPrefab;          //cubeのtagと当たった時に生成する音を入れる
    public GameObject SphereHeartPrefab;        //sphereのtagと当たった時に生成する音を入れる
    public GameObject CapsuleHeartPrefab;       //capsuleのtagと当たった時に生成する音を入れる
    public GameObject TriangleHeartPrefab;      //triangleのtagと当たった時に生成する音を入れる

    string cube;
    string sphere;
    string capsule; 
    string triangle;

    GameObject Heartbeat;
    heartBeat heartbeat;

    private void Awake()
    {
        //フレームレート固定
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Color.white);
        startTime = Time.time;

        Heartbeat = GameObject.Find("heart");
        heartbeat = Heartbeat.GetComponent<heartBeat>(); //付いているスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
        BeatSize();
    }

    void OnTriggerEnter(Collider other)//敵がプレイヤーの気配的なものに当たった時に状態遷移する関数
    {
        if (other.gameObject.CompareTag("cube") && other.gameObject.name != cube)
        {
            BlueColor = OtherColor.Blue;
            // プレハブを指定位置に生成
            GameObject makeCube = Instantiate(CubeHeartPrefab, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), heartbeat.nowAngle);
            otherBeat mCube = makeCube.GetComponent<otherBeat>();
            //mCube.otherColor = otherBeat.OtherColor.Blue;

            cube = other.gameObject.name;
        }

        if (other.gameObject.CompareTag("sphere") && other.gameObject.name != sphere)
        {
            RedColor = OtherColor.Red;

            // プレハブを指定位置に生成
            GameObject makeSphere = Instantiate(SphereHeartPrefab, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), heartbeat.nowAngle);
            otherBeat mSphere = makeSphere.GetComponent<otherBeat>();
            //mSphere.otherColor = otherBeat.OtherColor.Red;

            sphere = other.gameObject.name;
        }

        if (other.gameObject.CompareTag("capsule") && other.gameObject.name != capsule)
        {
            BlackColor = OtherColor.Black;

            // プレハブを指定位置に生成
            GameObject makeCapsule = Instantiate(CapsuleHeartPrefab, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), heartbeat.nowAngleCapsule);
            otherBeat mCapsule = makeCapsule.GetComponent<otherBeat>();

            capsule = other.gameObject.name;

        }

        if (other.gameObject.CompareTag("triangle") && other.gameObject.name != triangle)
        {
            GreenColor = OtherColor.Green;

            // プレハブを指定位置に生成
            GameObject makeTriangle = Instantiate(TriangleHeartPrefab, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), heartbeat.nowAngle);
            otherBeat mCTriangle = makeTriangle.GetComponent<otherBeat>();
            //mCTriangle.otherColor = otherBeat.OtherColor.Green;

            triangle = other.gameObject.name;

        }

    }

    //音の大きさを拡大する関数
    private void BeatSize()
    {
        ScaleSize = SinSize * curve.Evaluate((Time.time - startTime) / (SinTime / 60.0f));
       
        //円が最大の大きさになったら消す
        if (ScaleSize >= SinSize)
        {
            Destroy(this.gameObject);
        }

        this.transform.localScale = new Vector3(ScaleSize, ScaleSize, ScaleSize);
    }
}
