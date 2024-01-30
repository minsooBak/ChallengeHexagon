using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public EventManager EventManager { get; private set; }
    public SaveData saveData;
    public bool isGameOver = false;

    [SerializeField] private GameObject InGameUI;
    [SerializeField] private GameObject GameOverUI;

    private ObjectManager _objectManager;
    private SaveDatas _saveData;

    public float lifeTime = 0f;
    public float bestScore;
    public Level level;
    public bool isEvent = false;

    public enum Level
    {
        point = 1,
        line,
        triangle,
        square,
        pentagon,
        hexagon,
    }

    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        _saveData = GameObject.Find("SaveData").GetComponent<SaveDatas>();
        EventManager = gameObject.AddComponent<EventManager>();
        bestScore = _saveData._saveData.bestLifeTime;
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
    }

    private void Update()
    {

        if (!isGameOver)
        {
            lifeTime += Time.deltaTime;
            LevelUpdater();
            if (_objectManager.CheckAnimationEnd())
                _objectManager.CheckOut();
            SetBestScore();
        }
        else
        {
            Time.timeScale = 0;
            _saveData._saveData.bestLifeTime = bestScore;
            CalGold(lifeTime);
            _saveData.SaveData();
            GameOverSequence();
        }
    }

    private void LevelUpdater()
    {
        switch (lifeTime)
        {
            case < 10f:
                {
                    level = Level.point;
                    Stage(Random.Range(0, 101));
                    break;
                }
            case < 20f:
                {
                    if (level == Level.point)
                    {
                        _objectManager.ObjectUpdate(4, 12, 7);
                        _objectManager.ChangeObject(1, false);
                    }
                    level = Level.line;
                    Stage(Random.Range(10, 101));
                    break;
                }
            case < 30f:
                {
                    if (level == Level.line)
                    {
                        _objectManager.ObjectUpdate(3, 15, 10);
                        _objectManager.ChangeObject(1, true);
                    }
                    level = Level.triangle;
                    Stage(Random.Range(20, 101));
                    break;
                }
            case < 45f:
                {
                    if (level == Level.triangle)
                    {
                        _objectManager.ObjectUpdate(2, 17, 15);
                        _objectManager.ChangeObject(1, false);
                        _objectManager.ChangeObject(2, false);
                    }
                    level = Level.square;
                    Stage(Random.Range(30, 101));
                    break;
                }
            case < 60f:
                {
                    if (level == Level.triangle)
                    {
                        _objectManager.ObjectUpdate(2, 20, 20);
                        _objectManager.ChangeObject(2, true);
                    }
                    level = Level.pentagon;
                    Stage(Random.Range(40, 101));
                    break;
                }
            case >= 60f:
                {
                    if (level == Level.triangle)
                    {
                        _objectManager.ObjectUpdate(1.5f, 20, 30);
                        _objectManager.ChangeObject(1, true);
                    }
                    level = Level.hexagon;
                    Stage(Random.Range(50, 101));
                    break;
                }
        }
    }

    private void SetBestScore()
    {
        if (lifeTime > bestScore)
        {
            bestScore = lifeTime;
        }
    }

    private void GameOverSequence()
    {
        InGameUI.SetActive(false);
        GameOverUI.SetActive(true);
    }

    public void RestartGameButton()
    {
        RestartGame();
    }
    public void GoToMainButton()
    {
        GoToMainScene();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Player");
    }

    private void GoToMainScene()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    private void CalGold(float time)
    {
        _saveData._saveData.gold += (int)time / 10;
    }


    private void Stage(int random)
    {
        if (random < 50 || isEvent)
        {
            return;
        }
        isEvent = true;
        _objectManager.SettingEvent(EventManager.AddData(WallEvent.Damage, 10 * (int)level));
        switch (random)
        {
            case < 75:
                {
                    int r = Random.Range(0, 2);
                    if (r == 0)
                    {
                        _objectManager.SettingEvent(EventManager.AddData(WallEvent.SPEED_O, 2 * (int)level));
                    }
                    else
                    {
                        _objectManager.SettingEvent(EventManager.AddData(WallEvent.SPEED_P, 10 * (int)level));
                    }
                    break;
                }
            case < 85:
                {
                    int r = Random.Range(0, 2);
                    if (r == 0)
                    {
                        _objectManager.SettingEvent(EventManager.AddData(WallEvent.HP, 10 * (int)level));
                    }
                    else
                    {
                        _objectManager.SettingEvent(EventManager.AddData(WallEvent.HP_MAX, 10 * (int)level));
                    }
                    break;
                }
            default:
                {
                    int r = Random.Range(0, 2);
                    if (r == 0)
                    {
                        _objectManager.SettingEvent(EventManager.AddData(WallEvent.MIRROR, 10 * (int)level));
                    }
                    else
                    {
                        _objectManager.SettingEvent(EventManager.AddData(WallEvent.Damage, 10 * (int)level));
                    }
                    break;
                }
        }
    }
}
