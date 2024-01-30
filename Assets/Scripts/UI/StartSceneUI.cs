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
    [SerializeField] private Text _inputField;

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
        GameManager.I.AudioManager.SFXPlay(SFX.UI_SELECT);
    }

    public void ShopExitButtonClick()
    {
        _mainUI.SetActive(true);
        _shopUI.SetActive(false);
        GameManager.I.AudioManager.SFXPlay(SFX.UI_SELECT);
    }

    public void ShowAudioSetting()
    {
        _audioUI.SetActive(true);
        GameManager.I.AudioManager.SFXPlay(SFX.UI_SELECT);
    }

    public void HideAudioSetting()
    {
        _audioUI.SetActive(false);
        GameManager.I.AudioManager.SFXPlay(SFX.UI_SELECT);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Player");
        GameManager.I.PlayerManager.PlayerName = _inputField.text;
        GameManager.I.AudioManager.SFXPlay(SFX.ROUND_START);
        GameManager.I.AudioManager.BGMChange(BGM.ROUND);
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
        GameManager.I.AudioManager.SFXPlay(SFX.UI_SELECT);
    }
}
