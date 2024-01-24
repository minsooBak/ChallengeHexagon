using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public Text levelText;

    private int levelNum;
    private string levelName;

    private void Update()
    {
        UpdateLevelVar();
        UpdateLevelText();
    }

    private void UpdateLevelVar()
    {
        levelNum = (int)GameManager.I.level;
        levelName = GameManager.I.level.ToString();
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level " + levelNum + " | " + levelName;
    }
}
