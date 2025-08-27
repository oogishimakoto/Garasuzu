using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
//using UTJ;
using static UnityEngine.ParticleSystem;

public class heartBeat : MonoBehaviour
{
    //=================================================
    //�ϐ�
    //=================================================
    //public AnimationCurve curve;
    float startTime; //���܂������̎���

    GameObject player;

    Vector3 playerVec;

    GameObject Circle;                       //�S���͈͂̏���̉~�̑傫����
    beat circle;

    [Header("�������鉹�I�u�W�F�N�g")]
    public GameObject HeartPrefab;  //�v���C���[����o�����̌`

    [Header("�������{�^��")]
    public KeyCode MakeBeat = KeyCode.B;            // �L�[�R�[�h�̕ϐ�

    [Header("���p�x�ύX�֌W")]
    public KeyCode AngleChangeLeft = KeyCode.N;            // �L�[�R�[�h�̕ϐ�
    public KeyCode AngleChangeRight = KeyCode.M;            // �L�[�R�[�h�̕ϐ�

    public Quaternion nowAngle = Quaternion.Euler(0f, 0f, 0f);  //�p�x�ύX�p
    public Quaternion nowAngleCapsule = Quaternion.Euler(90f, 0f, 90f); //�p�x�ύX�p

    [Header("1��ŕς��p�x")]
    public float changeAngle = 90f;

    float angleZ = 0f;
    float CapsuleAngleZ = 90f;

    //=================================================
    //�p�����[�^�[�ϐ�
    //=================================================
    float FPS = 0.0f;

    [Header("���̃N�[���^�C��")]
    public float coolTime = 5.0f;   //�����l�́u5.0f�v
    float coolTimecount = 0.0f;

    //bool hlk = true;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerVer1.01");
        startTime = Time.time;
        coolTimecount = coolTime * Time.deltaTime;
        CapsuleAngleZ = 90f;
    }


    // Update is called once per frame
    void Update()
    {
        coolTimecount++;

        playerVec = player.GetComponent<Player>().moveForward;  //�v���C���[�̈ړ����擾����

        //�t���[�����[�g
        FPS += Time.deltaTime;
        
        // b�������΂Ƀv���n�u�𐶐�
        if (Input.GetKeyDown(MakeBeat) && coolTimecount >= coolTime)
        {
             // �����ʒu
             Vector3 pos = player.transform.position;
             // �v���n�u���w��ʒu�ɐ���
             GameObject Obj = Instantiate(HeartPrefab, new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z), Quaternion.identity);

             startTime = Time.time;

            coolTimecount = 0.0f;
        }

        //---------------------------------------------------------------
        //�p�x�ύX
        if (Input.GetKeyDown(AngleChangeLeft))
        {
            angleZ += changeAngle;

            if(angleZ >= 360 || angleZ <= 0)
            {
                angleZ = 0f;
            }

           
            CapsuleAngleZ += changeAngle;

            if (CapsuleAngleZ >= 360 || CapsuleAngleZ <= 0)
            {
                CapsuleAngleZ = 0f;
            }

            nowAngle = Quaternion.Euler(0f, 0f, angleZ);
            nowAngleCapsule = Quaternion.Euler(0f, 0f, CapsuleAngleZ);
        }

        if (Input.GetKeyDown(AngleChangeRight))
        {
            if (angleZ >= 360 || angleZ <= 0)
            {
                angleZ = 360f;
            }

            angleZ -= changeAngle;
           

            if (CapsuleAngleZ >= 360 || CapsuleAngleZ <= 0)
            {
                CapsuleAngleZ = 360f;
            }

            CapsuleAngleZ -= changeAngle;

            nowAngle = Quaternion.Euler(0f, 0f, angleZ);
            nowAngleCapsule = Quaternion.Euler(0f, 0f, CapsuleAngleZ);
        }

        //�ςȒl���������̕␳����
        if(changeAngle < 0f)
        {
            changeAngle = 0f;
        }
        if (changeAngle > 360f)
        {
            changeAngle = 360f;
        }

        //FPS���Z�b�g
        if (FPS >= 60 / 60.0f)
        {
            FPS %= 1;
        }

    }




}
