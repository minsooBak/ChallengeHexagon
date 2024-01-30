using UnityEngine;
using TMPro;

public class TextBaseUI : MonoBehaviour
{
    protected GameManager _gameManager;

    protected virtual void Start()
    {
        _gameManager = GameManager.I;
    }

    protected void UpdateText(TextMeshProUGUI text, string msg)

    {
        text.text = msg;
    }

    protected void ActiveText(GameObject obj, string msg)
    {
        obj.SetActive(true);
        obj.GetComponentInChildren<TextMeshProUGUI>().text = msg;
    }

    protected void Active(GameObject obj)
    {
        obj.SetActive(true);
    }

    protected void Disabled(GameObject obj)
    {
        obj.SetActive(false);
    }


}
