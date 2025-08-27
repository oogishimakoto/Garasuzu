using UnityEngine;
using UnityEngine.SceneManagement;

public class cursor : MonoBehaviour
{
    private int cursorNo = 0;   //カーソル用変数
    private bool cursorflg = false; //カーソルフラグ
    private bool cursorFirstflg = true; //シーン移行された最初の状態でカーソルを表示ししない
    private int sceneNo = 1;    //シーン
     

    [Header("cursorの位置によって表示されるオブジェクト")]
    public GameObject ButtonObject1;
    public GameObject ButtonObject2;
    public GameObject ButtonObject3;
    public GameObject UILight;



    [Header("cursorの位置によって表示されるtext")]
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
        
        //ステージセレクト画面用
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
                    //対応した文字列表示
                    Stage1Text.SetActive(true);
                    Stage1Text2.SetActive(true);

                    Stage2Text.SetActive(false);
                    Stage2Text2.SetActive(false);

                    Stage3Text.SetActive(false);
                    Stage3Text2.SetActive(false);
                    //選択されているものを大きくする
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
                    //対応した文字列表示
                    Stage1Text.SetActive(false);
                    Stage1Text2.SetActive(false);

                    Stage2Text.SetActive(true);
                    Stage2Text2.SetActive(true);

                    Stage3Text.SetActive(false);
                    Stage3Text2.SetActive(false);

                    //選択されているものを大きくする
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
                    //対応した文字列表示
                    Stage1Text.SetActive(false);
                    Stage1Text2.SetActive(false);

                    Stage2Text.SetActive(false);
                    Stage2Text2.SetActive(false);

                    Stage3Text.SetActive(true);
                    Stage3Text2.SetActive(true);
                    //選択されているものを大きくする
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

        //ENTER押したら
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //sceneNoで現在のシーンを判断する
            //scene1
            if (sceneNo == 1)
            {
                //cursorNoで選択されているステージに飛ぶ
                if (cursorNo == 1)
                {
                    //シーン移行
                    SceneManager.LoadScene("1-1");
                }

                if (cursorNo == 2)
                {
                    //シーン移行
                    SceneManager.LoadScene("Title");
                }

                if (cursorNo == 3)
                {
                    //シーン移行
                    SceneManager.LoadScene("Title");
                }
            }

            //scene2
            if (sceneNo == 2)
            {
                Debug.Log(sceneNo);
                //cursorNoで選択されているステージに飛ぶ
                if (cursorNo == 1)
                {
                    Debug.Log(sceneNo);
                    //シーン移行
                    SceneManager.LoadScene("Title");
                }

                if (cursorNo == 2)
                {
                    Debug.Log(sceneNo);
                    //シーン移行
                    SceneManager.LoadScene("Title");
                }

                if (cursorNo == 3)
                {
                    Debug.Log(sceneNo);
                    //シーン移行
                    SceneManager.LoadScene("Title");
                }
            }

            //scene3
            if (sceneNo == 3)
            {
                //cursorNoで選択されているステージに飛ぶ
                if (cursorNo == 1)
                {
                    //シーン移行
                    SceneManager.LoadScene("Title");
                }

                if (cursorNo == 2)
                {
                    //シーン移行
                    SceneManager.LoadScene("Title");
                }

                if (cursorNo == 3)
                {
                    //シーン移行
                    SceneManager.LoadScene("Title");
                }
            }



        }

        //ENTER押したら
        if (Input.GetKeyDown(KeyCode.L))
        {
            sceneNo++;
            if (sceneNo > 3)
            {
                sceneNo = 1;
            }

            //sceneに対応したシーンに飛ぶ
            if (sceneNo == 1)
            {
                //シーン移行
                SceneManager.LoadScene("StageSelect");
            }

            if (sceneNo == 2)
            {
                //シーン移行
                SceneManager.LoadScene("StageSelect2");
            }

            if (sceneNo == 3)
            {
                //シーン移行
                SceneManager.LoadScene("StageSelect3");
            }
        }

        //ENTER押したら
        if (Input.GetKeyDown(KeyCode.K))
        {
            sceneNo--;
            if (sceneNo < 1)
            {
                sceneNo = 3;
            }

            //sceneに対応したシーンに飛ぶ
            if (sceneNo == 1)
            {
                //シーン移行
                SceneManager.LoadScene("StageSelect");
            }

            if (sceneNo == 2)
            {
                //シーン移行
                SceneManager.LoadScene("StageSelect2");
            }

            if (sceneNo == 3)
            {
                //シーン移行
                SceneManager.LoadScene("StageSelect3");
            }
        }


    }
}
