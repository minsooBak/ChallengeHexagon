using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public GameObject wall;
    private List<Wall> walls = new();

    private void OnEnable()
    {
        foreach(var wall in walls)
        {
            wall.Init();
        }
    }

    private void Update()
    {
        if (transform.localScale.x < 1)
            gameObject.SetActive(false);
    }

    public void CreateWall(int speed, int layer)
    {
        Wall w = Instantiate(wall, transform).GetComponent<Wall>();
        w.Layers = layer;
        w.speed = speed;
        walls.Add(w);
    }
}
