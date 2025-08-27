using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Player : Characte
{
    // Player�̓V���O���g���ɂ��Ƃ�
    #region Singleton
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<Player>();
            {
                return instance;
            }
        }
    }
    #endregion
    private SaveSystem System => SaveSystem.Instance;  //���\�b�h�ȗ�
    private UserData Data => System.UserData;          //���\�b�h�ȗ�
    private int stopTimer = 0;  // �v���C���[�̓�������莞�Ԏ~�߂邽�߂̃^�C�}�[
    private Animator animator;//�A�j���[�^�[�p


    [Header("�W�����v������(1)")]
    public float JumpallTime = 1.00f;
    [Header("�`���[�W�ɂ����鎞��(0.1)")]
    public float CcargeTime = 0.1f;
    [Header("�㏸�ɂ����鎞��(0.2)")]
    public float UpTime = 0.2f;
    [Header("�����ɂ����鎞��(0.6)")]
    public float foleTime = 0.6f;
    [Header("���n��d������(0.1)")]
    public float tyakutiTime = 0.1f;
    [Header("���ݎ���(�e�X�g�p)")]
    public float nowtime = 0.0f;

    [Header("�V���b�N�^�C��(�ő�)")]
    public float Maxshocktime;

    [Header("�V���b�N�^�C��(����)")]
    public float Nowshocktime = 0.0f;

    public bool UseKey = true;

    //////////SE�ǉ��ɔ����ύX�_
    private bool lastGroundTouch = false;
    private bool deadFlg = false;

    [Header("�E�������Ă��邩�ۂ�")]
    public bool Right = false;
    ///////�V��ǋL(4/25)
    [Header("�|�[�Y���Ă��邩�ۂ�")]
    public bool The_World = false;

    ////////////�V��ǋL
    private PlayerInput PInput;
    private InputActionMap PlayerSet;
    private InputAction _RightMove;
    private InputAction _LeftMove;
    private InputAction _Jump;
    private InputAction _Beat;
    private InputAction _Pause;

    public void SetTheWorld(bool flg)
    {
        The_World = flg;
    }

    protected override void Start()         �@// �I�[�o�[���C�h
    {
        base.Start();                        // �e��Start�Ăяo��

        ////////�V��ǋL
        PInput = GetComponent<PlayerInput>();
        PlayerSet = PInput.currentActionMap;
        _RightMove = PlayerSet["MoveRight"];
        _LeftMove = PlayerSet["MoveLeft"];
        _Jump = PlayerSet["Jump"];
        _Beat = PlayerSet["Beat"];
        _Pause = PlayerSet["The_World"];

        animator = GetComponent<Animator>();//�A�j���[�^�[�R���|�[�l���g�擾
        //this.transform.position = Data.Pos;  // ���[�h�����ʒu��Character���ړ�������
        Data.Pos = Player.Instance.transform.position;  // �|�W�V������ۑ�
        SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
    }
    // Update is called once per frame
    void Update()
    {
        //�V��ǋL
        bool rightflg = _RightMove.IsPressed();
        bool leftflg = _LeftMove.IsPressed();
        bool _jumpflg = _Jump.triggered;
        bool beatflg = _Beat.triggered;
        bool pauseflg = _Pause.triggered;

        //�L�[���g�����Ԃł����

        /////////�V��ǋL(4/25)�|�[�Y����t���O��true�ɂ�����A�󋵂ɉ�����rigidbody��FreezePosition��true�ɂ����肷��
        if ((pauseflg == true ) && SceneManager.GetActiveScene().name != "title")//|| pauseflg == true)
        {
            if (The_World == true)
            {
                The_World = false;
                rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
                Time.timeScale = 1;
            }
            else if (The_World == false)
            {
                The_World = true;
                rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
                Time.timeScale = 0;
            }
        }


        //if (Input.GetKeyDown(KeyCode.Q))                    // �Z�[�u���鎞��keyCord
        //{
        //    Data.Pos = Player.Instance.transform.position;  // �|�W�V������ۑ�
        //    SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    this.transform.position = Data.Pos;
        //    SaveSystem.Instance.Load();                     // script�̎Q��
        //}

        if (The_World == false & UseKey == true)//�|�[�Y���͂��̒��͒ʂ�Ȃ�
        {
            if (stopTimer <= 0)
            {
                //=================================================
                //�v���C���[�̈ړ�����
                //=================================================
                moveForward = new Vector3(0.0f, 0.0f, 0.0f);    // �ړ��x�Z�b�g 

                // �E�L�[�������ꂽ
                // �ǂɐڐG���͈ړ��𐧌����Ă߂荞�܂Ȃ��悤�ɂ���
                if (/*Input.GetKey(rightkey) ||*/ rightflg == true && rightWallTouch != true)
                {
                    moveForward.x = 1;  // �ړ�
                    Right = true;
                    startAngle = this.transform.eulerAngles.y;  // �J�n�p�x�Z�b�g
                    targetAngle = 90.0f + 0.01f;  // �ڕW�p�x���Z�b�g�i�p�x�����������Ȃ�Ȃ��悤0.01f�����Z�j
                    angleCount = 0;             // ��]��Ԃ�0��
                    animator.SetBool("Run", true);
                }
                // ���L�[�������ꂽ
                // �ǂɐڐG���͈ړ��𐧌����Ă߂荞�܂Ȃ��悤�ɂ���
                else if (/*Input.GetKey(leftkey) ||*/ leftflg == true && leftWallTouch != true)
                {
                    moveForward.x = -1; // �ړ�
                    Right = false;
                    startAngle = this.transform.eulerAngles.y;  // �J�n�p�x�Z�b�g
                    targetAngle = 270.0f;   // �ڕW�p�x���Z�b�g
                    angleCount = 0;         // ��]��Ԃ�0��
                    animator.SetBool("Run", true);
                }
                else
                {
                    animator.SetBool("Run", false);
                    if (Right == false)
                    {
                        targetAngle = 180.0f;
                    }
                }
                //=================================================
                // �v���C���[�̃W�����v����
                //=================================================
                jumpForward = new Vector3(0.0f, 0.0f, 0.0f);                    // �ړ��x�Z�b�g

                if (/*(Input.GetKeyDown(jumpKey) && groundTouch == true) ||*/ (_jumpflg == true && groundTouch == true) )           // �X�y�[�X��������&&Touch�t���O��true�Ȃ�
                {
                    jumpForward.y = 3.0f;
                    lastGroundTouch = true;
                    rb.AddForce(jumpForward * jumpPower, ForceMode.Impulse);    //�ړ������ɃX�s�[�h���|����AddForce�֐������s(Impulse)��u�ŗ͂��|����B
                    jumpflg = true;
                    //////////SE�ǉ��ɔ����ύX�_
                    SoundManager.Instance.PlaySE(SESoundData.SE.Jump);
                }


                if (jumpflg == true)
                {
                    nowtime += Time.deltaTime;
                    if (nowtime <= CcargeTime)
                    {
                        animator.SetBool("Charge", true);
                    }
                    else if (nowtime <= CcargeTime + UpTime)
                    {
                        animator.SetBool("Charge", false);
                        animator.SetBool("Up", true);

                    }
                    else if (nowtime <= CcargeTime + UpTime + foleTime)
                    {
                        animator.SetBool("Up", false);
                        animator.SetBool("Down", true);
                    }
                    else if (nowtime <= CcargeTime + UpTime + foleTime + tyakutiTime)
                    {
                        animator.SetBool("Down", false);
                        animator.SetBool("Landing", true);

                    }
                }

                if (nowtime >= JumpallTime)
                {
                    animator.SetBool("Landing", false);
                    lastGroundTouch = false;
                    jumpflg = false;
                    nowtime = 0.0f;
                    SoundManager.Instance.PlaySE(SESoundData.SE.Lading);
                }


            }

        }



        if (UseKey == false)
        {
            animator.SetBool("Shock", true);
            Nowshocktime += Time.deltaTime;
            if (Maxshocktime < Nowshocktime)
            {

                //SceneManager.LoadScene("1-1"); //�V�[����ǂݍ���
                Nowshocktime = 0.0f;
                this.transform.position = Data.Pos;
                SaveSystem.Instance.Load();                     // script�̎Q��
                UseKey = true;
                animator.SetBool("Shock", false);
            }
        }

        //=================================================
        // �v���C���[�̊p�x����
        //=================================================
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
                                                                       //=================================================
                                                                       // ���C���΂�
                                                                       //=================================================
                                                                       // �n�ʂƂ̔���
        Vector3 rayOri = new Vector3(0.0f, 0.05f, 0.0f);    // ���C�̊J�n�ʒu
        Vector3 rayDir = new Vector3(0.0f, -1.0f, 0.0f);    // ���C�̕���
        float rayDist = 0.1f;   // �I�u�W�F�N�g�Ƃ̋���
        groundTouch = FlgRayCheck(groundTouch, rayOri, rayDir, rayDist);


        // �E�̕�
        rayOri = new Vector3(0.0f, 0.1f, 0.0f);    // ���C�̊J�n�ʒu
        rayDir = new Vector3(1.0f, 0.0f, 0.0f);   // ���C�̕���
        rayDist = 0.3f;   // �I�u�W�F�N�g�Ƃ̋���
        rightWallTouch = FlgRayCheck(rightWallTouch, rayOri, rayDir, rayDist);
        if (rightWallTouch == true)
        {

        }
        // �������G��Ă��Ȃ��ꍇ�㕔�𒲂ׂ�
        else
        {
            rayOri = new Vector3(0.0f, 0.9f, 0.0f);    // ���C�̊J�n�ʒu
            rightWallTouch = FlgRayCheck(rightWallTouch, rayOri, rayDir, rayDist);
        }

        // ���̕�
        rayOri = new Vector3(0.0f, 0.1f, 0.0f);    // ���C�̊J�n�ʒu
        rayDir = new Vector3(-1.0f, 0.0f, 0.0f);   // ���C�̕���
        rayDist = 0.3f;   // �I�u�W�F�N�g�Ƃ̋���
        leftWallTouch = FlgRayCheck(leftWallTouch, rayOri, rayDir, rayDist);
        if (leftWallTouch == true)
        {

        }
        // �������G��Ă��Ȃ��ꍇ�㕔�𒲂ׂ�
        else
        {
            rayOri = new Vector3(0.0f, 0.9f, 0.0f);    // ���C�̊J�n�ʒu
            leftWallTouch = FlgRayCheck(leftWallTouch, rayOri, rayDir, rayDist);
        }


        //==================================================
        // �A�j���[�V��������
        //==================================================
        // ���s�A�j���[�V��������
        //if (moveForward != Vector3.zero)     // moveForward���[���łȂ����

        //{
        //    anim.SetBool("running", true);  //running��true�ɂ���B
        //}
        //else
        //{
        //    anim.SetBool("running", false);  //running��false�ɂ���
        //}
        //// �W�����v�A�j���[�V��������
        //if (Input.GetKeyDown(jumpKey) && groundTouch == true)
        //{
        //    anim.SetBool("jumping", true);  // jumping��true�ɂ���
        //}
        //else
        //{
        //    anim.SetBool("jumping", false);  // junping��false�ɂ���
        //}

        //==================================================
        // SE�̐ݒ�
        //==================================================
        if (Input.GetKeyDown(jumpKey) && groundTouch == true)
        {
            // asou.Play();                    // �W�����v���ʉ��Đ�
        }

        //==================================================
        // �p�[�e�B�N��
        //==================================================
        // ���s�p�[�e�B�N��
        //if (rb.velocity != Vector3.zero && groundTouch == true)             // �����Frb.velocity���[���łȂ�&&�n��ɂ����
        //{
        //    if (!psys.isEmitting)                                           // �����F�p�[�e�B�N���Đ����łȂ����
        //    {
        //        psys.Play();                                                // �p�[�e�B�N���Đ�
        //    }
        //    else
        //    {
        //        if (psys.isEmitting)                                        // �p�[�e�B�N���Đ����Ȃ�
        //        {
        //            psys.Stop();                                            // �p�[�e�B�N����~����B
        //        }
        //    }
        //}

        //==================================================
        // �v���C���[���s���s�\�ɂ���
        //==================================================
        if (Input.GetKeyDown(KeyCode.M))
        {
            stopTimer = 180;        // 180�t���[���̃^�C�}�[
            moveForward.x = 0.0f;   // ���݂̈ړ��x�����Z�b�g����
        }
        if (stopTimer > 0)
        {
            stopTimer--;    // �^�C�}�[�����炷
        }



    }
    //==================================================
    // �G�Ƃ̏Փ˔���
    //==================================================
    private void OnCollisionEnter(Collision collision)
    {
        // �Ԃ����Ă����I�u�W�F�N�g���G�Ȃ�
        if (collision.gameObject.tag == "Enemy")
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Fall);
            UseKey = false;
            moveForward.x = 0.0f;
            moveForward.y = 0.0f;

        }
    }

    private bool FlgRayCheck(bool flg, Vector3 ori, Vector3 dir, float dist)
    {
        Ray ray = new Ray(
            this.transform.position +
            ori,     // ���C�̊J�n�ʒu
            dir);    // ���C�̕���
        RaycastHit hit;         // ���������ƌ��ʂ�������ϐ�
        flg = false;    // �Ƃ肠�����n�ʂɐG��ĂȂ����Ƃɂ���
        if (Physics.Raycast(ray, out hit, 10.0f))
        {
            // ���C�̊J�n�ʒu�Ɠ��������I�u�W�F�N�g�̋��������ȉ��Ȃ�
            if (hit.distance < dist)
            {
                flg = true; // �n�ʂɐڐG���Ă���B
            }
            if (hit.collider.isTrigger == true)//���蔲����I�u�W�F�N�g�Ȃ�false�ɂ���
            {
                flg = false;
            }
        }
        return flg; // ���݂̃t���O�̏�Ԃ�Ԃ�
    }
    public void PlayFootstepSound01()
    {
        if (groundTouch == true)
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Footstep_1);
        }
    }

    public void PlayFootstepSound02()
    {
        if (groundTouch == true)
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Footstep_2);
        }
    }
}