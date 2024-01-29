using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public SaveData saveData;

    public bool isGameOver = false;

    public EventManager EventManager { get; private set; }

    [SerializeField] private GameObject InGameUI;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject GameOverButton;

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

    [ContextMenu("To Json Data")]
    void SaveData()
    {
        string jsonData = JsonUtility.ToJson(saveData, true);
        string path = Path.Combine(Application.dataPath, "SaveData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadData()
    {
        string path = Path.Combine(Application.dataPath, "SaveData.json");
        string jsonData = File.ReadAllText(path);
        saveData = JsonUtility.FromJson<SaveData>(jsonData);
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
        GameOverButton.SetActive(false);
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
        lifeTime = 0f;
        isGameOver = false;
        InGameUI.SetActive(true);
        GameOverButton.SetActive(true);
        GameOverUI.SetActive(false);
    }

}

[System.Serializable]
public class SaveData
{
    public float bestLiteTime;
}


