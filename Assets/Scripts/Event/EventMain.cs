using System;
using UnityEngine;

public class EventMain : MonoBehaviour
{
    private Player _player;//ü��, �ӵ�, �¿����[�ӵ� * -1]
    private Transform _playerTransform;//ũ��
    private ObjectManager _objectManager;//������, �ӵ�

    private void Start()
    {
        _player = GetComponent<Player>();
        _playerTransform = GetComponent<Transform>();
        _objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
    }

    public void ChangeHP(int number, bool isMax = false)
    {
        if(isMax)
        {
            _player.MaxHP += number;
        }
        else
        {
            _player.HP += number;
        }
    }

    public void ChangSpeed(float speed)
    {
        _player.Speed += speed; ;
    }
    
    public void ChangeMirror()
    {
        _player.Speed *= -1;
    }

    public void ChangeScale(float addScale)
    {
        _playerTransform.localScale += new Vector3(addScale, addScale, 0);
    }

    public void ChangeObjectSpeed(int speed)
    {
        _objectManager.AddSpeed(speed);
    }
}
