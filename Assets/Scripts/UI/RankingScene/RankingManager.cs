using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    [SerializeField] private GameObject _rankingPrefab;
    [SerializeField] private GameObject _UI;
    private SaveDatas _saveData;
    private Transform _transform;
    private float newY;

    private void Awake()
    {
        _saveData = GameObject.Find("SaveData").GetComponent<SaveDatas>();
        _transform = _UI.GetComponent<Transform>();
    }

    private void Start()
    {
        MakeRankingList();
    }

    private void MakeRankingList()
    {
        for(int i = 0; i < _saveData._saveRanking.ranking.Count; i++)
        {
            GameObject ranking = Instantiate(_rankingPrefab, _transform);
            newY = _transform.position.y - i;
            ranking.transform.position += new Vector3(0f, newY, 0f);
            ranking.transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
            ranking.transform.GetChild(1).GetComponent<Text>().text = _saveData._saveRanking.ranking[i].name;
            ranking.transform.GetChild(2).GetComponent<Text>().text = _saveData._saveRanking.ranking[i].bestScore.ToString();
        }
    }
}
