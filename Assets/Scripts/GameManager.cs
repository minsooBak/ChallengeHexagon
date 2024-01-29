using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public bool isGameOver = false;

    public EventManager EventManager { get; private set; }

    [SerializeField] private GameObject InGameUI;
    [SerializeField] private GameObject GameOverUI;

    private ObjectManager _objectManager;

    public float lifeTime = 0f;
    public float bestScore = 0f;
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
        EventManager = gameObject.AddComponent<EventManager>();
    }

    private void Update()
    {
        if (isEvent)
        {
            _objectManager.SettingEvent(EventManager.AddData(WallEvent.HP, 10));
            _objectManager.SettingEvent(EventManager.AddData(WallEvent.HP_MAX, 10));
            _objectManager.SettingEvent(EventManager.AddData(WallEvent.Damage, 10));
            _objectManager.SettingEvent(EventManager.AddData(WallEvent.SPEED_P, 10));
            _objectManager.SettingEvent(EventManager.AddData(WallEvent.MIRROR, 10));

            isEvent = false;
        }

        if (!isGameOver)
        {
            lifeTime += Time.deltaTime;
            LevelUpdater();
        }
        else
        {
            SetBestScore();
            GameOverSequence();
            CheckAnyButtonInput();
        }
    }

    private void LevelUpdater()
    {
        if (lifeTime < 10f)
        {
            level = Level.point;
        }
        else if (lifeTime < 20f)
        {
            level = Level.line;
        }
        else if (lifeTime < 30f)
        {
            level = Level.triangle;
        }
        else if (lifeTime < 45f)
        {
            level = Level.square;
        }
        else if (lifeTime < 60f)
        {
            level = Level.pentagon;
        }
        else
        {
            level = Level.hexagon;
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
}
