using System.Collections.Generic;
using UnityEngine;


public class ObjectManager : MonoBehaviour
{
    public enum ObjectType
    {
        ObjectEven,
        ObejctOdd,
        Wall
    }

    public GameObject map;
    public Object[] objects;

    private Animator _animator;
    private float _time = 0f;
    [SerializeField] private float _dealy = 5f;
    [SerializeField] private int _speed = 5;

    private void Awake()
    {
        Instantiate(map, transform);
        objects = GetComponentsInChildren<Object>();
        _animator = GetComponentInChildren<Animator>();
        int layer = 1;
        foreach (Object obj in objects)
        {
            obj.CreateWall(5, layer++);
        }
    }


    private void Update()
    {
        TestWall();
        _time += Time.deltaTime;
        if(_time > _dealy)
        {
            foreach (Object obj in objects)
            {
                obj.TakeOutWall(_speed);
            }
            _time = 0;
        }
    }

    private void TestWall()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetTrigger("1_Disabled");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetTrigger("1_Active");
        }
    }

    public void ObjectUpdate(float dealy, int speed)
    {
        _dealy = dealy;
        _speed = speed;
    }

    public void ChangePentagon()
    {
        _animator.SetTrigger("1_Disabled");
    }

    public void ChangeHexagon()
    {
        _animator.SetTrigger("1_Active");
    }
}
