using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffMate_Select : MonoBehaviour
{
    private SaveSystem System => SaveSystem.Instance;  //メソッド省略
    private UserData Data => System.UserData;          //メソッド省略

    [Header("ステージ番号(i-j)")]
    public int i, j;

    [Header("置き換えるやーつ")]
    [SerializeField]
    Material matetya;
    MeshRenderer mr;

    [Header("鍵のおなまえ")]
    public string KeyName;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        if (mr == null)
        {
            Debug.LogError("らいとがありましぇえええん");
        }
        if(matetya==null)
        {
            Debug.LogError("マテ茶がありま村");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Data.StageClearAll[i-1,j-1] == true)////鍵を取る(絶縁ガラスを割る?)
        {
            mr.material = matetya;//マテリアルを置き換える
        }
    }
}
