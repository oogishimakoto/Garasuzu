using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffLampMaterial : MonoBehaviour
{
    [Header("�u���������[��")]
    [SerializeField]
    Material matetya;
    MeshRenderer mr;
    GameObject Key;
    openFlg of;
    [Header("���̂��Ȃ܂�")]
    public string KeyName;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        if (mr == null)
        {
            Debug.LogError("�炢�Ƃ�����܂�����������");
        }
        Key = GameObject.Find(KeyName);
        if (Key == null)
        {
            Debug.LogError("Key������܂���");
        }
        of = Key.GetComponent<openFlg>();
        if (of == null)
        {
            Debug.LogError("of������܂���");
        }
        if(matetya==null)
        {
            Debug.LogError("�}�e��������ܑ�");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (of.flg == true)////�������(�≏�K���X������?)
        {
            mr.material = matetya;//�}�e���A����u��������
        }
    }
}
