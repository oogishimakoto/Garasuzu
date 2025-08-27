// UserData�̃C���X�^���X�𕶎���ɕϊ����邽�߂�Script
// �t�@�C���̏�������
// �t�@�C���̃��[�h
// ���[�h��userData�̃C���X�^���X�ɕ���������
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem
{
    // �V���O���g���ō��B
    #region Singleton
    private static SaveSystem instance = new SaveSystem();
    public static SaveSystem Instance => instance;
    #endregion
    private SaveSystem() { Load(); }                           // �R���X�g���N�^

    public string Path => Application.dataPath + "/data.json"; // asset�t�H���_�ɕۑ���ɂ��Ƃ�

    public UserData UserData { get; private set; }                      // �Q�b�^�[�A�Z�b�^�[

    public void Save()
    {
        string jsonData = JsonUtility.ToJson(UserData);

        StreamWriter writer = new StreamWriter(Path, false);  // �����f�[�^������ꍇ�㏑������B
        writer.WriteLine(jsonData);                           // �f�[�^���L��
        writer.Flush();                                       // ���������c�����L�����ꍇ
        writer.Close();                                       // �t�@�C�������
    }
    public void Load()
    {
        if (!File.Exists(Path))                                 //  �Z�[�u�f�[�^��������΃��[�h�ł��Ȃ���I
        {
            Debug.Log("����N����");                            //  ����N�����m�F���O
            UserData = new UserData();
            Save();
            return;
        }
        // �Z�[�u�f�[�^�̃��[�h���s���B
        StreamReader reader = new StreamReader(Path);           // �t�@�C����ǂ�
        string jusonData = reader.ReadToEnd();                  // �t�@�C����ǂނ�ŃC���X�^���X�ɂ���
        UserData = JsonUtility.FromJson<UserData>(jusonData);   // �ǂݍ��񂾂��̂�����
        reader.Close();                                         // �t�@�C�������
    }
}
