using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using static UnityEngine.ParticleSystem;

public class CreateSW_SawanoSpecial : MonoBehaviour
{
    //=================================================
    //�ϐ�
    //=================================================

    Rigidbody rb;
    Transform tr;
    float FPS = 0.0f;


    // �v���n�u�i�[�p
    [Header("���v���n�u")]
    public GameObject HeartPrefab;
    [Header("�����o���L�[�R�[�h")]
    public KeyCode key;

    [Header("�ǂ̃^�C�~���O�ŏo����")]
    public float startTime; 
    private bool flg=false;

    //=================================================
    //�p�����[�^�[�ϐ�
    //=================================================

    //[Header("�S��臒l")]
    //public int Sinlv1 = 5;
    //public int Sinlv2 = 15;
    //public int Sinlv3 = 25;
    //public int SinMax = 40;

    [Header("���T�C�Y")]
    public float Size1 = 4.0f;
    //public float Size2 = 6.0f;
    //public float Size3 = 8.0f;

    [Header("������")]
    public float Time1 = 60.0f;
    //public float Time2 = 120.0f;
    //public float Time3 = 180.0f;

    //[Header("�S�������Ԋu")]
    //public int Create1 = 60;
    //public int Create2 = 55;
    //public int Create3 = 50;
    //float CreateNowTime = 0.0f;     // �o�ߎ���
    //float CreateDeltaNowTime = 0.0f;     // �o�ߎ��Ԃ̍���

    //float MaxSinonTime = 0.0f;      // ���؂�p�o�ߎ���
    [Header("�N�[���^�C��")]
    public float CoolTime = 0.0f;
    float DelteCoolTime;  //�N�[���^�C��


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        tr = this.GetComponent<Transform>();

    }


    // Update is called once per frame
    void Update()
    {
        // �t���[�����[�g
        //FPS += Time.deltaTime;

        // �N�[���^�C�����Z
        if (DelteCoolTime < startTime)
        {
            DelteCoolTime += Time.deltaTime;
        }
        if (flg == false && startTime < DelteCoolTime)
        {
            // �����ʒu
            Vector3 GenePos = new Vector3(tr.position.x, tr.position.y + 0.5f, tr.position.z);
            // �v���n�u���w��ʒu�ɐ���
            GameObject Obj = Instantiate(HeartPrefab, GenePos, Quaternion.identity);
            //Obj.GetComponent<CircleResize_Aya>().SinLevel = 1;
            Obj.GetComponent<CircleResize_SawanoSpecial>().SinSize = Size1;
            Obj.GetComponent<CircleResize_SawanoSpecial>().SinTime = Time1;

            flg= true;

        }

        if (Input.GetKeyDown(key) && DelteCoolTime >= CoolTime)
        {
            DelteCoolTime = 0.0f;

        }

        //FPS���Z�b�g
        //if (FPS >= 60 / 60.0f)
        //{
        //    FPS %= 1;
        //}

    }
}
