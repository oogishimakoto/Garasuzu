using UnityEngine;
using UnityEngine.SceneManagement;

public class cursor : MonoBehaviour
{
    private int cursorNo = 0;   //�J�[�\���p�ϐ�
    private bool cursorflg = false; //�J�[�\���t���O
    private bool cursorFirstflg = true; //�V�[���ڍs���ꂽ�ŏ��̏�ԂŃJ�[�\����\�������Ȃ�
    private int sceneNo = 1;    //�V�[��
     

    [Header("cursor�̈ʒu�ɂ���ĕ\�������I�u�W�F�N�g")]
    public GameObject ButtonObject1;
    public GameObject ButtonObject2;
    public GameObject ButtonObject3;
    public GameObject UILight;



    [Header("cursor�̈ʒu�ɂ���ĕ\�������text")]
    public GameObject Stage1Text;
    public GameObject Stage1Text2;
    public GameObject Stage2Text;
    public GameObject Stage2Text2;
    public GameObject Stage3Text;
    public GameObject Stage3Text2;

    // Start is called before the first frame update
    void Start()
    {

        if (SceneManager.GetActiveScene().name == "StageSelect")
        {
           
            sceneNo = 1;
        }

        if (SceneManager.GetActiveScene().name == "StageSelect2")
        {
            sceneNo = 2;
        }

        if (SceneManager.GetActiveScene().name == "StageSelect3")
        {
            sceneNo = 3;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            cursorNo += 1;
            cursorflg = true;
            if (cursorFirstflg)
            {
                cursorNo = 1;
                cursorFirstflg = false;
                UILight.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cursorNo -= 1;
            cursorflg = true;

            if (cursorFirstflg)
            {
                cursorNo = 1;
                cursorFirstflg = false;
                UILight.SetActive(true);
            }
        }
        
        //�X�e�[�W�Z���N�g��ʗp
        if (sceneNo > 0 && sceneNo < 4)
        {
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
                    //�Ή�����������\��
                    Stage1Text.SetActive(true);
                    Stage1Text2.SetActive(true);

                    Stage2Text.SetActive(false);
                    Stage2Text2.SetActive(false);

                    Stage3Text.SetActive(false);
                    Stage3Text2.SetActive(false);
                    //�I������Ă�����̂�傫������
                    if (cursorflg)
                    {
                        ButtonObject2.gameObject.transform.localScale = ButtonObject1.gameObject.transform.localScale;
                        ButtonObject3.gameObject.transform.localScale = ButtonObject1.gameObject.transform.localScale;
                        ButtonObject1.gameObject.transform.localScale = new Vector3(1.2f, 11f, 1.2f);
                        UILight.gameObject.transform.position = ButtonObject1.gameObject.transform.position;
                       cursorflg = false;
                    }
                }

                if (cursorNo == 2)
                {
                    //�Ή�����������\��
                    Stage1Text.SetActive(false);
                    Stage1Text2.SetActive(false);

                    Stage2Text.SetActive(true);
                    Stage2Text2.SetActive(true);

                    Stage3Text.SetActive(false);
                    Stage3Text2.SetActive(false);

                    //�I������Ă�����̂�傫������
                    if (cursorflg)
                    {
                        ButtonObject1.gameObject.transform.localScale = ButtonObject2.gameObject.transform.localScale;
                        ButtonObject3.gameObject.transform.localScale = ButtonObject2.gameObject.transform.localScale;
                        ButtonObject2.gameObject.transform.localScale = new Vector3(1.2f, 11f, 1.2f);
                        UILight.gameObject.transform.position = ButtonObject2.gameObject.transform.position;
                        cursorflg = false;
                    }
                }

                if (cursorNo == 3)
                {
                    //�Ή�����������\��
                    Stage1Text.SetActive(false);
                    Stage1Text2.SetActive(false);

                    Stage2Text.SetActive(false);
                    Stage2Text2.SetActive(false);

                    Stage3Text.SetActive(true);
                    Stage3Text2.SetActive(true);
                    //�I������Ă�����̂�傫������
                    if (cursorflg)
                    {
                        ButtonObject1.gameObject.transform.localScale = ButtonObject3.gameObject.transform.localScale;
                        ButtonObject2.gameObject.transform.localScale = ButtonObject3.gameObject.transform.localScale;
                        ButtonObject3.gameObject.transform.localScale = new Vector3(1.2f, 11f, 1.2f);
                        UILight.gameObject.transform.position = ButtonObject3.gameObject.transform.position;
                        cursorflg = false;
                    }
                }
            }
        }

        //ENTER��������
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //sceneNo�Ō��݂̃V�[���𔻒f����
            //scene1
            if (sceneNo == 1)
            {
                //cursorNo�őI������Ă���X�e�[�W�ɔ��
                if (cursorNo == 1)
                {
                    //�V�[���ڍs
                    SceneManager.LoadScene("1-1");
                }

                if (cursorNo == 2)
                {
                    //�V�[���ڍs
                    SceneManager.LoadScene("Title");
                }

                if (cursorNo == 3)
                {
                    //�V�[���ڍs
                    SceneManager.LoadScene("Title");
                }
            }

            //scene2
            if (sceneNo == 2)
            {
                Debug.Log(sceneNo);
                //cursorNo�őI������Ă���X�e�[�W�ɔ��
                if (cursorNo == 1)
                {
                    Debug.Log(sceneNo);
                    //�V�[���ڍs
                    SceneManager.LoadScene("Title");
                }

                if (cursorNo == 2)
                {
                    Debug.Log(sceneNo);
                    //�V�[���ڍs
                    SceneManager.LoadScene("Title");
                }

                if (cursorNo == 3)
                {
                    Debug.Log(sceneNo);
                    //�V�[���ڍs
                    SceneManager.LoadScene("Title");
                }
            }

            //scene3
            if (sceneNo == 3)
            {
                //cursorNo�őI������Ă���X�e�[�W�ɔ��
                if (cursorNo == 1)
                {
                    //�V�[���ڍs
                    SceneManager.LoadScene("Title");
                }

                if (cursorNo == 2)
                {
                    //�V�[���ڍs
                    SceneManager.LoadScene("Title");
                }

                if (cursorNo == 3)
                {
                    //�V�[���ڍs
                    SceneManager.LoadScene("Title");
                }
            }



        }

        //ENTER��������
        if (Input.GetKeyDown(KeyCode.L))
        {
            sceneNo++;
            if (sceneNo > 3)
            {
                sceneNo = 1;
            }

            //scene�ɑΉ������V�[���ɔ��
            if (sceneNo == 1)
            {
                //�V�[���ڍs
                SceneManager.LoadScene("StageSelect");
            }

            if (sceneNo == 2)
            {
                //�V�[���ڍs
                SceneManager.LoadScene("StageSelect2");
            }

            if (sceneNo == 3)
            {
                //�V�[���ڍs
                SceneManager.LoadScene("StageSelect3");
            }
        }

        //ENTER��������
        if (Input.GetKeyDown(KeyCode.K))
        {
            sceneNo--;
            if (sceneNo < 1)
            {
                sceneNo = 3;
            }

            //scene�ɑΉ������V�[���ɔ��
            if (sceneNo == 1)
            {
                //�V�[���ڍs
                SceneManager.LoadScene("StageSelect");
            }

            if (sceneNo == 2)
            {
                //�V�[���ڍs
                SceneManager.LoadScene("StageSelect2");
            }

            if (sceneNo == 3)
            {
                //�V�[���ڍs
                SceneManager.LoadScene("StageSelect3");
            }
        }


    }
}
