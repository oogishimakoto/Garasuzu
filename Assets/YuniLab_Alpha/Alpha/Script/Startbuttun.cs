using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Startbuttun : MonoBehaviour
{
    // Start is called before the first frame update

    private float i;
    [Header("遷移するシーン")]
    public string NextScene = "select3D";


    [Header("何秒後に遷移しますかああああ？？？")]
    [SerializeField]
    float WaitTime = 1.0f;
    float Count = 0.0f;
    bool cntflg = false;

    private InputAction gameStart;
    private InputActionMap TitleSet;
    private PlayerInput TitleInput;
    public void SetNextScene(string nextScene)
    {
        NextScene = nextScene;
    }

    void Start()
    {
        i = 1;
        if (NextScene == null)
        {
            NextScene = "select3D";
        }
        TitleInput = GetComponent<PlayerInput>();
        if(TitleInput == null) { Debug.LogError("ねぇよ！"); }
        TitleSet = TitleInput.currentActionMap;
        gameStart = TitleSet["Start"];
        if (gameStart == null) { Debug.LogError("ねぇよ！（マジギレ）"); }

    }

    // Update is called once per frame
    void Update()
    {
        bool starton = gameStart.IsPressed();
        Debug.Log("あふぉ" + starton);
        if (cntflg == true)
        {
            Count += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.O) || starton==true)
        {
            cntflg = true;
        }
        if (WaitTime < Count)
        {
            SceneManager.LoadScene(NextScene);
        }
    }
}
