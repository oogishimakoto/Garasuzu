using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCursor : MonoBehaviour
{
    private int cursorNo = 0;   //カーソル用変数
    private bool cursorflg = false; //カーソルフラグ
    private bool cursorFirstflg = true; //シーン移行された最初の状態でカーソルを表示ししない

    [Header("Titleのcursorの位置")]
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

            //選択されているものを大きくする
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
            //選択されているものを大きくする
            if (cursorflg)
            {
                TitleButtonObject1.gameObject.transform.localScale = TitleButtonObject2.gameObject.transform.localScale;
                TitleButtonObject2.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                TitleUILight.gameObject.transform.position = TitleButtonObject2.gameObject.transform.position;
                cursorflg = false;
            }
        }

        //ENTER押したら
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //cursorNoで選択されているステージに飛ぶ
            if (cursorNo == 1)
            {
                //シーン移行
                SceneManager.LoadScene("StageSelect");
            }

            if (cursorNo == 2)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
            }

        }
    }
}
