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

    [Header("���֌W�̃p�����[�^�[")]
    public float SinSize2 = 7.0f;
    public float SinTime2 = 60.0f;

    [Header("�A�j���[�V�������x")]
    public AnimationCurve curve;        //�A�j���[�V�������x
    float CubeScaleSize = 0.0f;                 // �~�̊g��k��

    private void Awake()
    {
        //�t���[�����[�g�Œ�
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.Find("beat(Clone)");
        if (main != null)
        {
            mainBeat = main.GetComponent<beat>(); //�t���Ă���X�N���v�g���擾
            if (mainBeat.BlueColor == beat.OtherColor.Blue)
            {
                //Debug.Log("�F����");
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Color.blue);
                mainBeat.BlueColor = beat.OtherColor.White;
            }

            if (mainBeat.RedColor == beat.OtherColor.Red)
            {
                //Debug.Log("�ԐF����");
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Color.red);
                mainBeat.RedColor = beat.OtherColor.White;
            }

            if (mainBeat.BlackColor == beat.OtherColor.Black)
            {
                //Debug.Log("���F����");
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Color.black);
                mainBeat.BlackColor = beat.OtherColor.White;
            }

            if (mainBeat.GreenColor == beat.OtherColor.Green)
            {
                //Debug.Log("�ΐF����");
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

        //�~���ő�̑傫���ɂȂ��������
        if (CubeScaleSize >= SinSize2)
        {
            Destroy(this.gameObject);
        }

        transform.localScale = new Vector3(CubeScaleSize, CubeScaleSize, CubeScaleSize);

        
    }

}
