using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class openFlg : MonoBehaviour
{
    // Playerはシングルトンにしとく
    #region Singleton
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<Player>();
            {
                return instance;
            }
        }
    }
    #endregion
    private SaveSystem System => SaveSystem.Instance;  //メソッド省略
    private UserData Data => System.UserData;          //メソッド省略
    private float rotate = 180f;  //扉の開くスピード
    public float rotateSpeed = 10.0f;//回転速度
    public float startrotate = 270f;  //扉の開くスピード
    public float MaxRotate = 10f;//回転の限界角度
    public string openObjName = "Door (1)";

    public bool flg = false;

    private GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find(openObjName);
        rotate = startrotate;
    }

    // Update is called once per frame
    void Update()
    {

        if (flg)
        {

            Open();
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "OpenTheDoor")
        {
            flg = false;
        }
        else
        {
            Debug.Log("リジッドボディがありましぇえええええん");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "OpenTheDoor")
        {
            flg = true;
            Data.Pos = Player.Instance.transform.position;  // ポジションを保存
            SaveSystem.Instance.Save();                     // メソッド保存
        }
    }

    public void Open()
    {
        if (rotate > MaxRotate)
            rotate += rotateSpeed * Time.deltaTime;

        if (rotate > 360)
            rotate = 0;

        door.transform.eulerAngles = new Vector3(0f, rotate, 0f);
    }
}
