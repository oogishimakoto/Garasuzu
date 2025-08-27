using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public string charaName = "Player"; // �I�u�W�F�N�g����ǔ�����B
    public float VecX = 0;
    [Header("1�����")]
    public float VecY = 0;
    [Header("-10�����")]
    public float VecZ = 0;
    public float CameraPosX = 0;
    public float CameraPosY = 0;
    public float AnglX = 0;
    public float AnglY = 0;
    public float AnglZ = 0;
    [Header("�J�������W����(�X�e�[�W�[�ɍ��킹��)")]
    public float CamRimitL = 0;
    [Header("�J�������W�E��(�X�e�[�W�[�ɍ��킹��)")]
    public float CamRimitR = 0;
    [Header("�J�������W���(�X�e�[�W�[�ɍ��킹��)")]
    public float CamRimitT = 0;
    [Header("�J�������W����(�X�e�[�W�[�ɍ��킹��)")]
    public float CamRimitB = 0;
    [Header("�Y�[���t���O")]
    public bool ZoomFlg = false;

    GameObject charaObj;          // �L�����N�^�[�I�u�W�F�N�g
    GameObject cameraObj;         // �J�����I�u�W�F�N�g�擾
    Vector3 cameraVec;            // �J�����̈ʒu
    Vector3 cameraAngl;           // �J�����̊p�x
    // Start is called before the first frame update
    void Start()
    {
        // ���O������Scene������I�u�W�F�N�g��������
        charaObj = GameObject.Find(charaName);
        cameraVec = new Vector3(0.0f, 0.0f, 0.0f);
        cameraAngl = new Vector3(0.0f, 0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        // �J�����̍��W��������B
        cameraVec.x = charaObj.transform.position.x + VecX + CameraPosX;         // X���W�̓L�����Ɠ���
        if (cameraVec.x < CamRimitL)
        {
            cameraVec.x = CamRimitL;
        }
        if (cameraVec.x > CamRimitR)
        {
            cameraVec.x = CamRimitR;
        }
        cameraVec.y = charaObj.transform.position.y + VecY + CameraPosY;         // Y���W�̓L�����Ɠ���
        if (cameraVec.y < CamRimitB)
        {
            cameraVec.y = CamRimitB;
        }
        if (cameraVec.y > CamRimitT)
        {
            cameraVec.y = CamRimitT;
        }

        //�Y�[��
        if (ZoomFlg == true)
        {
            VecZ = VecZ += 0.02f;
            if (VecZ > -5)
            {
                VecZ = -5;
            }
        }


        cameraVec.z = VecZ;                                                      // Z���W�̓L�����Ƌ���
        cameraAngl.x = AnglX;                                                    // �J�����̊p�x
        cameraAngl.y = AnglY;                                                    // �J�����̊p�x
        cameraAngl.z = AnglZ;                                                    // �J�����̊p�x
        this.transform.position = cameraVec;                                     // �J�����̍��W�K�p
        this.transform.localEulerAngles = cameraAngl;
    }
}
