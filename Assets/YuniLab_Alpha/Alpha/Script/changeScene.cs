using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�V�[�������[�h����
    public void LoadScene(string str)
    {
        SceneManager.LoadScene(str);//�V�[����ǂݍ���
    }

    //�Q�[���I������
    public void GameEnd()
    {
#if UNITY_EDITOR    //UnityEditor�ł̎��s�Ȃ�
        //�Đ����[�h����������
        UnityEditor.EditorApplication.isPlaying = false;
#else //UnityEditor�ł̎��s�łȂ���΁i���r���h��j�Ȃ�
        //�A�v���P�[�V�������I������
        Application.Quit();
#endif
    }
}
