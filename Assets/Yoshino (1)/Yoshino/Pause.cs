using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    private int cursorNo = 0;   //�J�[�\���p�ϐ�
    private bool cursorflg = false; //�J�[�\���t���O
    private bool cursorFirstflg = true; //�V�[���ڍs���ꂽ�ŏ��̏�ԂŃJ�[�\����\�������Ȃ�

    public bool pauseflg = false;  //�|�[�Y��ʂ��J���Ă��邩

    [Header("cursor�̈ʒu")]
    public GameObject PauseButtonObject1;
    public GameObject PauseButtonObject2;
    public GameObject PauseButtonObject3;
    public GameObject PauseButtonLight;

    GameObject p;
    Player player;
    Rigidbody rb;

    [Header("�}�E�X�p")]
    public GameObject PanelObject;

    [SerializeField] Button ButtonObject1;
    [SerializeField] Button ButtonObject2;
    [SerializeField] Button ButtonObject3;


    bool a = false;

    /////////////////////�V��ǋL
    private PlayerInput PP;
    private InputActionMap PauseSet;
    private InputAction _Right;
    private InputAction _Left;
    private InputAction _The_World;
    private InputAction _Kettei;
    private InputAction _Back;

    // Start is called before the first frame update
    void Start()
    {
        //���\�b�h��o�^
        ButtonObject1.onClick.AddListener(Back);
        ButtonObject2.onClick.AddListener(restart);
        ButtonObject3.onClick.AddListener(select);

        p = GameObject.Find("AM_sikaberu_run");
        player = p.gameObject.GetComponent<Player>();
        rb = p.GetComponent<Rigidbody>();
        cursorNo = 1;

        //////////////////////////////�V��ǋL
        PP = GetComponent<PlayerInput>();
        PauseSet = PP.currentActionMap;
        _Right = PauseSet["Right"];
        _Left = PauseSet["Left"];
        _The_World = PauseSet["The_World"];
        _Kettei = PauseSet["Kettei"];
        _Back = PauseSet["Back"];
    }

    // Update is called once per frame
    void Update()
    {
        bool right = _Right.triggered;
        bool left = _Left.triggered;
        bool the_world = _The_World.triggered;
        bool kettei = _Kettei.triggered;
        bool back = _Back.triggered;

        //Escape��������
        if (player.The_World == true)
        {

            pauseflg = true;
            //�������тɋt�ɂȂ�
            //pauseflg= !pauseflg;

            ButtonObject1.gameObject.SetActive(pauseflg);
            ButtonObject2.gameObject.SetActive(pauseflg);
            ButtonObject3.gameObject.SetActive(pauseflg);
            PanelObject.SetActive(pauseflg);
            //player.SetTheWorld(!pauseflg);
        }
        else
        {
            pauseflg = false;
            ButtonObject1.gameObject.SetActive(pauseflg);
            ButtonObject2.gameObject.SetActive(pauseflg);
            ButtonObject3.gameObject.SetActive(pauseflg);
            PanelObject.SetActive(pauseflg);
        }
        if (pauseflg && player.The_World == true)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow) || right == true)
            {
                cursorNo += 1;
                cursorflg = true;
                if (cursorFirstflg)
                {
                    cursorNo = 1;
                    cursorFirstflg = false;
                    PauseButtonLight.SetActive(true);
                }
                SoundManager.Instance.PlaySE(SESoundData.SE.Cursor_M);

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || left == true)
            {
                cursorNo -= 1;
                cursorflg = true;

                if (cursorFirstflg)
                {
                    cursorNo = 1;
                    cursorFirstflg = false;
                    PauseButtonLight.SetActive(true);
                }
                SoundManager.Instance.PlaySE(SESoundData.SE.Cursor_M);

            }

            if (cursorNo > 3)
            {
                cursorNo = 1;
            }

            if (cursorNo < 1)
            {
                cursorNo = 3;
            }

            if (cursorFirstflg == false)
            {
                if (cursorNo == 1)
                {
                    //�I������Ă�����̂�傫������
                    if (cursorflg)
                    {
                        PauseButtonObject2.gameObject.transform.localScale = PauseButtonObject1.gameObject.transform.localScale;
                        PauseButtonObject3.gameObject.transform.localScale = PauseButtonObject1.gameObject.transform.localScale;
                        PauseButtonObject1.gameObject.transform.localScale = new Vector3(1.2f, 2.2f, 1.2f);
                        PauseButtonLight.gameObject.transform.position =
                            new Vector3(PauseButtonObject1.gameObject.transform.position.x, PauseButtonObject1.gameObject.transform.position.y + 175f, PauseButtonObject1.gameObject.transform.position.z);
                        cursorflg = false;
                    }
                }

                if (cursorNo == 2)
                {

                    //�I������Ă�����̂�傫������
                    if (cursorflg)
                    {
                        PauseButtonObject1.gameObject.transform.localScale = PauseButtonObject2.gameObject.transform.localScale;
                        PauseButtonObject3.gameObject.transform.localScale = PauseButtonObject2.gameObject.transform.localScale;
                        PauseButtonObject2.gameObject.transform.localScale = new Vector3(1.2f, 2.2f, 1.2f);
                        PauseButtonLight.gameObject.transform.position =
                            new Vector3(PauseButtonObject2.gameObject.transform.position.x, PauseButtonObject2.gameObject.transform.position.y + 175f, PauseButtonObject2.gameObject.transform.position.z);
                        cursorflg = false;
                    }
                }

                if (cursorNo == 3)
                {

                    //�I������Ă�����̂�傫������
                    if (cursorflg)
                    {
                        PauseButtonObject1.gameObject.transform.localScale = PauseButtonObject3.gameObject.transform.localScale;
                        PauseButtonObject2.gameObject.transform.localScale = PauseButtonObject3.gameObject.transform.localScale;
                        PauseButtonObject3.gameObject.transform.localScale = new Vector3(1.2f, 2.2f, 1.2f);
                        PauseButtonLight.gameObject.transform.position =
                            new Vector3(PauseButtonObject3.gameObject.transform.position.x, PauseButtonObject3.gameObject.transform.position.y + 175f, PauseButtonObject3.gameObject.transform.position.z);
                        cursorflg = false;
                    }
                }
            }

            ////////////////////////�V��ǋL
            if (back == true)
            {
                Back();
            }

            //ENTER��������
            if (Input.GetKeyDown(KeyCode.Return) || kettei == true)
            {
                SoundManager.Instance.PlaySE(SESoundData.SE.Cursor_D);

                if (cursorNo == 1)
                {
                    Back();
                }

                if (cursorNo == 2)
                {
                    restart();
                }

                if (cursorNo == 3)
                {
                    select();
                }
            }
        }
    }

    private void Back()
    {
        ButtonObject1.gameObject.SetActive(false);
        ButtonObject2.gameObject.SetActive(false);
        ButtonObject3.gameObject.SetActive(false);
        PanelObject.SetActive(false);
        player.SetTheWorld(false);
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        cursorNo = 1;
        Time.timeScale = 1;
    }



    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("Result");
        Back();
    }

    private void select()
    {
        //�V�[���ڍs
        SceneManager.LoadScene("select3D");
    }
}
