using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resonance : MonoBehaviour
{
    [Header("�����S���v���n�u")]
    public GameObject SinObj;
    [Header("�Ǘ��ԍ�[0�`31]")]
    [Range(0, 31)]
    public int HitNo = 0;
    Transform tr;
    CircleResize CR;
    private Animator animator;//�A�j���[�^�[�p

    [Header("�҂�����")]
    public float CoolTime = 0.0f;
    float DelteCoolTime = 0.0f;  //�N�[���^�C��

    [Header("�X�s�[�J�[�̉��̃T�C�Y")]
    public float SpeakerPower = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();//�A�j���[�^�[�R���|�[�l���g�擾
        tr = GetComponent<Transform>();
        // �r�b�g�͂ݏo���΍�
        if (31 < HitNo)
        {
            HitNo = 31;
        }
        // �������[�v�΍�
        if (CoolTime <= 0)
        {
            CoolTime = 1 / 60;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �N�[���^�C�����Z
        if (DelteCoolTime < CoolTime)
        {
            DelteCoolTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �v���C���[�łȂ����
        if (other.gameObject.tag != "Player" && DelteCoolTime >= CoolTime)
        {
            CR = other.gameObject.GetComponent<CircleResize>();
            if (CR != null)
            {
                // �q�b�g�����Ώۂ�����Type��������TypeN�łȂ���ΐ������Ȃ�
                if (other.tag != SinObj.tag && !other.CompareTag("SWW"))
                {
                    return;
                }

               
                // ���ʂɐ������[�h�͑����g��Ȃ��Ǝv���̂łƂ肠�����R�����g�A�E�g
               /*
                if (HitNo < 0)
                {
                    animator.SetTrigger("Blow");
                    // �����ʒu
                    Vector3 GenePos = new Vector3(tr.position.x, tr.position.y, tr.position.z);
                    // �v���n�u���w��ʒu�ɐ���
                    GameObject Obj = Instantiate(SinObj, GenePos, Quaternion.identity);

                    CircleResize CRA = Obj.GetComponent<CircleResize>();
                    //CRA.SinLevel = 1;
                    CRA.SinSize = 6;
                    CRA.SinTime = 60;
                    
                    DelteCoolTime = 0.0f;
                    return;
                }
                */

                // ��x�����������̂���͐������Ȃ����[�h
                if (CR.HitTuning(HitNo))
                {
                    // �d������̂Ő������Ȃ�
              
                }
                else
                {
                   // animator.SetTrigger("Blow");
                    // �����ʒu
                    Vector3 GenePos = new Vector3(tr.position.x, tr.position.y, tr.position.z);
                    // �v���n�u���w��ʒu�ɐ���
                    GameObject Obj = Instantiate(SinObj, GenePos, Quaternion.identity);
                    // ���̐ݒ�
                    CircleResize CRA = Obj.GetComponent<CircleResize>();
                    CRA.SinSize = SpeakerPower;
                    CRA.SinTime = 60;
                   
                    //�t���O�Z�b�g
                    CRA.HitTuningFg = CR.HitTuningFg;
                    CRA.SetHitTuning(HitNo);

                    DelteCoolTime = 0.0f;

                    //////////SE�ǉ��ɔ����ύX�_
                    // �^�O�ɉ�����SE���Đ�
                    switch (SinObj.tag)
                    {
                        case "SWB":// ��
                            SoundManager.Instance.PlaySE(SESoundData.SE.SoundW_B);
                            break;

                        case "SWBl":// ��    
                            SoundManager.Instance.PlaySE(SESoundData.SE.SoundW_Bl);
                            break;

                        case "SWG":// ��
                            SoundManager.Instance.PlaySE(SESoundData.SE.SoundW_G);
                            break;

                        case "SWR":// ��
                            SoundManager.Instance.PlaySE(SESoundData.SE.SoundW_R);
                            break;

                        case "SWW":// ��
                            SoundManager.Instance.PlaySE(SESoundData.SE.SoundW_W);
                            break;
                    }
                }
            }
        }
    }
}
