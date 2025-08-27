using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBGM : MonoBehaviour
{
    private static bool isJingleBegin = false; // �W���O�����Đ�������
    private static BGMSoundData.BGM nowScene = BGMSoundData.BGM.Empty; // ���݂̃V�[�� 
    private static BGMSoundData.BGM lastScene = BGMSoundData.BGM.Empty; // �O�̃V�[�� 


    float bgmTime = 0.0f;

    public static PlayBGM Instance;
    private void Awake()
    {
        // �V���O���g��
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        // ���݂̃V�[����Ԃ�ۑ�
        if (
            SceneManager.GetActiveScene().name == "1-1" |
            SceneManager.GetActiveScene().name == "1-2" |
            SceneManager.GetActiveScene().name == "1-3" |
            SceneManager.GetActiveScene().name == "2-1" |
            SceneManager.GetActiveScene().name == "2-2" |
            SceneManager.GetActiveScene().name == "2-3"
        )
        {
            nowScene = BGMSoundData.BGM.Stage1;
        }
        else if (
            SceneManager.GetActiveScene().name == "3-1" |
            SceneManager.GetActiveScene().name == "3-2" |
            SceneManager.GetActiveScene().name == "3-3" |
            SceneManager.GetActiveScene().name == "4-1" |
            SceneManager.GetActiveScene().name == "4-2" |
            SceneManager.GetActiveScene().name == "4-3"
        )
        {
            nowScene = BGMSoundData.BGM.Stage2;
        }
        else if (
           SceneManager.GetActiveScene().name == "5-1" |
           SceneManager.GetActiveScene().name == "5-2" |
           SceneManager.GetActiveScene().name == "5-3" |
           SceneManager.GetActiveScene().name == "6-1" |
           SceneManager.GetActiveScene().name == "6-2" |
           SceneManager.GetActiveScene().name == "6-3"

       )
        {
            nowScene = BGMSoundData.BGM.Stage3;
        }
        else if (
           SceneManager.GetActiveScene().name == "7-1" |
           SceneManager.GetActiveScene().name == "7-2" |
           SceneManager.GetActiveScene().name == "7-3" |
           SceneManager.GetActiveScene().name == "7-4" |
           SceneManager.GetActiveScene().name == "7-5" |
           SceneManager.GetActiveScene().name == "7-6"
       )
        {
            nowScene = BGMSoundData.BGM.Stage4;
        }
        else if (SceneManager.GetActiveScene().name == "title")
        {
            nowScene = BGMSoundData.BGM.Title;
        }
        else if (
            SceneManager.GetActiveScene().name == "select3D")
        {
            nowScene = BGMSoundData.BGM.Select;
        }




        // �O��ƈقȂ��
        if (nowScene != lastScene)
        {
            // ���݂̃V�[����BGM�Đ�
            SoundManager.Instance.PlayBGM(nowScene);
            lastScene = nowScene;
        }

        // ���U���g���
        if (SceneManager.GetActiveScene().name == "Result")
        {
            // �W���O���Đ��ς݂��Đ����I��������
            if (!SoundManager.Instance.GetIsPlayingSE() && isJingleBegin)
            {
                // �~�߂Ă���BGM���Đ�����
                SoundManager.Instance.SetTimeBGM(bgmTime);
                SoundManager.Instance.PlayBGM(lastScene);
                bgmTime = 0;
                SoundManager.Instance.SetTimeBGM(bgmTime);

                isJingleBegin = false;  // �W���O�����Đ���Ԃɖ߂�
            }
        }
        else
        {
            // �Đ��I����҂����ɃV�[���J�ڂ���Ə�Ԃ�߂��Ȃ��̂�
            isJingleBegin = false;
        }


    }
    public void PlayJingle()
    {

        // �W���O�����܂��Đ�����Ă��Ȃ�
        if (!isJingleBegin)
        {
            bgmTime = SoundManager.Instance.GetTimeBGM();
            SoundManager.Instance.StopBGM();// BGM���~�߂�
            SoundManager.Instance.PlaySE(SESoundData.SE.Jingle);// �W���O�����Đ�
            isJingleBegin = true;
        }
    }
}


