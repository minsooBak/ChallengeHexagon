using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private List<WallEventData<float>> _wallDatas;
    private const int MaxSize = 5;
    

    private void Awake()
    {
        _wallDatas = new List<WallEventData<float>>(MaxSize);
    }

    public int AddData(WallEvent type, float data)
    {
        int count = 0;
        foreach(var wall in _wallDatas)
        {
            if(wall.data == 0)
            {
                wall.type = type;
                wall.data = data;
                break;
            }
            count++;
        }
        if(count == 5)
        {
            Debug.Log("DataCount Range : 5");
        }
        return count;
    }

    public WallEventData<float> GetData(int index)
    {
        return _wallDatas[index];
    }

}
