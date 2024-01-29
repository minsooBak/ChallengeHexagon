using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreText : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;

    private void Update()
    {
        bestScoreText.text = "Best Score : " + GameManager.I.bestScore.ToString("F2");
    }
}
