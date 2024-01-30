using UnityEngine;

public class TextDataUI : MonoBehaviour
{
    private SaveData _saveData;

    public int Gold { get; set; }
    public int HPPotion { get; set; }

    protected virtual void Start()
    {
        _saveData = GameManager.I.GetComponent<SaveDatas>()._saveData;
    }

    protected float GetBestLifeTime()
    {
        return _saveData.bestLifeTime;
    }
}
