using UnityEngine;

public enum WallEvent
{
    None = -1,
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

    private const int MAX_SIZE = 30;
    private WallData[] _wallDatas = new WallData[MAX_SIZE];

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

    public int GetType(int index)
    {
        return (int)_wallDatas[index].Type;
    }

    public void DeleteData(int index)
    {
        _wallDatas[index].Data = 0;
    }

}
