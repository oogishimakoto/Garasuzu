using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffLight : MonoBehaviour
{

    public Light thislight;
    GameObject Key;
    openFlg of;

    // Start is called before the first frame update
    void Start()
    {
        thislight= GetComponent<Light>();
        if (thislight == null)
        {
            Debug.Log("�炢�Ƃ�����܂�����������");
        }
        Key = GameObject.Find("Key");
        if (Key == null)
        {
            Debug.Log("Key������܂���");
        }
        of = Key.GetComponent<openFlg>();
        if (of == null)
        {
            Debug.Log("of������܂���");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (of.flg == true)
        {
            thislight.enabled = true;
        }
    }
}
