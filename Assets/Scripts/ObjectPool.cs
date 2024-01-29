using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{

    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private int _size;

    protected Queue<GameObject> _pool;

    private void Awake()
    {
        _pool = new Queue<GameObject>();

        for (int i = 0; i < _size; ++i)
        {
            GameObject obj = Instantiate(_prefab, transform);
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    public GameObject SpawnFromPool()
    {
        GameObject obj = _pool.Dequeue();
        _pool.Enqueue(obj);

        return obj;
    }
}