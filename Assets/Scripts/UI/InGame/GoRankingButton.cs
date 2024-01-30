using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoRankingButton : MonoBehaviour
{
    [SerializeField] private GameObject button;

    public void GoRankingScene()
    {
        GameManager.I.AudioManager.SFXPlay(SFX.UI_SELECT);
        SceneManager.LoadScene("RankingScene");
    }
}
