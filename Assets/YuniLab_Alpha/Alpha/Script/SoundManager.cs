using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;

    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    [SerializeField] List<SESoundData> seSoundDatas;

    public float masterVolume = 1;      // 全体の音量
    public float bgmMasterVolume = 1;   // BGM音量
    public float seMasterVolume = 1;    // SE音量

    // シングルトン
    public static SoundManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // BGM再生
    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);    // 音声データをセット
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;   // 音量
        bgmAudioSource.Play();  // 再生

    }
    // BGM終了
    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }
    // 再生時間を取得
    public float GetTimeBGM()
    {
        return bgmAudioSource.time;
    }
    // 再生時間を取得
    public void SetTimeBGM(float time)
    {
        bgmAudioSource.time = time;
    }

    // SE再生
    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
    }
    // SEのピッチ変更（連鎖時に使用予定）
    public void PitchSetSE(float pitch)
    {
        seAudioSource.pitch = pitch;
    }
    // 再生中かどうかを返す
    public bool GetIsPlayingSE()
    {
        return seAudioSource.isPlaying;
    }
}

[System.Serializable]
public class BGMSoundData
{
    // BGM用列挙体
    public enum BGM
    {
        Empty,  // 空っぽ
        Title,
        Select,
        Stage1,
        Stage2,
        Stage3,
        Stage4,
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
    // SE用列挙体
    public enum SE
    {
        empty, // 空っぽ
        Cursor_C,
        Cursor_D,
        Cursor_M,
        Footstep_1,
        Footstep_2,
        Footstep_brake,
        GetCoin,
        GetSuzu,
        GlassBrake_1,
        GlassBrake_2,
        GlassBrake_3,
        Lading,
        SoundW_B,
        SoundW_Bl,
        SoundW_G,
        SoundW_R,
        SoundW_W,
        Jingle,
        Fall,
        Jump,
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}