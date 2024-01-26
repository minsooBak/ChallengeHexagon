using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]private float _speed = 5f;
    private int _damage = 0;
    int _dataIndex = -1;

    void Update()
    {
        CheckUpdate();
        if (transform.localPosition.y >= 0.56f)
        {
            gameObject.SetActive(false);
        }
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, _speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventMain _event = collision.GetComponent<EventMain>();
        _event.OnWallEvent(_dataIndex, -_damage);
        _dataIndex = -1;
        gameObject.SetActive(false);
    }

    public void Setting(int layer)
    {
        GetComponent<SpriteRenderer>().sortingOrder = layer;
    }

    public void SettingData(int index)
    {
        _dataIndex = index;
    }

    public void Init(int speed, int damage)
    {
        _speed = speed;
        _damage = damage;
        transform.localPosition = new Vector3(0, -0.4f, 0);
    }

    public void CheckUpdate()
    {
        var render = GetComponent<SpriteRenderer>();
        if (transform.parent.localScale.x <= 0.1f)
            render.enabled = false;
        else
        {
            render.enabled = true;
            if(transform.localPosition.x != 0)
            {
                transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
            }
        }
    }
}
