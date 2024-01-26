using UnityEngine;

public class Object : MonoBehaviour
{
    private GameObject wall;
    [SerializeField]private GameObject[] _objWalls;

    public int Layer { get; set; }

    private void Update()
    {
        if (transform.localScale.x < 1)
            gameObject.SetActive(false);
    }

    public void TakeOutWall(int speed, int damage)
    {
        wall = GameManager.I.ObjectPool.SpawnFromPool("Wall");
        wall.transform.parent = transform;
        wall.GetComponent<Wall>().Init(speed, damage);
        wall.SetActive(true);
        wall.GetComponent<Wall>().Setting(Layer);
    }

    public void SettingData(int index)
    {
        
        wall.GetComponent<Wall>().SettingData(index);
    }

    /*public void CreateWall(int count, int layer)
    {
        _objWalls = new GameObject[count];
        for (int i = 0; i < count; i++) 
        {
            _objWalls[i] = Instantiate(wall, transform);
            var w = _objWalls[i].GetComponent<Wall>();
            w.Setting(layer);
            _objWalls[i].SetActive(false);
        }
    }*/
}
