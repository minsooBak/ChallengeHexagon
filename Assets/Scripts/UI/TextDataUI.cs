using UnityEngine;

public class TextDataUI : MonoBehaviour
{
    private SaveData _saveData;

    public int Gold { get { return _saveData.gold; } set { _saveData.gold += value; } }
    public int HPPotion { get { return _saveData.healingPotion; } set { _saveData.healingPotion += value; } }

    protected virtual void Start()
    {
        _saveData = GameManager.I.GetComponent<SaveDatas>()._saveData;
    }

    protected float GetBestLifeTime()
    {
        return _saveData.bestLifeTime;
    }
}
