using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickDelete : MonoBehaviour
{
    [Header("マウス操作時用")]
    public GameObject deleteObject1;
    public GameObject deleteObject2;
    public GameObject deleteObject3;
    //public GameObject deleteObject4;
    //public GameObject deleteObject5;

    [SerializeField] Button Btn;

    private void Start()
    {
        Btn.onClick.AddListener(ActiveCreate);
        //Btn.onClick.AddListener(ActiveDelete);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {//左Clickで画像消去
            if (deleteObject1.activeSelf == true && deleteObject2.activeSelf == true && deleteObject3.activeSelf == true)
            {
                Invoke("ActiveDelete", 0.13f);
            }

        }
    }
    private void ActiveCreate()
    {
        if (deleteObject1.activeSelf == false && deleteObject2.activeSelf == false && deleteObject3.activeSelf == false)
        {
            deleteObject1.SetActive(true);
            deleteObject2.SetActive(true);
            deleteObject3.SetActive(true);
        }

    }

    private void ActiveDelete()
    {

        deleteObject1.SetActive(false);
        deleteObject2.SetActive(false);
        deleteObject3.SetActive(false);
    }
}
