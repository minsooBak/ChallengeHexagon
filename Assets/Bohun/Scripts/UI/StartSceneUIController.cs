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
    }    
    public void ShopExitButtonClick()
    {
        _mainUI.SetActive(true);
        _shopUI.SetActive(false);
    }

    public void ShowAudioSetting()
    {
        AudioManager.instance.SFXPlay(SFX.UI_SELECT);
        _audioUI.SetActive(true);
    }

    public void HideAudioSetting()
    {
        AudioManager.instance.SFXPlay(SFX.UI_SELECT);
        _audioUI.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Player");
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
    }
}
