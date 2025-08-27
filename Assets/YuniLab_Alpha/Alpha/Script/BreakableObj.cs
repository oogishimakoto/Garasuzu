using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class BreakableObj : MonoBehaviour
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

    MeshRenderer Mesh;
    BoxCollider Box;
    bool once = true;

    [Header("�f�t�H���g�}�e���A��")]
    public Material Dmat;

    [Header("�����[��}�e���A��")]
    public Material Nmat;

    float Syuwan;//�g��񂩂���
    float AmCount;//���݂̃A���J�E���g�̒l

    //////////////////////////////////////////////�ǋL������(�V��)
    [Header("�����n�_�Ƀv���C���[���ڐG���Ă��邩")]
    public bool PlayerTriggerflg = false;
    string PlayerTag = "Player";//�v���C���[�̃^�O���i�[���Ă���
    bool Broken_flg = false;//false�Ŋ���ĂȂ��Atrue�Ŋ���Ă���
    [Header("�҂����Ԃ������/�b(�f�t�H���g��1)")]
    public float WaitTime;

    float warizan;//Syuwan���v�Z����̂Ɏg���Ă����ǎg��񂩂���

    /// �ǋL�F����
    public bool ScoreCflg = true;//���ɂ��̃I�u�W�F�N�g����x�j�󂳂�ăX�R�A���l���ł��邩�@true->���j��
    ///

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
        if (WaitTime == 0.0)//���͂���Ă��Ȃ���Ώ����l������
        {
            WaitTime = 1.0f;
        }
    }
    void Update()
    {
        // �N�[���^�C�����Z
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
            /////�ǋL�F����
            ScoreItem scoreItem;
            GameObject obj = GameObject.Find("StageUI/score");//�I�u�W�F�N�g��"Text (Legacy)"����T���Ă���
                                                            // Debug.log(obj);

            scoreItem = obj.GetComponent<ScoreItem>();//ScoreItem�̒��g������
            if ((scoreItem.score < 100000000) && (ScoreCflg == true))
            {
                scoreItem.score += 100;//�X�R�A�����Z
                if (scoreItem.score >= 100000000)
                {
                    scoreItem.score = 99999999;
                }
                ScoreCflg = false;
            }

            if (Broken_flg == false)
            {
                Transform brokenTransform = Instantiate(brokenPrefab, transform.position, transform.rotation);             //  �������g�̈ʒu�ƌ����Ɖ�]
                brokenTransform.localScale = transform.localScale * 20;                                                   //  ���g�̑傫�������킹��
                foreach (MeshCollider meshCollider in brokenTransform.GetComponentsInChildren<MeshCollider>())                      //  �q����Rigidbody���擾
                {

                    meshCollider.enabled = false;                          //  �q��10��Rigidbody�̗́A�ꏊ�A�͈͂�ݒ肷��B
                }

                foreach (Rigidbody rigidbody in brokenTransform.GetComponentsInChildren<Rigidbody>())                      //  �q����Rigidbody���擾
                {

                    rigidbody.AddExplosionForce(Random.Range(MinPow, MaxPow), transform.position + Vector3.up * Random.Range(MinScatter, MaxScatter), 5f);                          //  �q��10��Rigidbody�̗́A�ꏊ�A�͈͂�ݒ肷��B
                }
                // �N�[���^�C�����ݒ肳��Ă����畜������
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
                    //Debug.Log("�Ƃ��Ă��");

                    //////////SE�ǉ��ɔ����ύX�_
                    // 1�`3�̗����ɉ�����SE���Đ�
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
    private void OnTriggerExit(Collider other)//�v���C���[���o���畜���������ĊJ����
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            PlayerTriggerflg = false;
        }
    }
}