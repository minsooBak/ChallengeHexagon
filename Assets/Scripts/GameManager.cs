using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public bool isGameOver = false;

    public GameObject InGameUI;
    public GameObject GameOverUI;
    public GameObject GameOverButton;

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
    }

    private void Update()
    {
        if (isEvent)
        {
            _objectManager.SettingEvent(WallEventData.WallEvent.HP, 10);
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
