using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneUIController : MonoBehaviour
{
    [SerializeField] private GameObject _mainUI;
    [SerializeField] private GameObject _shopUI;

    public void ShopButtonClick()
    {
        _mainUI.SetActive(false);
        _shopUI.SetActive(true);
    }    
    public void ShopExitButtonClick()
    {
        _mainUI.SetActive(true);
        _shopUI.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Player");
    }
}
