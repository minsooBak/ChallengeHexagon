using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoRankingButton : MonoBehaviour
{
    [SerializeField] private GameObject button;

    public void GoRankingScene()
    {
        SceneManager.LoadScene("RankingScene");
    }
}
