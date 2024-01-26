using System;
using UnityEngine;

public class EventMain : MonoBehaviour
{
    private Player _player;//체력, 속도, 좌우반전[속도 * -1]
    private Transform _playerTransform;//크기
    private ObjectManager _objectManager;//딜레이, 속도
    private EventManager _eventManager;

    private void Start()
    {
        _player = GetComponent<Player>();
        _playerTransform = GetComponent<Transform>();
        _objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        _eventManager = GameManager.I.EventManager;
    }

    public void OnWallEvent(int index, int damage = 0)
    {
        if(index == -1)
        {
            ChangeHP(damage);
            return;
        }
        var data = _eventManager.GetData(index);
        switch(data.Type)
        {
            case WallEvent.HP:
                {
                    ChangeHP((int)data.Data);
                    break;
                }
            case WallEvent.HP_MAX:
                {
                    ChangeHP((int)data.Data, true);
                    break;
                }
            case WallEvent.SPEED_P:
                {
                    ChangSpeed(data.Data);
                    break;
                }
            case WallEvent.MIRROR:
                {
                    ChangeMirror();
                    break;
                }
            case WallEvent.SCALE_P:
                {
                    ChangeScale((int)data.Data);
                    break;
                }
            case WallEvent.SPEED_O:
                {
                    ChangeObjectSpeed((int)data.Data);
                    break;
                }
            case WallEvent.Damage:
                {
                    ChangeHP((int)data.Data + damage);
                    break;
                }
        }
        data.Data = 0;
    }

    private void ChangeHP(int number, bool isMax = false)
    {
        if(isMax)
        {
            _player.MaxHP += number;
        }
        else
        {
            _player.HP += number;
            if(_player.HP == 0)
            {
                GameManager.I.isGameOver = true;
            }
        }
    }

    private void ChangSpeed(float speed)
    {
        _player.Speed += speed;
    }

    private void ChangeMirror()
    {
        _player.Speed *= -1;
    }

    private void ChangeScale(float addScale)
    {
        _playerTransform.localScale += new Vector3(addScale, addScale, 0);
    }

    private void ChangeObjectSpeed(int speed)
    {
        _objectManager.AddSpeed(speed);
    }
}
