using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private int _damage = 0;
    private int _dataIndex = -1;

    private SpriteRenderer _renderer;
    private EventManager _eventManager;

    [SerializeField] private Material _defultMaterial;
    [SerializeField] private Material[] _materials;

    void Update()
    {
        CheckUpdate();
        if (transform.localPosition.y >= 0.56f)
        {
            if (_dataIndex != -1)
            {
                GameManager.I.EventManager.DeleteData(_dataIndex);
                _dataIndex = -1;
            }
            gameObject.SetActive(false);
        }
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, _speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventMain _event = collision.GetComponent<EventMain>();
        _event.OnWallEvent(_dataIndex, -_damage);
        _dataIndex = -1;
        _renderer.material = _defultMaterial;
        gameObject.SetActive(false);
    }

    public void Setting(int layer)
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.material = _defultMaterial;
        _eventManager = GameManager.I.EventManager;
        _renderer.sortingOrder = layer;
    }

    public void SettingData(int index)
    {
        //TODO : Type에 따른 메테리얼 변경
        if (index == -1)
        {
            _renderer.material = _defultMaterial;
        }
        else
        {
            _dataIndex = index;
            _renderer.material = _materials[_eventManager.GetType(index)];
        }
    }

    public void Init(int speed, int damage)
    {
        if(_dataIndex == -1)
        {
            _renderer.material = _defultMaterial;
        }
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
