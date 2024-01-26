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

    public void OnWallEvent(int index, int damage = 0)
    {
        if(index == -1)
        {
            ChangeHP(damage);
            return;
        }
        var data = GameManager.I.EventManager.GetData(index);
        switch(data.type)
        {
            case WallEvent.HP:
                {
                    ChangeHP((int)data.data);
                    break;
                }
            case WallEvent.HP_MAX:
                {
                    ChangeHP((int)data.data, true);
                    break;
                }
            case WallEvent.SPEED_P:
                {
                    ChangSpeed(data.data);
                    break;
                }
            case WallEvent.MIRROR:
                {
                    ChangeMirror();
                    break;
                }
            case WallEvent.SCALE_P:
                {
                    ChangeScale((int)data.data);
                    break;
                }
            case WallEvent.SPEED_O:
                {
                    ChangeObjectSpeed((int)data.data);
                    break;
                }
            case WallEvent.Damage:
                {
                    ChangeHP((int)data.data + damage);
                    break;
                }
        }
        data.data = 0;
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
