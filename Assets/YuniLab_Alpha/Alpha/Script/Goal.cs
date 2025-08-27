using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private SaveSystem System => SaveSystem.Instance;  //���\�b�h�ȗ�
    private UserData Data => System.UserData;          //���\�b�h�ȗ�

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayBGM.Instance.PlayJingle();
        Data.StageClear = true;
        SceneManager.LoadScene("Result");
    }
}
