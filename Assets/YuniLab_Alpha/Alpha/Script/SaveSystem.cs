// UserDataのインスタンスを文字列に変換するためのScript
// ファイルの書き込み
// ファイルのロード
// ロード後userDataのインスタンスに復元させる
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem
{
    // シングルトンで作る。
    #region Singleton
    private static SaveSystem instance = new SaveSystem();
    public static SaveSystem Instance => instance;
    #endregion
    private SaveSystem() { Load(); }                           // コンストラクタ

    public string Path => Application.dataPath + "/data.json"; // assetフォルダに保存先にしとく

    public UserData UserData { get; private set; }                      // ゲッター、セッター

    public void Save()
    {
        string jsonData = JsonUtility.ToJson(UserData);

        StreamWriter writer = new StreamWriter(Path, false);  // もしデータがある場合上書きする。
        writer.WriteLine(jsonData);                           // データを記入
        writer.Flush();                                       // もし書き残しが有った場合
        writer.Close();                                       // ファイルを閉じる
    }
    public void Load()
    {
        if (!File.Exists(Path))                                 //  セーブデータが無ければロードできないよ！
        {
            Debug.Log("初回起動時");                            //  初回起動時確認ログ
            UserData = new UserData();
            Save();
            return;
        }
        // セーブデータのロードを行う。
        StreamReader reader = new StreamReader(Path);           // ファイルを読む
        string jusonData = reader.ReadToEnd();                  // ファイルを読むんでインスタンスにする
        UserData = JsonUtility.FromJson<UserData>(jusonData);   // 読み込んだものを入れる
        reader.Close();                                         // ファイルを閉じる
    }
}
