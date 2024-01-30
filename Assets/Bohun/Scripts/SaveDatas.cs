using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDatas : MonoBehaviour
{
    public SaveData _saveData;
    public SaveRankingData _saveRanking;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        LoadData();
        LoadRankingData();
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

    [ContextMenu("To Json Ranking Data")]
    public void SaveRankingData()
    {
        string jsonData = JsonUtility.ToJson(_saveRanking, true);
        string path = Path.Combine(Application.dataPath, "SaveRankingData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Ranking Data")]
    public void LoadRankingData()
    {
        string path = Path.Combine(Application.dataPath, "SaveRankingData.json");
        if (!File.Exists(path))
        {
            Debug.Log("No File");
            _saveRanking = new SaveRankingData();
            return;
        }
        string jsonData = File.ReadAllText(path);

        _saveRanking = JsonUtility.FromJson<SaveRankingData>(jsonData);

        Debug.Log("Ranking Data");
        foreach (var item in _saveRanking.ranking)
        {
            Debug.Log(item.name + " : " + item.bestScore);
        }
    }

}

[System.Serializable]
public class SaveData
{
    public float bestLifeTime;
    public int gold;
    public int healingPotion;
}

[System.Serializable]
public class SaveRankingData
{ 
    public List<RankingData> ranking = new List<RankingData>();
}

[System.Serializable]
public class RankingData
{
    public string name;
    public float bestScore;
}

