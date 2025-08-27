using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using static UnityEngine.ParticleSystem;

public class CircleResize_SawanoSpecial : MonoBehaviour
{
    //=================================================
    //�ϐ�
    //=================================================
    float ScaleSize = 0.0f;                 // �~�̊g��k��
    public AnimationCurve curve;        //�A�j���[�V�������x
    float FPS = 0.0f;   //FPS

    float startTime = 0;

    //public int SinLevel = 0;
    public float SinSize = 2000.0f;
    public float SinTime = 20000.0f;

    [Header("�q�b�g�Ǘ��p�ϐ�")]
    public int HitTuningFg = 0;

    // Start is called before the first frame update
    void Start()
    {
        // �������Ԃ��L��
        startTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        // �t���[�����[�g
        //FPS += Time.deltaTime;

        // �S�����L���鏈��
        //gameObject.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Color.white);
        ScaleSize = SinSize * curve.Evaluate((Time.time - startTime) / (SinTime / 60.0f));


        //�~���ő�̑傫���ɂȂ��������
        if (ScaleSize >= SinSize)
        {
            //Debug.Log("�폜");
            Destroy(this.gameObject);
        }

        //FPS���Z�b�g
        //if (FPS >= 60 / 60.0f)
        //{
            //FPS %= 1;
        //}

        this.transform.localScale = new Vector3(ScaleSize, ScaleSize, ScaleSize);

    }

    public bool HitTuning(int _value)
    {
        // ����TypeN�͑O�̂�Ƃ��֌W�Ȃ��̂ŃX���[
        //if (LayerMask.LayerToName(gameObject.layer) == "TypeN_Oto") return false; 

        // �r�b�g���Z�p�ɐ��l��␳����
        _value = 1 << _value;

        // �K��̔ԍ��Ƀt���O�������Ă��邩�`�F�b�N
        if ((HitTuningFg & _value) == _value)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void SetHitTuning(int _value)
    {
        // �r�b�g���Z�p�ɐ��l��␳����
        _value = 1 << _value;

        // ���l������
        HitTuningFg |= _value;
    }


}
