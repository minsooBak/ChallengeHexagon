using System.IO;
using UnityEngine;

public class B_GameManager : MonoBehaviour
{
    public SaveData saveData;

    [ContextMenu("To Json Data")]
    void SaveData()
    {
        string jsonData = JsonUtility.ToJson(saveData, true);
        string path = Path.Combine(Application.dataPath, "SaveData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadData()
    {
        string path = Path.Combine(Application.dataPath, "SaveData.json");
        string jsonData = File.ReadAllText(path);
        saveData =  JsonUtility.FromJson<SaveData>(jsonData);
    }
}
[System.Serializable]
public class SaveData
{
    public float bestLiteTime;
}

