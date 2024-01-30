using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject button;

    public void GoMenuScene()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
}
