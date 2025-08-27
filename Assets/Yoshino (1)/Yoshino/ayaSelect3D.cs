using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ayaSelect3D : MonoBehaviour
{
    //�X�e�[�W��enam�ŊǗ�
    private enum stageInf
    {
        zero,
        OneOne,
        OneTwo,
        OneThree,
        TwoOne,
        TwoTwo,
        TwoThree,
        ThreeOne,
        ThreeTwo,
        ThreeThree,
        FourOne,
        FourTwo,
        FourThree,
        FiveOne,
        FiveTwo,
        FiveThree,
        SixOne,
        SixTwo,
        SixThree,
        SevenOne,
        SevenTwo,
        SevenThree,
    };

    //�J�[�\���ړ��p�ϐ�
    private stageInf nowStage = stageInf.zero;

    //���݂̃X�e�[�W�𐔎��ŊǗ�����
    //1-1�Ȃ�11,1-2�Ȃ�12
    private int InowStage = 0;

    //�ŏ��̈��ڂ̃L�[���͂ł�1-1�ɃJ�[�\�����s���悤�ɋ�������
    private bool firstFlg = true;



    [Header("�J�[�\���ړ��̕�(7-3�܂łȂ�7�Ə���)")]
    public int MaxCursor = 7;
    public int MinCursor = 1;

    //�J�[�\���ʒu����p
    private GameObject Stage11;
    private GameObject Stage12;
    private GameObject Stage13;
    private GameObject Stage21;
    private GameObject Stage22;
    private GameObject Stage23;
    private GameObject Stage31;
    private GameObject Stage32;
    private GameObject Stage33;
    private GameObject Stage41;
    private GameObject Stage42;
    private GameObject Stage43;
    private GameObject Stage51;
    private GameObject Stage52;
    private GameObject Stage53;
    private GameObject Stage61;
    private GameObject Stage62;
    private GameObject Stage63;
    private GameObject Stage71;
    private GameObject Stage72;
    private GameObject Stage73;

    Vector3 nowCameraFocus = new Vector3(-320, -128, -80);

    //�J�����擾�p
    private GameObject p;
    private Camera nowCamera;
    private float cameraSpeed = 1.0f;

    //���Ԏ擾�p
    private float startTime;    //�J�[�]���ړ��̎n�܂�������
    private float ForcusStartTime;  //�X�e�[�W�I�������肵����̃t�H�[�J�X���n�܂�������
    public bool timeFlg = true;    //�X�e�[�W�I�����Ƃ�focus�����Ă������Ɏg���Ă���


    float fadeS = 1.0f; //���x
    [Header("�t�F�[�h�ݒ�")]
    public Image fade;
    public UnityEngine.Color color = new UnityEngine.Color(0, 0, 0, 0); //�t�F�[�h�̐F

    private bool forcusFLg; //�J�[�\���ړ��ɔ����J�����̈ړ����ɓr���̃J�[�\���ύX���ł��Ȃ�����

    [Header("�J�����ʒu")]
    public int Zpos = 20;
    public int Xpos = 0;

    [Header("��")]
    public float rotateSpeed = 100.0f;//��]���x
    public float MaxRotateRight = 10f;//��]�̌��E�p�x
    public float MaxRotateLeft = 350f;//��]�̌��E�p�x
    [SerializeField]

    private float rotateSpeedRight = 0f;  //���̊J���X�s�[�h
    private float rotateSpeedLeft = 0f;  //���̊J���X�s�[�h
    private float beforrotateSpeedRight = 0f;  //���̕���X�s�[�h
    private float beforrotateSpeedLeft = 0f;  //���̕���X�s�[�h
    private float closeendR = 0f;  //���̕���X�s�[�h
    private float closeendL = 0f;  //���̕���X�s�[�h

    //�����J���A�j���[�V�����p
    private GameObject nowPos;
    private GameObject nowPosRight;
    private GameObject nowPosLeft;
    private GameObject beforPosRight;
    private GameObject beforPosLeft;
    private GameObject EndPosR;
    private GameObject EndPosL;

    /////////////�V��ǋL
    private PlayerInput SelectInput;
    private InputActionMap SelectSet;
    private InputAction _RightMove;
    private InputAction _LeftMove;
    private InputAction _UpMove;
    private InputAction _DownMove;
    private InputAction _KetteiButtun;
    private InputAction _ESCButtun;
    public int GetSelectStage()
    {
        return InowStage;
    }

    private void Awake()
    {
        timeFlg = true;    //�X�e�[�W�I�����Ƃ�focus�����Ă������Ɏg���Ă���
    }

    // Start is called before the first frame update
    void Start()
    {
        ///////////�V��ǋL
        SelectInput=GetComponent<PlayerInput>();
        SelectSet = SelectInput.currentActionMap;
        _RightMove = SelectSet["Right"];
        _LeftMove = SelectSet["Left"];
        _UpMove = SelectSet["Up"];
        _DownMove = SelectSet["Down"];
        _KetteiButtun = SelectSet["Kettei"];
        _ESCButtun = SelectSet["ESC"];

        p = GameObject.Find("Main Camera");
        nowCamera = p.GetComponent<Camera>();

        Stage11 = GameObject.Find("1-1");
        Stage12 = GameObject.Find("1-2");
        Stage13 = GameObject.Find("1-3");
        Stage21 = GameObject.Find("2-1");
        Stage22 = GameObject.Find("2-2");
        Stage23 = GameObject.Find("2-3");
        Stage31 = GameObject.Find("3-1");
        Stage32 = GameObject.Find("3-2");
        Stage33 = GameObject.Find("3-3");
        Stage41 = GameObject.Find("4-1");
        Stage42 = GameObject.Find("4-2");
        Stage43 = GameObject.Find("4-3");
        Stage51 = GameObject.Find("5-1");
        Stage52 = GameObject.Find("5-2");
        Stage53 = GameObject.Find("5-3");
        Stage61 = GameObject.Find("6-1");
        Stage62 = GameObject.Find("6-2");
        Stage63 = GameObject.Find("6-3");
        Stage71 = GameObject.Find("7-1");
        Stage72 = GameObject.Find("7-2");
        Stage73 = GameObject.Find("7-3");

        firstFlg = true;
        timeFlg = true;    //�X�e�[�W�I�����Ƃ�focus�����Ă������Ɏg���Ă���
        startTime = Time.time;
        Time.timeScale = 1;
        forcusFLg = true;
        rotateSpeedRight = 180;
        rotateSpeedLeft = 180;

        beforPosRight = GameObject.Find("a");
        beforPosLeft = GameObject.Find("a");
    }

    // Update is called once per frame
    void Update()
    {
        //========================================================================
        //��

        //////////�V��ǋL
        bool rightflg = _RightMove.IsPressed();
        bool leftflg = _LeftMove.IsPressed();
        bool upflg = _UpMove.IsPressed();
        bool downflg = _DownMove.IsPressed();
        bool ketteiflg = _KetteiButtun.triggered;
        bool ESC = _ESCButtun.triggered;

        //������������
        if (Input.GetKeyDown(KeyCode.DownArrow)||downflg==true && timeFlg)
        {
            //�ŏ��̈�񂾂��ړ��ł���͈͂̍Œ�̃X�e�[�W���I�������
            if (firstFlg)
            {
                InowStage += (MinCursor * 10) + 1;
                firstFlg = false;//����������false��
                timeFlg = false;
                startTime = Time.time;
            }
            else
            {

                EndPosR = beforPosRight;//Pos�X�V
                EndPosL = beforPosLeft;
                if (EndPosR == nowPosRight)
                {
                    EndPosR = null;
                    EndPosL = null;
                }
                beforPosRight = nowPosRight;
                beforPosLeft = nowPosLeft;//�����܂�

                ///////���J���Ȃ���鎞�p�ɍ��̊J����Ԃ������p���ł���
                closeendR = beforrotateSpeedRight;
                closeendL = beforrotateSpeedLeft;
                beforrotateSpeedRight = rotateSpeedRight;
                beforrotateSpeedLeft = rotateSpeedLeft;
                rotateSpeedRight = 180;
                rotateSpeedLeft = 180;
                //�c�̃J�[�\���ړ�
                InowStage -= 10;
                //�J�[�\�����͈͂𒴂�����͈͂̋t���Ɉړ�
                if (InowStage < MinCursor * 10)
                {
                    InowStage += (MaxCursor - MinCursor + 1) * 10;
                }


                if (timeFlg)
                {
                    startTime = Time.time;
                    timeFlg = false;
                    //CloseDoor();
                }
            }
            SoundManager.Instance.PlaySE(SESoundData.SE.Cursor_M);

        }

        //�����������
        if (Input.GetKeyDown(KeyCode.UpArrow) ||upflg==true&& timeFlg)
        {
            //�ŏ��̈�񂾂��ړ��ł���͈͂̍Œ�̃X�e�[�W���I�������
            if (firstFlg)
            {
                InowStage += (MinCursor * 10) + 1;
                firstFlg = false;
                timeFlg = false;
                startTime = Time.time;
            }
            else
            {

                EndPosR = beforPosRight;//Pos�X�V
                EndPosL = beforPosLeft;
                if (EndPosR.transform == nowPosRight.transform)
                {
                    Debug.Log("�Ƃ�����������������������������");
                    EndPosR = null;
                    EndPosL = null;
                }
                beforPosRight = nowPosRight;
                beforPosLeft = nowPosLeft;

                closeendR = beforrotateSpeedRight;
                closeendL = beforrotateSpeedLeft;
                beforrotateSpeedRight = rotateSpeedRight;
                beforrotateSpeedLeft = rotateSpeedLeft;
                rotateSpeedRight = 180;
                rotateSpeedLeft = 180;
                //�c�̃J�[�\���ړ�
                InowStage += 10;
                //�J�[�\�����͈͂𒴂�����͈͂̋t���Ɉړ�
                if (InowStage > (MaxCursor * 10) + 10)
                {
                    InowStage -= (MaxCursor - MinCursor + 1) * 10;
                }

                if (timeFlg)
                {
                    startTime = Time.time;
                    timeFlg = false;
                    //CloseDoor();
                }
            }
            SoundManager.Instance.PlaySE(SESoundData.SE.Cursor_M);

        }

        //�E����������
        if (Input.GetKeyDown(KeyCode.RightArrow)||rightflg==true && timeFlg)
        {
            //�ŏ��̈�񂾂��ړ��ł���͈͂̍Œ�̃X�e�[�W���I�������
            if (firstFlg)
            {
                InowStage += (MinCursor * 10) + 1;
                firstFlg = false;
                timeFlg = false;
                startTime = Time.time;
            }
            else
            {

                EndPosR = beforPosRight;//Pos�X�V
                EndPosL = beforPosLeft;
                if (EndPosR == nowPosRight)
                {
                    EndPosR = null;
                    EndPosL = null;
                }
                beforPosRight = nowPosRight;
                beforPosLeft = nowPosLeft;

                closeendR = beforrotateSpeedRight;
                closeendL = beforrotateSpeedLeft;
                beforrotateSpeedRight = rotateSpeedRight;
                beforrotateSpeedLeft = rotateSpeedLeft;
                rotateSpeedRight = 180;
                rotateSpeedLeft = 180;
                //���̃J�[�\���ړ�
                InowStage += 1;

                //1�̈ʂ�3�𒴂�����1�ɖ߂�
                if (InowStage % 10 > 3)
                {
                    InowStage -= 3;
                }

                if (timeFlg)
                {
                    startTime = Time.time;
                    timeFlg = false;
                    //CloseDoor();
                }
            }
            SoundManager.Instance.PlaySE(SESoundData.SE.Cursor_M);

        }

        //������������
        if (Input.GetKeyDown(KeyCode.LeftArrow)||leftflg==true && timeFlg)
        {
            //�ŏ��̈�񂾂��ړ��ł���͈͂̍Œ�̃X�e�[�W���I�������
            if (firstFlg)
            {
                InowStage += (MinCursor * 10) + 1;
                firstFlg = false;
                timeFlg = false;
                startTime = Time.time;
            }
            else
            {

                EndPosR = beforPosRight;//Pos�X�V
                EndPosL = beforPosLeft;
                if (EndPosR == nowPosRight)
                {
                    EndPosR = null;
                    EndPosL = null;
                }
                beforPosRight = nowPosRight;
                beforPosLeft = nowPosLeft;

                closeendR = beforrotateSpeedRight;
                closeendL = beforrotateSpeedLeft;
                beforrotateSpeedRight = rotateSpeedRight;
                beforrotateSpeedLeft = rotateSpeedLeft;
                rotateSpeedRight = 180;
                rotateSpeedLeft = 180;
                //���̃J�[�\���ړ�
                InowStage -= 1;

                //1�̈ʂ�1�����������3�ɖ߂�
                if (InowStage % 10 < 1)
                {
                    InowStage += 3;
                }

                if (timeFlg)
                {
                    startTime = Time.time;
                    timeFlg = false;
                    //CloseDoor();
                }
            }
            SoundManager.Instance.PlaySE(SESoundData.SE.Cursor_M);

        }

        CursorChange();



        //��
        //==========================================================

        if (/*Input.GetKeyDown(KeyCode.Return)||*/ketteiflg==true && timeFlg && nowPos != null)
        {
            ForcusStartTime = Time.time;
            //�t�F�[�h
            StartCoroutine(Fade());
        }

        if (/*Input.GetKeyDown(KeyCode.Escape)*/ESC==true && timeFlg)
        {
            SceneManager.LoadScene("title");
        }

    }

    //�J�[�\���ړ��ɔ����ăX�e�[�W�̑I����ς���
    private void CursorChange()
    {
        //�ŏ��̈�񂾂��̓X�e�[�W11���I�������悤�ɂ���
        if (firstFlg)
        {
            nowStage = stageInf.OneOne;

        }
        else
        {
            if (InowStage == 11)
            {
                nowStage = stageInf.OneOne;
                NowStage11();
            }

            if (InowStage == 12)
            {
                nowStage = stageInf.OneTwo;
                NowStage12();
            }

            if (InowStage == 13)
            {
                nowStage = stageInf.OneThree;
                NowStage13();
            }

            if (InowStage == 21)
            {
                nowStage = stageInf.TwoOne;
                NowStage21();
            }

            if (InowStage == 22)
            {
                nowStage = stageInf.TwoTwo;
                NowStage22();
            }

            if (InowStage == 23)
            {
                nowStage = stageInf.TwoThree;
                NowStage23();
            }

            if (InowStage == 31)
            {
                nowStage = stageInf.ThreeOne;
                NowStage31();
            }

            if (InowStage == 32)
            {
                nowStage = stageInf.ThreeTwo;
                NowStage32();
            }

            if (InowStage == 33)
            {
                nowStage = stageInf.ThreeThree;
                NowStage33();
            }

            if (InowStage == 41)
            {
                nowStage = stageInf.FourOne;
                NowStage41();
            }

            if (InowStage == 42)
            {
                nowStage = stageInf.FourTwo;
                NowStage42();
            }

            if (InowStage == 43)
            {
                nowStage = stageInf.FourThree;
                NowStage43();
            }

            if (InowStage == 51)
            {
                nowStage = stageInf.FiveOne;
                NowStage51();
            }

            if (InowStage == 52)
            {
                nowStage = stageInf.FiveTwo;
                NowStage52();
            }

            if (InowStage == 53)
            {
                nowStage = stageInf.FiveThree;
                NowStage53();
            }

            if (InowStage == 61)
            {
                nowStage = stageInf.SixOne;
                NowStage61();
            }

            if (InowStage == 62)
            {
                nowStage = stageInf.SixTwo;
                NowStage62();
            }

            if (InowStage == 63)
            {
                nowStage = stageInf.SixThree;
                NowStage63();
            }

            if (InowStage == 71)
            {
                nowStage = stageInf.SevenOne;
                NowStage71();
            }

            if (InowStage == 72)
            {
                nowStage = stageInf.SevenTwo;
                NowStage72();
            }

            if (InowStage == 73)
            {
                nowStage = stageInf.SevenThree;
                NowStage73();
            }
        }
    }

    //============================================================================
    //�e�X�e�[�W���ƂɑI������Ă���Ƃ��̏�����`��

    private void NowStage11()
    {

        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage11.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door1-1/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door1-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door1-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage12()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage12.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door1-2/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door1-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door1-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage13()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage13.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door1-3/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door1-3/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door1-3/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage21()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage21.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door2-1/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door2-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door2-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage22()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage22.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door2-2/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door2-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door2-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage23()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage23.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door2-3/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door2-3/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door2-3/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage31()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage31.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door3-1/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door3-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door3-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage32()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage32.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door3-2/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door3-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door3-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage33()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage33.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door3-3/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door3-3/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door3-3/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();

    }
    private void NowStage41()
    {

        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage41.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door4-1/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door4-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door4-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage42()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage42.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door4-2/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door4-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door4-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage43()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage43.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door4-3/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door4-3/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door4-3/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage51()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage51.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door5-1/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door5-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door5-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage52()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage52.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door5-2/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door5-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door5-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage53()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage53.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door5-3/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door5-3/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door5-3/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage61()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage61.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door6-1/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door6-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door6-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage62()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage62.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door6-2/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door6-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door6-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage63()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage63.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door6-3/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door6-3/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door6-3/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();

    }

    private void NowStage71()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage71.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door7-1/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door7-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door7-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage72()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage72.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door7-2/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door7-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door7-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage73()
    {
        //fade�p�̈ʒu���i�[����
        nowCameraFocus = Stage73.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door7-3/Double_Door");

        //�I������Ă���X�e�[�W�̃h�A���J����
        nowPosRight = GameObject.Find("door7-3/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door7-3/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();

    }

    //---------------------------------------------------------------------------------------------------
    //fade
    IEnumerator Fade()
    {
        //�t�F�[�h�pPanel�L��
        fade.gameObject.SetActive(true);
        //�����x���Ȃ��Ȃ�܂�
        while (fade.color.a <= 0.9f)
        {
            FadeCamera();//�J�������߂Â���
            fade.color = new UnityEngine.Color(color.r, color.g, color.b, fade.color.a + (fadeS * Time.deltaTime));//fade

            yield return null;//1f�ҋ@
        }

        //fade���I���΃V�[�����ړ�������
        if (nowStage == stageInf.OneOne)
        {
            SceneManager.LoadScene("1-1");
        }

        if (nowStage == stageInf.OneTwo)
        {
            SceneManager.LoadScene("1-2");
        }

        if (nowStage == stageInf.OneThree)
        {
            SceneManager.LoadScene("1-3");
        }

        //2
        if (nowStage == stageInf.TwoOne)
        {
            SceneManager.LoadScene("2-1");
        }

        if (nowStage == stageInf.TwoTwo)
        {
            SceneManager.LoadScene("2-2");
        }

        if (nowStage == stageInf.TwoThree)
        {
            SceneManager.LoadScene("2-3");
        }

        //3
        if (nowStage == stageInf.ThreeOne)
        {
            SceneManager.LoadScene("3-1");
        }

        if (nowStage == stageInf.ThreeTwo)
        {
            SceneManager.LoadScene("3-2");
        }

        if (nowStage == stageInf.ThreeThree)
        {
            SceneManager.LoadScene("3-3");
        }

        //4
        if (nowStage == stageInf.FourOne)
        {
            SceneManager.LoadScene("4-1");
        }

        if (nowStage == stageInf.FourTwo)
        {
            SceneManager.LoadScene("4-2");
        }

        if (nowStage == stageInf.FourThree)
        {
            SceneManager.LoadScene("4-3");
        }

        //5
        if (nowStage == stageInf.FiveOne)
        {
            SceneManager.LoadScene("5-1");
        }

        if (nowStage == stageInf.FiveTwo)
        {
            SceneManager.LoadScene("5-2");
        }

        if (nowStage == stageInf.FiveThree)
        {
            SceneManager.LoadScene("5-3");
        }

        //6
        if (nowStage == stageInf.SixOne)
        {
            SceneManager.LoadScene("6-1");
        }

        if (nowStage == stageInf.SixTwo)
        {
            SceneManager.LoadScene("6-2");
        }

        if (nowStage == stageInf.SixThree)
        {
            SceneManager.LoadScene("6-3");
        }

        //7
        if (nowStage == stageInf.SevenOne)
        {
            SceneManager.LoadScene("7-1");
        }

        if (nowStage == stageInf.SevenTwo)
        {
            SceneManager.LoadScene("7-2");
        }

        if (nowStage == stageInf.SevenThree)
        {
            SceneManager.LoadScene("7-3");
        }
    }

    //�����J���鏈��
    private void OpenDoor()
    {
        if (rotateSpeedRight > MaxRotateRight)
            rotateSpeedRight -= rotateSpeed * Time.deltaTime;
        if (rotateSpeedLeft < MaxRotateLeft)
            rotateSpeedLeft += rotateSpeed * Time.deltaTime;

        if (beforrotateSpeedRight < 180)
            beforrotateSpeedRight += rotateSpeed * Time.deltaTime;
        if (beforrotateSpeedLeft > 180)
            beforrotateSpeedLeft -= rotateSpeed * Time.deltaTime;

        if (closeendR < 180)
            closeendR += rotateSpeed * Time.deltaTime;
        if (closeendL > 180)
            closeendL -= rotateSpeed * Time.deltaTime;

        if (EndPosR != null)
        {
            EndPosR.transform.eulerAngles = new Vector3(0f, closeendR, 0f);
            EndPosL.transform.eulerAngles = new Vector3(0f, closeendL, 0f);
        }
        nowPosRight.transform.eulerAngles = new Vector3(0f, rotateSpeedRight, 0f);
        nowPosLeft.transform.eulerAngles = new Vector3(0f, rotateSpeedLeft, 0f);
        beforPosRight.transform.eulerAngles = new Vector3(0f, beforrotateSpeedRight, 0f);
        beforPosLeft.transform.eulerAngles = new Vector3(0f, beforrotateSpeedLeft, 0f);
    }

    //����߂�
    private void CloseDoor()
    {


        rotateSpeedRight = 180;
        rotateSpeedLeft = 180;

        nowPosRight.transform.eulerAngles = new Vector3(0f, rotateSpeedRight, 0f);
        nowPosLeft.transform.eulerAngles = new Vector3(0f, rotateSpeedLeft, 0f);

    }

    //�I������Ă���X�e�[�W�ɃJ�������߂Â��鏈��
    private void FocusCamera()
    {
        //�I������Ă���X�e�[�W�̃|�W�V����������
        Vector3 other = nowCameraFocus;

        //�J�����ƈړ���̈ʒu�̋���
        float distanceTwo = Vector3.Distance(nowCamera.gameObject.transform.position, other);

        // ���݂̈ʒu
        float presentLocation = (Time.time - startTime * cameraSpeed) / distanceTwo;

        //�ړ������鏈��
        nowCamera.gameObject.transform.position = Vector3.Lerp(nowCamera.gameObject.transform.position, other, presentLocation);

        nowCamera.rect = new Rect(0.0f, 0.0f, 0.7f, 1.0f);


        if (timeFlg == false && nowCamera.gameObject.transform.position == other)
        {
            timeFlg = true;
        }
    }

    private void FadeCamera()
    {
        forcusFLg = false;

        //�I������Ă���X�e�[�W�̃|�W�V����������
        Vector3 other = nowPos.gameObject.transform.position;

        other.y += 3;


        //�J�����ƈړ���̈ʒu�̋���
        float distanceTwo = Vector3.Distance(nowCamera.gameObject.transform.position, other);

        // ���݂̈ʒu
        float presentLocation = (Time.time - ForcusStartTime * cameraSpeed) / distanceTwo;

        //�ړ������鏈��
        nowCamera.gameObject.transform.position = Vector3.Lerp(nowCamera.gameObject.transform.position, other, presentLocation);

        nowCamera.rect = new Rect(0.0f, 0.0f, 0.7f, 1.0f);


        if (nowCamera.gameObject.transform.position == other)
        {
            forcusFLg = false;
        }

    }
}
