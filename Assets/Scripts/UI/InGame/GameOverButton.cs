using UnityEngine;
using UnityEngine.UI;

public class GameOverButton : MonoBehaviour
{
    public Button button;

    public void OnClick()
    {
        MakeGameOver();
    }

    private void MakeGameOver()
    {
        GameManager.I.isGameOver = true;
    }
}
