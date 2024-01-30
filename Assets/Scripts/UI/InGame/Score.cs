using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : TextBaseUI
{
    [SerializeField] private GameObject resultUI;

    [SerializeField] private TextMeshProUGUI _inGameScoreText;
    [SerializeField] private TextMeshProUGUI _inGameBestScoreText;
    [SerializeField] private TextMeshProUGUI _currentRecordText;
    [SerializeField] private TextMeshProUGUI _resultBestScoreText;

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _homeButton;

    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private TextMeshProUGUI _resultLevelText;
    [SerializeField] private TextMeshProUGUI _resultNameText;
    [SerializeField] private Image _levelImage;
    private Sprite[] polygons;

    private SaveData saveData;
    private SaveRankingData saveRanking;
    private Stage _stage;
    private float bestScore;

    protected override void Start()
    {
        base.Start();
        saveData = GameManager.I.GetComponent<SaveDatas>()._saveData;
        saveRanking = GameManager.I.GetComponent<SaveDatas>()._saveRanking;
        _stage = GameObject.Find("Stage").GetComponent<Stage>();
        _gameManager.OnGame += UpdateText;
        _gameManager.EndGame += EndText;
        _restartButton.onClick.AddListener(Restart);
        _homeButton.onClick.AddListener(GoHome);
        polygons = Resources.LoadAll<Sprite>("Sprites/UI/polygons");
    }

    private void UpdateText()
    {
        levelText.text = $"Level " + (int)_stage._level + " | " + _stage._level.ToString().ToUpper();
        saveData.bestLifeTime = _gameManager.lifeTime > saveData.bestLifeTime ? _gameManager.lifeTime : saveData.bestLifeTime;
        _inGameScoreText.text = _gameManager.lifeTime.ToString("F2");
        LoadBestScore();
        _inGameBestScoreText.text = "Best Score : " + bestScore.ToString("F2");
    }

    private void EndText()
    {
        Active(resultUI);
        saveData.bestLifeTime = _gameManager.lifeTime > saveData.bestLifeTime ? _gameManager.lifeTime : saveData.bestLifeTime;
        _currentRecordText.text = _gameManager.lifeTime.ToString("F2");
        _resultBestScoreText.text = saveData.bestLifeTime.ToString("F2");
        _resultLevelText.text = "Level " + (int)_stage._level;
        _resultNameText.text = _stage._level.ToString().ToUpper();
        _levelImage.sprite = polygons[(int)_stage._level - 1];
    }

    private float LoadBestScore()
    {
        bestScore = 0f;
        var name = GameManager.I.PlayerManager.PlayerName;
        foreach (var item in saveRanking.ranking)
        {
            if (item.name == name)
            {
                bestScore = item.bestScore;
                break;
            }
        }
        return bestScore > saveData.bestLifeTime ? bestScore : saveData.bestLifeTime;
    }

    private void GoHome()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    private void Restart()
    {
        SceneManager.LoadScene("Player");
    }
}
