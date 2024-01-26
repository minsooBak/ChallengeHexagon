using System;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]private float _speed = 5f;
    private int _damage = 0;
    WallEventData _data;
    void Update()
    {
        if (transform.localPosition.y >= 0.56f)
        {
            gameObject.SetActive(false);
        }
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, _speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventMain _event = collision.GetComponent<EventMain>();
        if (_data != null)
        {
            _event.ChangeScale(_data.scale);
            _event.ChangSpeed(_data.speedP);
            _event.ChangeObjectSpeed(_data.speedO);
            _event.ChangeHP(_data.maxHP, true);
            _event.ChangeHP(_data.hp);
            if (_data.isMirror)
                _event.ChangeMirror();
            _event.ChangeHP((_damage + _data.damage) * -1);
        }
        else
        {
            _event.ChangeHP(-_damage);
        }
        gameObject.SetActive(false);
    }

    public void Setting(int layer)
    {
        GetComponent<SpriteRenderer>().sortingOrder = layer;
    }

    public void SettingData(WallEventData data)
    {
        _data = data;
    }

    public void Init(int speed, int damage)
    {
        _speed = speed;
        _damage = damage;
        transform.localPosition = new Vector3(0, -0.4f, 0);
    }
}
