using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class BreakableObj_Title : MonoBehaviour
{
    [Header("�Ώۂ̃^�O�̎��")]
    [SerializeField]
    BeatType BlockType;
    [Header("�I�����ꂽ�v���n�u�ɒu��������")]
    [SerializeField] private Transform brokenPrefab;// �v���n�u
    [Header("�p�x��0�łɂ��Ƃ��Ă�������")]
    [SerializeField] private float MinRotationZ = 0; // 0�x~���͐��l�܂�
    [Header("�p�x��0�łɂ��Ƃ��Ă�������")]
    [SerializeField] private float MaxRotationZ = 0; // ���͒l~359�x�܂�
    [Header("�Œ�̗�")]
    public int MinPow = 10;
    [Header("�ő�̗�")]
    public int MaxPow = 200;
    [Header("�U��΂�͈͂̍Œ�l")]
    public float MinScatter = 0.1f;
    [Header("�U��΂�͈͂̍ő�l")]
    public float MaxScatter = 0.2f;
    [Header("�������ԁi0�����Ɩ����j")]
    public float CoolTime = 0;
    float DelteCoolTime = 0;

    AudioSource AS;
    public AudioClip AC;

    MeshRenderer Mesh;
    BoxCollider Box;
    bool once = true;

    [Header("�f�t�H���g�}�e���A��")]
    public Material Dmat;

    [Header("�����[��}�e���A��")]
    public Material Nmat;

    [Header("�ϊ�����ۂ̃I�u�W�F�N�g�̃T�C�Y(�{)")]
    [SerializeField]
    float x, y, z;
    //float Syuwan;//�g��񂩂���
    //float AmCount;//���݂̃A���J�E���g�̒l

    //////////////////////////////////////////////�ǋL������(�V��)
    [Header("�����n�_�Ƀv���C���[���ڐG���Ă��邩")]
    public bool PlayerTriggerflg = false;
    string PlayerTag = "Player";//�v���C���[�̃^�O���i�[���Ă���
    bool Broken_flg = false;//false�Ŋ���ĂȂ��Atrue�Ŋ���Ă���
    [Header("�҂����Ԃ������/�b(�f�t�H���g��1)")]
    public float WaitTime;

    float warizan;//Syuwan���v�Z����̂Ɏg���Ă����ǎg��񂩂���

    /// //////////////////////////////////////////�����܂�

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

        //Syuwan = 1 / CoolTime;
        //warizan = 60 * CoolTime;
        //Syuwan=Syuwan/warizan;
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
        if (WaitTime == 0.0)//���͂���Ă��Ȃ���Ώ����l������
        {
            WaitTime = 1.0f;
        }
        AS = GetComponent<AudioSource>();
    }
    void Update()
    {
        // �N�[���^�C�����Z
        if (DelteCoolTime < CoolTime)
        {
            DelteCoolTime += Time.deltaTime;
        }

        //if(PlayerTriggerflg==false&& AmCount > Syuwan)
        //{
        //    AmCount = 1-DelteCoolTime / CoolTime;
        //    GetComponent<MeshRenderer>().material.SetFloat("_Amcount", AmCount);
        //    //AmCount = Syuwan;
        //}
        //if (AmCount < Syuwan)
        //{
        //    GetComponent<MeshRenderer>().material = Dmat;
        //    Box.isTrigger = false;
        //    Broken_flg = false;
        //    //gameObject.AddComponent<BoxCollider>();
        //    //this.gameObject.SetActive(true);
        //    once = true;
        //}

        if (PlayerTriggerflg == true && DelteCoolTime >= CoolTime - WaitTime)//�����n�_���v���C���[�Əd�Ȃ��Ă���ƕ�����҂�
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
            if (Broken_flg == false)
            {
                
                Transform brokenTransform = Instantiate(brokenPrefab, transform.position, transform.rotation);             //  �������g�̈ʒu�ƌ����Ɖ�]
                brokenTransform.localScale = new Vector3(transform.localScale.x*x,transform.localScale.y*y,transform.localScale.z*z);        //  ���g�̑傫�������킹��
                Vector3 rotation = transform.rotation.eulerAngles; // ���݂̉�]�p�x���擾
                rotation.x = 90f; // x���̉�]�p�x��-90�x�ɐݒ�
                brokenTransform.rotation = Quaternion.Euler(rotation); // ��]��K�p
                if (AC != null)
                {
                    AS.PlayOneShot(AC);
                    Debug.Log("�Ƃ���������");
                }

                foreach (MeshCollider meshCollider in brokenTransform.GetComponentsInChildren<MeshCollider>())                      //  �q����Rigidbody���擾
                {

                    meshCollider.enabled = false;                          //  �q��10��Rigidbody�̗́A�ꏊ�A�͈͂�ݒ肷��B
                }

                foreach (Rigidbody rigidbody in brokenTransform.GetComponentsInChildren<Rigidbody>())                      //  �q����Rigidbody���擾
                {
                    Debug.Log("�Ƃ�����");//  �q��10��Rigidbody�̗́A�ꏊ�A�͈͂�ݒ肷��B

                    rigidbody.AddExplosionForce(Random.Range(MinPow, MaxPow), new Vector3(transform.position.x,transform.position.y,transform.position.z), 10f);
                }
                // �N�[���^�C�����ݒ肳��Ă����畜������
                //if (CoolTime != 0)
                //{
                //    //Mesh.enabled = false;
                //    Box.isTrigger = true;
                //    Broken_flg = true;
                //    //Destroy(GetComponent<BoxCollider>());
                //    //this.gameObject.SetActive(false);


                //    once = false;
                //    DelteCoolTime = 0.0f;
                //    GetComponent<MeshRenderer>().material = Nmat;
                //    GetComponent<MeshRenderer>().material.SetFloat("_Amcount",1.0f);
                //    AmCount = 1.0f;
                //    //Debug.Log("�Ƃ��Ă��");
                //}
               
                {
                    Destroy(this.gameObject);
                    Debug.Log("���܂�����");
                }
            }
        }
        if (other.gameObject.CompareTag(PlayerTag))
        {
            PlayerTriggerflg = true;
        }
    }
    private void OnTriggerExit(Collider other)//�v���C���[���o���畜���������ĊJ����
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            PlayerTriggerflg = false;
        }
    }
}