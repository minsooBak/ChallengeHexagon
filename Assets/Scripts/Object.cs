using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public GameObject wall;
    [SerializeField]private Queue<GameObject> _objWalls;


    public void TakeOutWall(int speed, int damage)
    {
        var obj = _objWalls.Dequeue();
        if(obj.activeSelf)
        {
            Debug.Log("Wall Pool over");
        }
        obj.GetComponent<Wall>().Init(speed, damage);
        obj.SetActive(true);
        _objWalls.Enqueue(obj);
    }

    public void SettingData(int index)
    {
        foreach(GameObject obj in _objWalls)
        {
            if (obj.activeSelf == false)
            {
                obj.GetComponent<Wall>().SettingData(index);
                break;
            }
        }
    }

    public void CreateWall(int count, int layer)
    {
        _objWalls = new Queue<GameObject>(count);
        for (int i = 0; i < count; i++) 
        {
            var obj = Instantiate(wall, transform);
            var w = obj.GetComponent<Wall>();
            w.Setting(layer);
            obj.SetActive(false);
            _objWalls.Enqueue(obj);
        }
    }
}
