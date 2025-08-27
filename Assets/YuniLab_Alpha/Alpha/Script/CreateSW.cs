using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using static UnityEngine.ParticleSystem;
using UnityEngine.InputSystem;

public class CreateSW : MonoBehaviour
{
    //=================================================
    //�ϐ�
    //=================================================

    Rigidbody rb;
    Transform tr;
    float FPS = 0.0f;
    private Animator animator;//�A�j���[�^�[�p

    // �v���n�u�i�[�p
    [Header("���v���n�u")]
    public GameObject HeartPrefab;
    [Header("�����o���L�[�R�[�h")]
    public KeyCode key;

    private bool Death = false;
    public ParticleSystem RingBell;

    [Header("�|�[�Y�̃X�N���v�g�������Ă�I�u�W�F�N�g")]
    public GameObject Pauseobj;

    Pause Ppause;
    bool beforpause = false;

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

    private PlayerInput PI;
    private InputActionMap BeatSet;
    private InputAction _beat;

    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody>();
        RingBell = this.GetComponentInChildren<ParticleSystem>();
        tr = this.GetComponent<Transform>();
        animator = GetComponent<Animator>();//�A�j���[�^�[�R���|�[�l���g�擾

        /////�V��ǋL
        PI = GetComponent<PlayerInput>();
        BeatSet = PI.currentActionMap;
        _beat = BeatSet["Beat"];
        Ppause = Pauseobj.GetComponent<Pause>();
        if (Ppause == null) { Debug.LogError("�Ȃ��ł���"); }
    }


    // Update is called once per frame
    void Update()
    {
        // �t���[�����[�g
        //FPS += Time.deltaTime;
        /////�V��ǋL
        bool beatflg = _beat.triggered;

        // �N�[���^�C�����Z
        if (DelteCoolTime < CoolTime)
        {
            DelteCoolTime += Time.deltaTime;
        }


        if (/*(Input.GetKeyDown(key) && DelteCoolTime >= CoolTime && Death == false )|| */((beatflg == true && beforpause == false && DelteCoolTime >= CoolTime && Death == false)) )
        {
            RingBell.Play();
            animator.SetTrigger("SoundMake");
            // �����ʒu
            Vector3 GenePos = new Vector3(tr.position.x, tr.position.y + 0.5f, tr.position.z);
            // �v���n�u���w��ʒu�ɐ���
            GameObject Obj = Instantiate(HeartPrefab, GenePos, Quaternion.identity);
            //Obj.GetComponent<CircleResize_Aya>().SinLevel = 1;
            Obj.GetComponent<CircleResize>().SinSize = Size1;
            Obj.GetComponent<CircleResize>().SinTime = Time1;

            DelteCoolTime = 0.0f;

            //////////SE�ǉ��ɔ����ύX�_
            SoundManager.Instance.PlaySE(SESoundData.SE.SoundW_W);
        }




        //FPS���Z�b�g
        //if (FPS >= 60 / 60.0f)
        //{
        //    FPS %= 1;
        //}
        beforpause = Ppause.pauseflg;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // �Ԃ����Ă����I�u�W�F�N�g���G�Ȃ�
        if (collision.gameObject.tag == "Enemy")
        {

            Death = true;


        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // �Ԃ����Ă����I�u�W�F�N�g���G�Ȃ�
        if (collision.gameObject.tag == "Enemy")
        {

            Death = false;


        }
    }
}
