using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]private List<WallEventData<float>> _wallDatas;
    private const int MaxSize = 5;
    

    private void Start()
    {
        _wallDatas = new List<WallEventData<float>>(MaxSize);
        for(int i = 0; i < MaxSize; i++)
        {
            _wallDatas[i] = ScriptableObject.CreateInstance<WallEventData<float>>();
        }
    }

    public int AddData(WallEvent type, float data)
    {
        for(int i = 0; i < MaxSize; i++)
        {
            if (_wallDatas[i].data == 0)
            {
                _wallDatas[i].type = type;
                _wallDatas[i].data = data;
                return i;
            }
        }
        Debug.Log("Wall Data Size out");
        return -1;
    }

    public WallEventData<float> GetData(int index)
    {
        return _wallDatas[index];
    }

}
