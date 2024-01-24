using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultLevelText : MonoBehaviour
{
    public Text levelNumText;
    public Text levelStringText;

    private int levelNum;

    private void Start()
    {
        levelNum = (int)GameManager.I.level;
        levelNumText.text = "Level " + levelNum.ToString();
        levelStringText.text = GameManager.I.level.ToString().ToUpper();
    }
}
