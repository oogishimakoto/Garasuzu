using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffLight_Select : MonoBehaviour
{
    private SaveSystem System => SaveSystem.Instance;  //メソッド省略
    private UserData Data => System.UserData;          //メソッド省略

    [Header("ステージ番号(i-j)")]
    public int i, j;

    public Light thislight;

    // Start is called before the first frame update
    void Start()
    {
        thislight= GetComponent<Light>();
        if (thislight == null)
        {
            Debug.Log("らいとがありましぇえええん");
        }
        thislight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Data.StageClearAll[i-1,j-1] == true)
        {
            thislight.enabled = true;
        }
    }
}
