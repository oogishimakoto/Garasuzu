using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ayaSelect3D : MonoBehaviour
{
    //ステージをenamで管理
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

    //カーソル移動用変数
    private stageInf nowStage = stageInf.zero;

    //現在のステージを数字で管理する
    //1-1なら11,1-2なら12
    private int InowStage = 0;

    //最初の一回目のキー入力では1-1にカーソルが行くように強制する
    private bool firstFlg = true;



    [Header("カーソル移動の幅(7-3までなら7と書く)")]
    public int MaxCursor = 7;
    public int MinCursor = 1;

    //カーソル位置代入用
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

    //カメラ取得用
    private GameObject p;
    private Camera nowCamera;
    private float cameraSpeed = 1.0f;

    //時間取得用
    private float startTime;    //カーゾル移動の始まった時間
    private float ForcusStartTime;  //ステージ選択を決定した後のフォーカスが始まった時間
    public bool timeFlg = true;    //ステージ選択ごとにfocusさせていた時に使っていた


    float fadeS = 1.0f; //速度
    [Header("フェード設定")]
    public Image fade;
    public UnityEngine.Color color = new UnityEngine.Color(0, 0, 0, 0); //フェードの色

    private bool forcusFLg; //カーソル移動に伴うカメラの移動中に途中のカーソル変更をできなくする

    [Header("カメラ位置")]
    public int Zpos = 20;
    public int Xpos = 0;

    [Header("扉")]
    public float rotateSpeed = 100.0f;//回転速度
    public float MaxRotateRight = 10f;//回転の限界角度
    public float MaxRotateLeft = 350f;//回転の限界角度
    [SerializeField]

    private float rotateSpeedRight = 0f;  //扉の開くスピード
    private float rotateSpeedLeft = 0f;  //扉の開くスピード
    private float beforrotateSpeedRight = 0f;  //扉の閉じるスピード
    private float beforrotateSpeedLeft = 0f;  //扉の閉じるスピード
    private float closeendR = 0f;  //扉の閉じるスピード
    private float closeendL = 0f;  //扉の閉じるスピード

    //扉を開くアニメーション用
    private GameObject nowPos;
    private GameObject nowPosRight;
    private GameObject nowPosLeft;
    private GameObject beforPosRight;
    private GameObject beforPosLeft;
    private GameObject EndPosR;
    private GameObject EndPosL;

    /////////////澤野追記
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
        timeFlg = true;    //ステージ選択ごとにfocusさせていた時に使っていた
    }

    // Start is called before the first frame update
    void Start()
    {
        ///////////澤野追記
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
        timeFlg = true;    //ステージ選択ごとにfocusさせていた時に使っていた
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
        //↓

        //////////澤野追記
        bool rightflg = _RightMove.IsPressed();
        bool leftflg = _LeftMove.IsPressed();
        bool upflg = _UpMove.IsPressed();
        bool downflg = _DownMove.IsPressed();
        bool ketteiflg = _KetteiButtun.triggered;
        bool ESC = _ESCButtun.triggered;

        //下を押したら
        if (Input.GetKeyDown(KeyCode.DownArrow)||downflg==true && timeFlg)
        {
            //最初の一回だけ移動できる範囲の最低のステージが選択される
            if (firstFlg)
            {
                InowStage += (MinCursor * 10) + 1;
                firstFlg = false;//一回入ったらfalseに
                timeFlg = false;
                startTime = Time.time;
            }
            else
            {

                EndPosR = beforPosRight;//Pos更新
                EndPosL = beforPosLeft;
                if (EndPosR == nowPosRight)
                {
                    EndPosR = null;
                    EndPosL = null;
                }
                beforPosRight = nowPosRight;
                beforPosLeft = nowPosLeft;//ここまで

                ///////半開きなら閉じる時用に今の開き状態を引き継いでおく
                closeendR = beforrotateSpeedRight;
                closeendL = beforrotateSpeedLeft;
                beforrotateSpeedRight = rotateSpeedRight;
                beforrotateSpeedLeft = rotateSpeedLeft;
                rotateSpeedRight = 180;
                rotateSpeedLeft = 180;
                //縦のカーソル移動
                InowStage -= 10;
                //カーソルが範囲を超えたら範囲の逆側に移動
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

        //上を押したら
        if (Input.GetKeyDown(KeyCode.UpArrow) ||upflg==true&& timeFlg)
        {
            //最初の一回だけ移動できる範囲の最低のステージが選択される
            if (firstFlg)
            {
                InowStage += (MinCursor * 10) + 1;
                firstFlg = false;
                timeFlg = false;
                startTime = Time.time;
            }
            else
            {

                EndPosR = beforPosRight;//Pos更新
                EndPosL = beforPosLeft;
                if (EndPosR.transform == nowPosRight.transform)
                {
                    Debug.Log("とおおおおおおおおおおおおおおお");
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
                //縦のカーソル移動
                InowStage += 10;
                //カーソルが範囲を超えたら範囲の逆側に移動
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

        //右を押したら
        if (Input.GetKeyDown(KeyCode.RightArrow)||rightflg==true && timeFlg)
        {
            //最初の一回だけ移動できる範囲の最低のステージが選択される
            if (firstFlg)
            {
                InowStage += (MinCursor * 10) + 1;
                firstFlg = false;
                timeFlg = false;
                startTime = Time.time;
            }
            else
            {

                EndPosR = beforPosRight;//Pos更新
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
                //横のカーソル移動
                InowStage += 1;

                //1の位が3を超えたら1に戻す
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

        //左を押したら
        if (Input.GetKeyDown(KeyCode.LeftArrow)||leftflg==true && timeFlg)
        {
            //最初の一回だけ移動できる範囲の最低のステージが選択される
            if (firstFlg)
            {
                InowStage += (MinCursor * 10) + 1;
                firstFlg = false;
                timeFlg = false;
                startTime = Time.time;
            }
            else
            {

                EndPosR = beforPosRight;//Pos更新
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
                //横のカーソル移動
                InowStage -= 1;

                //1の位が1を下回ったら3に戻す
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



        //↑
        //==========================================================

        if (/*Input.GetKeyDown(KeyCode.Return)||*/ketteiflg==true && timeFlg && nowPos != null)
        {
            ForcusStartTime = Time.time;
            //フェード
            StartCoroutine(Fade());
        }

        if (/*Input.GetKeyDown(KeyCode.Escape)*/ESC==true && timeFlg)
        {
            SceneManager.LoadScene("title");
        }

    }

    //カーソル移動に伴ってステージの選択を変える
    private void CursorChange()
    {
        //最初の一回だけはステージ11が選択されるようにする
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
    //各ステージごとに選択されているときの処理を描く

    private void NowStage11()
    {

        //fade用の位置を格納する
        nowCameraFocus = Stage11.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door1-1/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door1-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door1-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage12()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage12.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door1-2/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door1-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door1-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage13()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage13.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door1-3/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door1-3/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door1-3/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage21()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage21.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door2-1/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door2-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door2-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage22()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage22.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door2-2/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door2-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door2-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage23()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage23.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door2-3/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door2-3/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door2-3/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage31()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage31.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door3-1/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door3-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door3-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage32()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage32.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door3-2/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door3-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door3-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage33()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage33.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door3-3/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door3-3/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door3-3/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();

    }
    private void NowStage41()
    {

        //fade用の位置を格納する
        nowCameraFocus = Stage41.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door4-1/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door4-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door4-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage42()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage42.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door4-2/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door4-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door4-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage43()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage43.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door4-3/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door4-3/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door4-3/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage51()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage51.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door5-1/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door5-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door5-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage52()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage52.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door5-2/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door5-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door5-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage53()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage53.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door5-3/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door5-3/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door5-3/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage61()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage61.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door6-1/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door6-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door6-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage62()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage62.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door6-2/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door6-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door6-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage63()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage63.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door6-3/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door6-3/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door6-3/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();

    }

    private void NowStage71()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage71.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door7-1/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door7-1/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door7-1/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage72()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage72.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door7-2/Double_Door");

        //選択されているステージのドアを開ける
        nowPosRight = GameObject.Find("door7-2/Double_Door/Double_Door_R");
        nowPosLeft = GameObject.Find("door7-2/Double_Door/Double_Door_L");
        OpenDoor();

        if (forcusFLg)
            FocusCamera();
    }

    private void NowStage73()
    {
        //fade用の位置を格納する
        nowCameraFocus = Stage73.transform.position;
        nowCameraFocus.x += Xpos;
        nowCameraFocus.z -= Zpos;

        nowPos = GameObject.Find("door7-3/Double_Door");

        //選択されているステージのドアを開ける
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
        //フェード用Panel有効
        fade.gameObject.SetActive(true);
        //透明度がなくなるまで
        while (fade.color.a <= 0.9f)
        {
            FadeCamera();//カメラを近づける
            fade.color = new UnityEngine.Color(color.r, color.g, color.b, fade.color.a + (fadeS * Time.deltaTime));//fade

            yield return null;//1f待機
        }

        //fadeが終わればシーンを移動させる
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

    //扉を開ける処理
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

    //扉を閉める
    private void CloseDoor()
    {


        rotateSpeedRight = 180;
        rotateSpeedLeft = 180;

        nowPosRight.transform.eulerAngles = new Vector3(0f, rotateSpeedRight, 0f);
        nowPosLeft.transform.eulerAngles = new Vector3(0f, rotateSpeedLeft, 0f);

    }

    //選択されているステージにカメラを近づける処理
    private void FocusCamera()
    {
        //選択されているステージのポジションを入れる
        Vector3 other = nowCameraFocus;

        //カメラと移動先の位置の距離
        float distanceTwo = Vector3.Distance(nowCamera.gameObject.transform.position, other);

        // 現在の位置
        float presentLocation = (Time.time - startTime * cameraSpeed) / distanceTwo;

        //移動させる処理
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

        //選択されているステージのポジションを入れる
        Vector3 other = nowPos.gameObject.transform.position;

        other.y += 3;


        //カメラと移動先の位置の距離
        float distanceTwo = Vector3.Distance(nowCamera.gameObject.transform.position, other);

        // 現在の位置
        float presentLocation = (Time.time - ForcusStartTime * cameraSpeed) / distanceTwo;

        //移動させる処理
        nowCamera.gameObject.transform.position = Vector3.Lerp(nowCamera.gameObject.transform.position, other, presentLocation);

        nowCamera.rect = new Rect(0.0f, 0.0f, 0.7f, 1.0f);


        if (nowCamera.gameObject.transform.position == other)
        {
            forcusFLg = false;
        }

    }
}
