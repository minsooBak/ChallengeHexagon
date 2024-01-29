using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public SaveData saveData;

    public bool isGameOver = false;

    public EventManager EventManager { get; private set; }

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
            CheckAnyButtonInput();
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
                    level = Level.line;
                    Stage(Random.Range(10, 101));
                    _objectManager.ObjectUpdate(4, 15, 10);
                    break;
                }
            case < 30f:
                {
                    level = Level.triangle;
                    Stage(Random.Range(20, 101));
                    break;
                }
            case < 45f:
                {
                    level = Level.square;
                    Stage(Random.Range(30, 101));
                    break;
                }
            case < 60f:
                {
                    level = Level.pentagon;
                    Stage(Random.Range(40, 101));
                    break;
                }
            case >= 60f:
                {
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

    private void CheckAnyButtonInput()
    {
        if (Input.anyKeyDown)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Player");
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
                        _objectManager.SettingEvent(EventManager.AddData(WallEvent.SPEED_O, 10 * (int)level));
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
