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
            Debug.Log("‚ç‚¢‚Æ‚ª‚ ‚è‚Ü‚µ‚¥‚¦‚¦‚¦‚ñ");
        }
        Key = GameObject.Find("Key");
        if (Key == null)
        {
            Debug.Log("Key‚ª‚ ‚è‚Ü‚»‚Ž");
        }
        of = Key.GetComponent<openFlg>();
        if (of == null)
        {
            Debug.Log("of‚ª‚ ‚è‚Ü‚»‚Ž");
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
