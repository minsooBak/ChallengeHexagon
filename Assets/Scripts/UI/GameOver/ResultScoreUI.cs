using UnityEngine;
using UnityEngine.UI;

public class ResultScoreUI : MonoBehaviour
{
    [SerializeField] private Text currentRecordText;
    [SerializeField] private Text bestRecordText;

    private void Update()
    {
        currentRecordText.text = GameManager.I.lifeTime.ToString("F2") + " s";
        bestRecordText.text = GameManager.I.bestScore.ToString("F2") + " s";
    }
}
