using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerMove : Characte
{
    // Start is called before the first frame update

    [Header("�����œ�������(X)")]
    public float HalfDisX;
    [Header("�����œ�������(Y)")]
    public float HalfDisY;
    [Header("�����œ�������(Z)")]
    public float HalfDisZ;

    [Header("1f�łǂꂾ���ړ����邩(X)")]
    public float SpeedX;
    [Header("1f�łǂꂾ���ړ����邩(Y)")]
    public float SpeedY;
    [Header("1f�łǂꂾ���ړ����邩(Z)")]
    public float SpeedZ;

    private Vector3 DefaultPosition;
    private Animator animator;//�A�j���[�^�[�p
    [Header("�E�ɓ����Ă邩�ǂ���")]
    private bool RightMove = true;
    private bool ForwardMove = true;
    [Header("����̈ʒu���琳�̕����ɓ������ǂ���")]
    [SerializeField]
    bool Xswitch = true, Yswitch = true, Zswitch = true;
    [Header("������ύX���Ȃ��Ƃ��p")]
    public bool AngleF = true;

    void Start()
    {
        DefaultPosition = this.transform.position;
        animator = GetComponent<Animator>();//�A�j���[�^�[�R���|�[�l���g�擾
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        //////�����݈ʒu�Ə���̈ʒu��if��
        if (DefaultPosition.x + HalfDisX < transform.position.x)
        {
            Xswitch = false;
        }
        else if (DefaultPosition.x - HalfDisX > transform.position.x)
        {
            Xswitch = true;
        }
        if (DefaultPosition.y + HalfDisY < transform.position.y)
        {
            Yswitch = false;
        }
        else if (DefaultPosition.y - HalfDisY > transform.position.y)
        {
            Yswitch = true;
        }
        if (DefaultPosition.z + HalfDisZ < transform.position.z)
        {
            Zswitch = false;
        }
        else if (DefaultPosition.z - HalfDisZ > transform.position.z)
        {
            Zswitch = true;
        }

        //////�������܂�

        //////�ړ�������
        if (Xswitch == true)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x + SpeedX, transform.position.y, transform.position.z);
            animator.SetBool("Walk", true);
            RightMove = true;
        }
        else if (Xswitch == false)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x - SpeedX, transform.position.y, transform.position.z);
            RightMove = false;
        }
        if (Yswitch == true)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + SpeedY, transform.position.z);
        }
        else if (Yswitch == false)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - SpeedY, transform.position.z);
        }

        if (Zswitch == true)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + SpeedZ);
            ForwardMove = true;

        }
        else if (Zswitch == false)
        {
            this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - SpeedZ);
            ForwardMove = false;

        }

        if (AngleF == true)
        {
            //�E�������Ă��鎞
            if (RightMove == true && SpeedX > 0.01f)
            {

                startAngle = this.transform.eulerAngles.y;  // �J�n�p�x�Z�b�g
                targetAngle = 90.0f + 0.01f;  // �ڕW�p�x���Z�b�g�i�p�x�����������Ȃ�Ȃ��悤0.01f�����Z�j
                angleCount = 0;             // ��]��Ԃ�0��
            }
            //�E�������Ă��Ȃ���
            else if (RightMove == false && SpeedX > 0.01f)
            {
                moveForward.x = -1; // �ړ�
                startAngle = this.transform.eulerAngles.y;  // �J�n�p�x�Z�b�g
                targetAngle = 270.0f;   // �ڕW�p�x���Z�b�g
                angleCount = 0;         // ��]��Ԃ�0��
            }

            //�O�������Ă��鎞
            else if (ForwardMove == true && SpeedZ > 0.01f)
            {
                startAngle = this.transform.eulerAngles.y;  // �J�n�p�x�Z�b�g
                targetAngle = 360.0f;   // �ڕW�p�x���Z�b�g
                angleCount = 0;             // ��]��Ԃ�0��
            }
            //���������Ă���
            else if (ForwardMove == false && SpeedZ > 0.01f)
            {
                moveForward.y = -1; // �ړ�
                startAngle = this.transform.eulerAngles.y;  // �J�n�p�x�Z�b�g
                targetAngle = 180.0f + 0.01f;  // �ڕW�p�x���Z�b�g�i�p�x�����������Ȃ�Ȃ��悤0.01f�����Z�j
                angleCount = 0;         // ��]��Ԃ�0��
            }
            else
            {

                targetAngle = 180.0f;

            }
            if (angleCount <= 1.0f)
            {
                // ��]�x���𑝉�������
                angleCount += Time.deltaTime / turnTime;
            }
            else
            {
                angleCount = 1.0f;
            }
            float angle = Mathf.LerpAngle(startAngle, targetAngle, angleCount);  // ��]�J�n�p�x�Ɖ�]�ڕW�p�x���猻�݂̊p�x���v�Z����
            this.transform.eulerAngles = new Vector3(0.0f, angle, 0.0f);   // ���݂̊p�x��ݒ肷��
        }
    }
}

