using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneUIController : MonoBehaviour
{
    private SaveDatas _saveDatas;
    [SerializeField] private GameObject _mainUI;
    [SerializeField] private GameObject _shopUI;
    [SerializeField] private GameObject _audioUI;

    [SerializeField] private Text _shopGold;
    [SerializeField] private Text _healingPotion;

   
    private void Awake()
    {
        _saveDatas = GameObject.Find("SaveData").GetComponent<SaveDatas>();
        
    }


    public void ShopButtonClick()
    {
        _shopGold.text = "Gold" + _saveDatas._saveData.gold.ToString();
        _healingPotion.text = _saveDatas._saveData.healingPotion.ToString();
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
        AudioManager.instance.BGMChange(BGM.ROUND);
    }
    public void BuyHealingPition()
    {
        if (_saveDatas._saveData.gold >= 5)
        {
            _saveDatas._saveData.gold-=5;
            _saveDatas._saveData.healingPotion += 1;
            _shopGold.text = "Gold" + _saveDatas._saveData.gold.ToString();
            _healingPotion.text = _saveDatas._saveData.healingPotion.ToString();
            _saveDatas.SaveData();
        }
        AudioManager.instance.SFXPlay(SFX.UI_SELECT);
    }
}
