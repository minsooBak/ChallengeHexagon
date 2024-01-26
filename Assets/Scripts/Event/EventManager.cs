using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public enum WallEvent
{
    Damage,
    HP,
    HP_MAX,
    SPEED_P,
    SPEED_O,
    SCALE_P,
    MIRROR,
}

public class EventManager : MonoBehaviour
{

    public struct WallData
    {
        public WallEvent Type { get; set; }
        public float Data { get; set; }
    }
    private const int MAX_SIZE = 5;
    [SerializeField]private WallData[] _wallDatas = new WallData[MAX_SIZE];

    public int AddData(WallEvent type, float data)
    {
        for(int i = 0; i < MAX_SIZE; i++)
        {
            if (_wallDatas[i].Data == 0)
            {
                _wallDatas[i].Type = type;
                _wallDatas[i].Data = data;
                return i;
            }
        }
        Debug.Log("Wall Data Size out");
        return -1;
    }

    public WallData GetData(int index)
    {
        return _wallDatas[index];
    }

}
