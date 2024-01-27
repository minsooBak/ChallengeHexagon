using UnityEngine;
using UnityEngine.UI;

public class FinalLevelUI : MonoBehaviour
{
    public Text levelNumText;
    public Text levelStringText;
    public Image levelImage;

    private int levelNum;
    private Sprite[] polygons;

    private void Awake()
    {
        polygons = Resources.LoadAll<Sprite>("Sprites/UI/polygons");
    }

    private void Start()
    {

    }

    private void Update()
    {
        SetAllUIs();
        RotateLevelImage();
    }

    private void SetAllUIs()
    {
        levelNum = (int)GameManager.I.level;
        levelNumText.text = "Level " + levelNum.ToString();
        levelStringText.text = GameManager.I.level.ToString().ToUpper();
        levelImage.sprite = polygons[levelNum - 1];
    }

    private void RotateLevelImage()
    {
        levelImage.transform.Rotate(0.05f, 0.1f, 0f);
    }
}
