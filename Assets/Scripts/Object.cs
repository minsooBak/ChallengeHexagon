using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public GameObject wall;
    [SerializeField]private GameObject[] objWalls;
    private List<Wall> walls;

    private void Update()
    {
        if (transform.localScale.x < 1)
            gameObject.SetActive(false);
    }

    public void TakeOutWall(int speed)
    {
        for(int i = 0; i < walls.Count; i++)
        {
            if (objWalls[i].activeSelf == false)
            {
                walls[i].Init(speed);
                objWalls[i].SetActive(true);
                break;
            }
        }
    }

    public void CreateWall(int count, int layer)
    {
        walls = new List<Wall>(count);
        objWalls = new GameObject[count];
        for (int i = 0; i < count; i++) 
        {
            var w = Instantiate(wall, transform);
            objWalls[i] = w;
            walls.Add(w.GetComponent<Wall>());
            walls[i].Setting(layer);
            w.SetActive(false);
        }
    }
}
