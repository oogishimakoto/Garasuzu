using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffLampMaterial : MonoBehaviour
{
    [Header("置き換えるやーつ")]
    [SerializeField]
    Material matetya;
    MeshRenderer mr;
    GameObject Key;
    openFlg of;
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
        Key = GameObject.Find(KeyName);
        if (Key == null)
        {
            Debug.LogError("Keyがありまそｎ");
        }
        of = Key.GetComponent<openFlg>();
        if (of == null)
        {
            Debug.LogError("ofがありまそｎ");
        }
        if(matetya==null)
        {
            Debug.LogError("マテ茶がありま村");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (of.flg == true)////鍵を取る(絶縁ガラスを割る?)
        {
            mr.material = matetya;//マテリアルを置き換える
        }
    }
}
