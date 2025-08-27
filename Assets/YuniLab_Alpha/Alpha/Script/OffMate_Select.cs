using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffMate_Select : MonoBehaviour
{
    private SaveSystem System => SaveSystem.Instance;  //���\�b�h�ȗ�
    private UserData Data => System.UserData;          //���\�b�h�ȗ�

    [Header("�X�e�[�W�ԍ�(i-j)")]
    public int i, j;

    [Header("�u���������[��")]
    [SerializeField]
    Material matetya;
    MeshRenderer mr;

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
        if(matetya==null)
        {
            Debug.LogError("�}�e��������ܑ�");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Data.StageClearAll[i-1,j-1] == true)////�������(�≏�K���X������?)
        {
            mr.material = matetya;//�}�e���A����u��������
        }
    }
}
