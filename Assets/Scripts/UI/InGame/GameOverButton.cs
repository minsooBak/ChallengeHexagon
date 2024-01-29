using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverButton : MonoBehaviour
{
    [SerializeField] private Button button;

    public void OnClick()
    {
        MakeGameOver();
    }

    private void MakeGameOver()
    {
        GameManager.I.isGameOver = true;
    }
}
