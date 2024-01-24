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

    public float lifeTime = 0f;
    public Level level;

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
    }

    private void Update()
    {
        if (!isGameOver)
        {
            lifeTime += Time.deltaTime;
            LevelUpdater();
        }
        else
        {
            GameOverSequence();
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

    private void GameOverSequence()
    {
        InGameUI.SetActive(false);
        GameOverButton.SetActive(false);
        GameOverUI.SetActive(true);
    }
}
