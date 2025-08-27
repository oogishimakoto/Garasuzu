using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;

    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    [SerializeField] List<SESoundData> seSoundDatas;

    public float masterVolume = 1;      // �S�̂̉���
    public float bgmMasterVolume = 1;   // BGM����
    public float seMasterVolume = 1;    // SE����

    // �V���O���g��
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

    // BGM�Đ�
    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);    // �����f�[�^���Z�b�g
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;   // ����
        bgmAudioSource.Play();  // �Đ�

    }
    // BGM�I��
    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }
    // �Đ����Ԃ��擾
    public float GetTimeBGM()
    {
        return bgmAudioSource.time;
    }
    // �Đ����Ԃ��擾
    public void SetTimeBGM(float time)
    {
        bgmAudioSource.time = time;
    }

    // SE�Đ�
    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
    }
    // SE�̃s�b�`�ύX�i�A�����Ɏg�p�\��j
    public void PitchSetSE(float pitch)
    {
        seAudioSource.pitch = pitch;
    }
    // �Đ������ǂ�����Ԃ�
    public bool GetIsPlayingSE()
    {
        return seAudioSource.isPlaying;
    }
}

[System.Serializable]
public class BGMSoundData
{
    // BGM�p�񋓑�
    public enum BGM
    {
        Empty,  // �����
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
    // SE�p�񋓑�
    public enum SE
    {
        empty, // �����
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