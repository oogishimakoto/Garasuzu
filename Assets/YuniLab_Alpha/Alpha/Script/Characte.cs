using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]   // �C���X�^���X��ۑ����邽�߂ɕK�v

public class Characte : MonoBehaviour
{
    protected Rigidbody rb;                        // ���M�b�g�{�f�B
    protected Animator anim;                       // �A�j���[�V����
    protected AudioSource asou;                    // �T�E���h
    protected ParticleSystem psys;                 // �p�[�e�B�N���V�X�e��
    public Vector3 moveForward;                    // �ړ��x
    protected Vector3 jumpForward;                 // �W�����v�̈ړ��x
    //=================================================
    // �L�[�R�[�h�̕ϐ�
    //=================================================
    public KeyCode leftkey = KeyCode.A;            // �L�[�R�[�h�̕ϐ�
    public KeyCode rightkey = KeyCode.D;           // �L�[�R�[�h�̕ϐ�
    public KeyCode jumpKey = KeyCode.Space;        // �L�[�R�[�h�̕ϐ�
    //=================================================
    // �L�����N�^�[�̕ϐ�
    //=================================================
    public Vector3 Pos = Vector3.zero;
    [Header("�ړ����x(15)")]
    public float speed = 15.0f;                    // �L�����N�^�[�̈ړ��X�s�[�h
    [Header("�W�����v��(8)")]
    public float jumpPower = 8.0f;                 // �L�����N�^�[�̃W�����v��
    [Header("�ϓ_�p�x(0,180)")]
    public float startAngle = 0.0f;                 // �ϓ_�J�n�p�x
    public float targetAngle = 180.0f;              // �ϓ_�ڕW�p�x
    [Header("�U������ɂ����鎞��(0.05)")]
    public float turnTime = 0.05f;                     
    [Header("�ړ����x����(3)")]
    public float limitRunSpeed = 3;                // �ړ����x�̐���
    [Header("�㏸���x����(1)")]
    public float limitRiseSpeed = 1;              // �㏸���x�̐���
    [Header("���C�̒���(0.1,0.6)")]
    public float rayGroundDist = 0.1f;  // �n�ʂɔ�΂����C
    public float rayWallDist = 0.6f;    // �ǂɔ�΂����C
    public bool rightWallTouch = false; // �E�����ǂɐG��Ă��邩�̃t���O
    public bool leftWallTouch = false;  // �������ǂɐG��Ă��邩�̃t���O
    public bool groundTouch = false;    // �n�ʂɐG��Ă��邩�ǂ���
    public bool jumpflg = false;    // �W�����v�������ǂ���
    public float angleCount = 0;        // Player�̊p�x�̃J�E���g

    

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = this.GetComponent<Rigidbody>();        // �R���|�[�l���g���擾
        anim = this.GetComponent<Animator>();       // Animator�R���|�[�l���g���擾
        asou = this.GetComponent<AudioSource>();    // AudioSouce�R���|�[�l���g���擾
        psys = this.GetComponent<ParticleSystem>(); // ParticleSystem�R���|�[�l���g���擾
    }



    void FixedUpdate()
    {
        // x���̑��x����
        if (rb.velocity.magnitude > limitRunSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x / 1.1f, rb.velocity.y, rb.velocity.z);
        }
        // y���̑��x����
        if (rb.velocity.y > limitRiseSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y / 1.1f, rb.velocity.z);
        }
        rb.AddForce(moveForward * speed, ForceMode.Force);  //�ړ������ɃX�s�[�h���|����AddForce�֐������s
    }
}
