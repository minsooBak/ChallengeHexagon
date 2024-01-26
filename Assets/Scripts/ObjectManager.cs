using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject map;
    public Object[] objects;

    private Animator _animator;
    private float _time = 5f;
    [SerializeField] private float _dealy = 5f;
    [SerializeField] private int _speed = 5;
    [SerializeField] private int _defaultDamage = 5;

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
        _time += Time.deltaTime;
        if(_time > _dealy)
        {
            TakeOut();
            _time = 0;
        }
    }

    public void ObjectUpdate(float dealy, int speed, int defaultDamage)
    {
        _dealy = dealy;
        _speed = speed;
        _defaultDamage = defaultDamage;
    }

    public void SettingEvent(int index)
    {
        
        int number =  Random.Range(0, objects.Length);
        objects[number].SettingData(index);
    }

    public void ChangeObject(int count, bool isAcitve)
    {
        if(isAcitve)
        {
            _animator.SetTrigger($"{count}_Active");
        }else
        {
            _animator.SetTrigger($"{count}_Disabled");
        }
    }

    public void AddSpeed(int speed)
    {
        _speed += speed;
    }

    private void TakeOut()
    {
        foreach (Object obj in objects)
        {
            obj.TakeOutWall(_speed, _defaultDamage);
        }
    }
}
