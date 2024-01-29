using UnityEngine;

public class Object : MonoBehaviour
{
    private GameObject _wall;
    private ObjectPool _pool;

    public int Layer { get; set; }

    private void Awake()
    {
        _pool = GetComponent<ObjectPool>();
    }

    private void Update()
    {
        if (transform.localScale.x < 1)
            gameObject.SetActive(false);
    }

    public void TakeOutWall(int speed, int damage)
    {
        _wall = _pool.SpawnFromPool();
        _wall.GetComponent<Wall>().Init(speed, damage);
        _wall.SetActive(true);
        _wall.GetComponent<Wall>().Setting(Layer);
    }

    public void SettingData(int index)
    {
        if(_wall == null)
        {
            GameManager.I.EventManager.DeleteData(index);
            return;
        }
        _wall.GetComponent<Wall>().SettingData(index);
    }
}