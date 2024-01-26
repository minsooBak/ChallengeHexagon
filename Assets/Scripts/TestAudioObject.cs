using UnityEngine;

// 음원을 재생 테스트를 위한 테스트 클래스입니다.
public class TestAudioObject : MonoBehaviour
{
    AudioManager audioManager;

    void Start()
    {
        audioManager = AudioManager.instance;
    }

    public void PlayLobbyBGM()
    {
        audioManager.BGMPlay(BGM.Lobby);
    }

    public void PlayRoundBGM()
    {
        audioManager.BGMPlay(BGM.ROUND_1);
    }


    public void UISelect()
    {
        audioManager.SFXPlay(SFX.UI_SELECT);
    }

    public void RoundStart()
    {
        audioManager.SFXPlay(SFX.ROUND_START);
    }

    public void RoundEnd()
    {
        audioManager.SFXPlay(SFX.ROUND_END);
    }

    public void Damaged()
    {
        audioManager.SFXPlay(SFX.DAMAGED);
    }
}
