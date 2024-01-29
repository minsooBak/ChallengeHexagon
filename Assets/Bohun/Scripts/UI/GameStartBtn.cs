using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartBtn : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Player");
    }
}
