using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDatas : MonoBehaviour
{
   public SaveData _saveData;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        LoadData();
    }

    [ContextMenu("To Json Data")]
    public void SaveData()
    {
        string jsonData = JsonUtility.ToJson(_saveData, true);
        string path = Path.Combine(Application.dataPath, "SaveData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    public void LoadData() 
    {
        string path = Path.Combine(Application.dataPath, "SaveData.json");
        string jsonData = File.ReadAllText(path);
        _saveData = JsonUtility.FromJson<SaveData>(jsonData);
    }
}

[System.Serializable]
public class SaveData
{
    public float bestLifeTime;
    public int gold;
    public int healingPotion;
}
