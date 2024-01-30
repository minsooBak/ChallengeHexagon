using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartSceneUI : TextDataUI
{
    [SerializeField] private GameObject _mainUI;
    [SerializeField] private GameObject _shopUI;
    [SerializeField] private GameObject _audioUI;

    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitShop;
    [SerializeField] private Button _audioButton;
    [SerializeField] private Button _exitAudio;

    [SerializeField] private Button _hpPotionButton;

    [SerializeField] private TextMeshProUGUI _shopGold;
    [SerializeField] private TextMeshProUGUI _healingPotion;

    protected override void Start()
    {
        base.Start();
        _shopButton.onClick.AddListener(ShopButtonClick);
        _exitShop.onClick.AddListener(ShopExitButtonClick);
        _audioButton.onClick.AddListener(ShowAudioSetting);
        _exitAudio.onClick.AddListener(HideAudioSetting);
        _startButton.onClick.AddListener(StartGame);
        _hpPotionButton.onClick.AddListener(BuyHealingPition);
    }

    public void ShopButtonClick()
    {
        _shopGold.text = "Gold" + Gold.ToString();
        _healingPotion.text = HPPotion.ToString();
        _mainUI.SetActive(false);
        _shopUI.SetActive(true);
        AudioManager.instance.SFXPlay(SFX.UI_SELECT);
    }

    public void ShopExitButtonClick()
    {
        _mainUI.SetActive(true);
        _shopUI.SetActive(false);
        AudioManager.instance.SFXPlay(SFX.UI_SELECT);
    }

    public void ShowAudioSetting()
    {
        _audioUI.SetActive(true);
        AudioManager.instance.SFXPlay(SFX.UI_SELECT);
    }

    public void HideAudioSetting()
    {
        _audioUI.SetActive(false);
        AudioManager.instance.SFXPlay(SFX.UI_SELECT);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Player");
        AudioManager.instance.SFXPlay(SFX.ROUND_START);
        AudioManager.instance.BGMChange(BGM.ROUND_1);
    }
    public void BuyHealingPition()
    {
        if (Gold >= 5)
        {
            Gold -= 5;
            HPPotion += 1;
            _shopGold.text = "Gold" + Gold.ToString();
            _healingPotion.text = HPPotion.ToString();
        }
        AudioManager.instance.SFXPlay(SFX.UI_SELECT);
    }
}
