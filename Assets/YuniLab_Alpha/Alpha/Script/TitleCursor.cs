using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCursor : MonoBehaviour
{
    private int cursorNo = 0;   //�J�[�\���p�ϐ�
    private bool cursorflg = false; //�J�[�\���t���O
    private bool cursorFirstflg = true; //�V�[���ڍs���ꂽ�ŏ��̏�ԂŃJ�[�\����\�������Ȃ�

    [Header("Title��cursor�̈ʒu")]
    public GameObject TitleButtonObject1;
    public GameObject TitleButtonObject2;
    public GameObject TitleUILight;

    // Start is called before the first frame update
    void Start()
    {

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
                TitleUILight.SetActive(true);
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
                TitleUILight.SetActive(true);
            }
        }

        if (cursorNo > 2)
        {
            cursorNo = 1;
        }

        if (cursorNo < 1)
        {
            cursorNo = 2;
        }

        if (cursorNo == 1)
        {

            //�I������Ă�����̂�傫������
            if (cursorflg)
            {
                TitleButtonObject2.gameObject.transform.localScale = TitleButtonObject1.gameObject.transform.localScale;
                TitleButtonObject1.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                TitleUILight.gameObject.transform.position = TitleButtonObject1.gameObject.transform.position;
                cursorflg = false;
            }
        }

        if (cursorNo == 2)
        {
            //�I������Ă�����̂�傫������
            if (cursorflg)
            {
                TitleButtonObject1.gameObject.transform.localScale = TitleButtonObject2.gameObject.transform.localScale;
                TitleButtonObject2.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                TitleUILight.gameObject.transform.position = TitleButtonObject2.gameObject.transform.position;
                cursorflg = false;
            }
        }

        //ENTER��������
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //cursorNo�őI������Ă���X�e�[�W�ɔ��
            if (cursorNo == 1)
            {
                //�V�[���ڍs
                SceneManager.LoadScene("StageSelect");
            }

            if (cursorNo == 2)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
            }

        }
    }
}
