using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public enum BGM
{
    Lobby,
    ROUND_1,
}

public enum SFX
{
    UI_SELECT,
    ROUND_START,
    ROUND_END,
    DAMAGED,
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("#BGM")]
    [SerializeField] private AudioClip[] bgmClip;
    [SerializeField] private float bgmVolume;
    private AudioSource bgmPlayer;

    [Header("#SFX")]
    [SerializeField] private AudioClip[] sfxClips;
    [SerializeField] private float sfxVolume;
    [SerializeField] private int channels;
    private AudioSource[] sfxPlayers;
    private int sfxChannelIndex;


    [Header("AudioMixer")]
    [SerializeField] private AudioMixer _audioMixer;
    private AudioMixerGroup _bgmMixerGroup;
    private AudioMixerGroup _sfxMixerGroup;


    private void Awake()
    {
        if (instance == null)
        { 
            instance = this; 
        }
        else if(instance != this)
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(this);
        Init();
    }

    private void Start()
    {
        BGMPlay(BGM.Lobby);
    }

    private void Init()
    {
        // �����("BGM") �ͼ� �׷� ��������
        _bgmMixerGroup = _audioMixer.FindMatchingGroups("Master/BGM")[0];

        // ȿ����("SFX") �ͼ� �׷� ��������
        _sfxMixerGroup = _audioMixer.FindMatchingGroups("Master/SFX")[0];

        

        // ����� �ʱ�ȭ
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer =  bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.outputAudioMixerGroup = _bgmMixerGroup;

        // ȿ���� �ʱ�ȭ
        sfxPlayers = new AudioSource[channels];
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxChannelIndex = 0;
        

        for (int i = 0; i < sfxPlayers.Length; ++i)
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].loop = false;
            sfxPlayers[i].volume = sfxVolume;
            sfxPlayers[i].outputAudioMixerGroup = _sfxMixerGroup;
        }
    }

    public void SFXPlay(SFX sfx)
    {
        for(int i = 0; i < sfxPlayers.Length; ++i)
        {
            int loop = (i + sfxChannelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loop].isPlaying)
                continue;

            sfxChannelIndex = loop;
            sfxPlayers[loop].clip = sfxClips[(int)sfx];
            sfxPlayers[loop].Play();
            break;
        }
    }


    public void BGMPlay(BGM bgm)
    {
        bgmPlayer.clip = bgmClip[(int)bgm];
        bgmPlayer.Play();
    }

    public void BGMStop()
    {
        bgmPlayer.Stop();
    }

    public void BGMChange(BGM bgm)
    {
        bgmPlayer.Stop();
        bgmPlayer.clip = bgmClip[(int)bgm];
        bgmPlayer.Play();
    }

    public void ApplyLowPassFilter()
    {
        if (_audioMixer != null)
            _audioMixer.FindSnapshot("BGM_LowpassFilter").TransitionTo(0);
    }

    public void ResetAudioEffect()
    {
        if (_audioMixer != null)
            _audioMixer.FindSnapshot("Default2").TransitionTo(0f);
        else
            Debug.Log("������ ���� �Ұ�");
    }


}
