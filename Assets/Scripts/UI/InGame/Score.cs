using UnityEngine;
using TMPro;

public class Score : TextBaseUI
{
    [SerializeField] private GameObject resultUI;

    [SerializeField] private TextMeshProUGUI _inGameScoreText;
    [SerializeField] private TextMeshProUGUI _inGameBestScoreText;
    [SerializeField] private TextMeshProUGUI _currentRecordText;
    [SerializeField] private TextMeshProUGUI _resultBestScoreText;

    [SerializeField] private TextMeshProUGUI levelText;

    private SaveData saveData;
    private Stage _stage;

    protected override void Start()
    {
        base.Start();
        saveData = GameObject.Find("SaveData").GetComponent<SaveData>();
        _stage = _gameManager.gameObject.GetComponent<Stage>();
        _gameManager.OnGame += UpdateText;
        _gameManager.EndGame += EndText;
    }

    private void UpdateText()
    {
        levelText.text = $"Level " + (int)_stage._level + " | " + _stage._level.ToString().ToUpper();
        saveData.bestLifeTime = _gameManager.lifeTime > saveData.bestLifeTime ? _gameManager.lifeTime : saveData.bestLifeTime;
        _inGameScoreText.text = _gameManager.lifeTime.ToString("F2");
        _inGameBestScoreText.text = "Best Score : " + saveData.bestLifeTime;
    }

    private void EndText()
    {
        Active(resultUI);
        saveData.bestLifeTime = _gameManager.lifeTime > saveData.bestLifeTime ? _gameManager.lifeTime : saveData.bestLifeTime;
        _currentRecordText.text = _gameManager.lifeTime.ToString("F2");
        _resultBestScoreText.text = "Best Score : " + saveData.bestLifeTime;
    }
}
