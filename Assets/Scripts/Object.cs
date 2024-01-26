using UnityEngine;

public class Object : MonoBehaviour
{
    public GameObject wall;
    [SerializeField]private GameObject[] objWalls;


    public void TakeOutWall(int speed, int damage)
    {
        for(int i = 0; i < objWalls.Length; i++)
        {
            if (objWalls[i].activeSelf == false)
            {
                objWalls[i].GetComponent<Wall>().Init(speed, damage);
                objWalls[i].SetActive(true);
                break;
            }
        }
    }

    public void SettingData(int index)
    {
        for (int i = 0; i < objWalls.Length; i++)
        {
            if (objWalls[i].activeSelf == false)
            {
                objWalls[i].GetComponent<Wall>().SettingData(index);
                break;
            }
        }
    }

    public void CreateWall(int count, int layer)
    {
        objWalls = new GameObject[count];
        for (int i = 0; i < count; i++) 
        {
            objWalls[i] = Instantiate(wall, transform);
            var w = objWalls[i].GetComponent<Wall>();
            w.Setting(layer);
            objWalls[i].SetActive(false);
        }
    }
}
