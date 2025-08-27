using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class openFlg : MonoBehaviour
{
    // Player�̓V���O���g���ɂ��Ƃ�
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
    private SaveSystem System => SaveSystem.Instance;  //���\�b�h�ȗ�
    private UserData Data => System.UserData;          //���\�b�h�ȗ�
    private float rotate = 180f;  //���̊J���X�s�[�h
    public float rotateSpeed = 10.0f;//��]���x
    public float startrotate = 270f;  //���̊J���X�s�[�h
    public float MaxRotate = 10f;//��]�̌��E�p�x
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
            Debug.Log("���W�b�h�{�f�B������܂���������������");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "OpenTheDoor")
        {
            flg = true;
            Data.Pos = Player.Instance.transform.position;  // �|�W�V������ۑ�
            SaveSystem.Instance.Save();                     // ���\�b�h�ۑ�
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
