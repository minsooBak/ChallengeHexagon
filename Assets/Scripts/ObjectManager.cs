using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject map;
    public Object[] objects;

    private Animator _animator;
    private float _time = 0f;
    [SerializeField] private float _dealy = 5f;
    [SerializeField] private int _speed = 5;
    [SerializeField] private int _defaultDamage = 5;
    private List<WallEventData> _datas = new ();

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

    public void SettingEvent(WallEventData.WallEvent wallEvent, int number, int count = -1)
    {
        WallEventData data = ScriptableObject.CreateInstance<WallEventData>();
        switch(wallEvent)
        {
            case WallEventData.WallEvent.HP:
                data.hp = number;
                break;
            case WallEventData.WallEvent.SCALE_P:
                data.scale = number; 
                break;
            case WallEventData.WallEvent.SPEED_P:
                data.speedP = number;
                break;
            case WallEventData.WallEvent.SPEED_O:
                data.speedO = number;
                break;
            case WallEventData.WallEvent.HP_MAX:
                data.maxHP = number; 
                break;
            case WallEventData.WallEvent.Damage:
                data.damage = number;
                break;
            case WallEventData.WallEvent.MIRROR:
                data.isMirror = true;
                break;
        }
        data.number = count == -1 ? Random.Range(0, objects.Length) : count;
        _datas.Add(data);
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
        if (_datas.Count > 0)
        {
            foreach (WallEventData data in _datas)
            {
                objects[data.number].SettingData(data);
            }
            _datas.Clear();
        }

        foreach (Object obj in objects)
        {
            obj.TakeOutWall(_speed, _defaultDamage);
        }
    }
}
