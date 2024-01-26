using UnityEngine;

public class Object : MonoBehaviour
{
    public GameObject wall;
    [SerializeField]private GameObject[] _objWalls;


    public void TakeOutWall(int speed, int damage)
    {
        for(int i = 0; i < _objWalls.Length; i++)
        {
            if (_objWalls[i].activeSelf == false)
            {
                _objWalls[i].GetComponent<Wall>().Init(speed, damage);
                _objWalls[i].SetActive(true);
                break;
            }
        }
    }

    public void SettingData(int index)
    {
        for (int i = 0; i < _objWalls.Length; i++)
        {
            if (_objWalls[i].activeSelf == false)
            {
                _objWalls[i].GetComponent<Wall>().SettingData(index);
                break;
            }
        }
    }

    public void CreateWall(int count, int layer)
    {
        _objWalls = new GameObject[count];
        for (int i = 0; i < count; i++) 
        {
            _objWalls[i] = Instantiate(wall, transform);
            var w = _objWalls[i].GetComponent<Wall>();
            w.Setting(layer);
            _objWalls[i].SetActive(false);
        }
    }
}
