using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static beat;

public class otherBeat : MonoBehaviour
{

    float startTime;

    GameObject main;
    beat mainBeat;

    [Header("音関係のパラメーター")]
    public float SinSize2 = 7.0f;
    public float SinTime2 = 60.0f;

    [Header("アニメーション速度")]
    public AnimationCurve curve;        //アニメーション速度
    float CubeScaleSize = 0.0f;                 // 円の拡大縮小

    private void Awake()
    {
        //フレームレート固定
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.Find("beat(Clone)");
        if (main != null)
        {
            mainBeat = main.GetComponent<beat>(); //付いているスクリプトを取得
            if (mainBeat.BlueColor == beat.OtherColor.Blue)
            {
                //Debug.Log("青色だよ");
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Color.blue);
                mainBeat.BlueColor = beat.OtherColor.White;
            }

            if (mainBeat.RedColor == beat.OtherColor.Red)
            {
                //Debug.Log("赤色だよ");
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Color.red);
                mainBeat.RedColor = beat.OtherColor.White;
            }

            if (mainBeat.BlackColor == beat.OtherColor.Black)
            {
                //Debug.Log("黒色だよ");
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Color.black);
                mainBeat.BlackColor = beat.OtherColor.White;
            }

            if (mainBeat.GreenColor == beat.OtherColor.Green)
            {
                //Debug.Log("緑色だよ");
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Color.green);
                mainBeat.GreenColor = beat.OtherColor.White;
            }
        }       


        startTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        CubeScaleSize = SinSize2 * curve.Evaluate((Time.time - startTime) / (SinTime2 / 60.0f));

        //円が最大の大きさになったら消す
        if (CubeScaleSize >= SinSize2)
        {
            Destroy(this.gameObject);
        }

        transform.localScale = new Vector3(CubeScaleSize, CubeScaleSize, CubeScaleSize);

        
    }

}
