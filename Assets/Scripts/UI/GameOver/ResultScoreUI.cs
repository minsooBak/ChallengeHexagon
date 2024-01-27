using UnityEngine;
using UnityEngine.UI;

public class ResultScoreUI : MonoBehaviour
{
    public Text currentRecordText;
    public Text bestRecordText;

    private void Update()
    {
        currentRecordText.text = GameManager.I.lifeTime.ToString("F2") + " s";
        bestRecordText.text = GameManager.I.bestScore.ToString("F2") + " s";
    }
}
