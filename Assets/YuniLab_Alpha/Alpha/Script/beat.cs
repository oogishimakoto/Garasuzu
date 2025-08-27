using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class beat : MonoBehaviour
{

    float startTime;    //�������ꂽ����

    public enum OtherColor
    {
        White,
        Red,
        Blue,
        Black,
        Green
    }

    [Header("���̐F�ϊ��p(������Ȃ���)")]
    public OtherColor BlackColor = OtherColor.White;
    public OtherColor RedColor = OtherColor.White;
    public OtherColor BlueColor = OtherColor.White;
    public OtherColor GreenColor = OtherColor.White;

    [Header("���p�����[�^�[")]
    public float SinSize = 7.0f;    //�����l�́u7.0f�v
    public float SinTime = 60.0f;   //�����l�́u60.0f�v

    [Header("���A�j���[�V�������x")]
    public AnimationCurve curve;        //�A�j���[�V�������x
    float ScaleSize = 0.0f;                 // �~�̊g��k��

    [Header("�������鉹�I�u�W�F�N�g")]
    public GameObject CubeHeartPrefab;          //cube��tag�Ɠ����������ɐ������鉹������
    public GameObject SphereHeartPrefab;        //sphere��tag�Ɠ����������ɐ������鉹������
    public GameObject CapsuleHeartPrefab;       //capsule��tag�Ɠ����������ɐ������鉹������
    public GameObject TriangleHeartPrefab;      //triangle��tag�Ɠ����������ɐ������鉹������

    string cube;
    string sphere;
    string capsule; 
    string triangle;

    GameObject Heartbeat;
    heartBeat heartbeat;

    private void Awake()
    {
        //�t���[�����[�g�Œ�
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Color.white);
        startTime = Time.time;

        Heartbeat = GameObject.Find("heart");
        heartbeat = Heartbeat.GetComponent<heartBeat>(); //�t���Ă���X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
        BeatSize();
    }

    void OnTriggerEnter(Collider other)//�G���v���C���[�̋C�z�I�Ȃ��̂ɓ����������ɏ�ԑJ�ڂ���֐�
    {
        if (other.gameObject.CompareTag("cube") && other.gameObject.name != cube)
        {
            BlueColor = OtherColor.Blue;
            // �v���n�u���w��ʒu�ɐ���
            GameObject makeCube = Instantiate(CubeHeartPrefab, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), heartbeat.nowAngle);
            otherBeat mCube = makeCube.GetComponent<otherBeat>();
            //mCube.otherColor = otherBeat.OtherColor.Blue;

            cube = other.gameObject.name;
        }

        if (other.gameObject.CompareTag("sphere") && other.gameObject.name != sphere)
        {
            RedColor = OtherColor.Red;

            // �v���n�u���w��ʒu�ɐ���
            GameObject makeSphere = Instantiate(SphereHeartPrefab, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), heartbeat.nowAngle);
            otherBeat mSphere = makeSphere.GetComponent<otherBeat>();
            //mSphere.otherColor = otherBeat.OtherColor.Red;

            sphere = other.gameObject.name;
        }

        if (other.gameObject.CompareTag("capsule") && other.gameObject.name != capsule)
        {
            BlackColor = OtherColor.Black;

            // �v���n�u���w��ʒu�ɐ���
            GameObject makeCapsule = Instantiate(CapsuleHeartPrefab, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), heartbeat.nowAngleCapsule);
            otherBeat mCapsule = makeCapsule.GetComponent<otherBeat>();

            capsule = other.gameObject.name;

        }

        if (other.gameObject.CompareTag("triangle") && other.gameObject.name != triangle)
        {
            GreenColor = OtherColor.Green;

            // �v���n�u���w��ʒu�ɐ���
            GameObject makeTriangle = Instantiate(TriangleHeartPrefab, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), heartbeat.nowAngle);
            otherBeat mCTriangle = makeTriangle.GetComponent<otherBeat>();
            //mCTriangle.otherColor = otherBeat.OtherColor.Green;

            triangle = other.gameObject.name;

        }

    }

    //���̑傫�����g�傷��֐�
    private void BeatSize()
    {
        ScaleSize = SinSize * curve.Evaluate((Time.time - startTime) / (SinTime / 60.0f));
       
        //�~���ő�̑傫���ɂȂ��������
        if (ScaleSize >= SinSize)
        {
            Destroy(this.gameObject);
        }

        this.transform.localScale = new Vector3(ScaleSize, ScaleSize, ScaleSize);
    }
}
