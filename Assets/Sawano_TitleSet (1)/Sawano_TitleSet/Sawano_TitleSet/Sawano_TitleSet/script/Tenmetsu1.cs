using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tenmetsu1 : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshRenderer mr;
    [Header("�_�ł̊Ԋu(�b)")]
    public float TenmetsuKankaku;
    private bool Skelton;
    private float i;
    [Header("�J�ڂ���V�[��")]
    public string NextScene= "select3D";

    public void SetNextScene(string nextScene)
    {
        NextScene=nextScene;
    }

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        if (mr == null) { Debug.LogError("Mesh���Ȃ���"); }
        Skelton = false;
        i = 1;
        if (NextScene == null)
        {
            NextScene = "select3D";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (1 <= i / TenmetsuKankaku)
        {
            if (Skelton == true)
            {
                mr.material.color = mr.material.color + new Color32(0, 0, 0, 255 / 120);
            }
            else if (Skelton == false)
            {
                mr.material.color = mr.material.color - new Color32(0, 0, 0, 255 / 120);
            }

            if (mr.material.color.a <= 0)
            {
                Skelton = true;
            }
            else if (mr.material.color.a >= 1)
            {
                Skelton = false;
             
            }
            i = 1;
        }
        else
        {
            i++;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(NextScene);
        }
    }
}
