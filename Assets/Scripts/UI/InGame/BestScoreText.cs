using UnityEngine;
using UnityEngine.UI;

public class BestScoreText : MonoBehaviour
{
    public Text bestScoreText;

    private void Update()
    {
        bestScoreText.text = "Best Score : " + GameManager.I.bestScore.ToString("F2");
    }
}
