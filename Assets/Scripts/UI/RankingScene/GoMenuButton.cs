using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject button;

    public void GoMenuScene()
    {
        GameManager.I.AudioManager.SFXPlay(SFX.UI_SELECT);
        SceneManager.LoadScene("CharacterSelect");
    }
}
