using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _hp;
    [SerializeField] private int _maxHP;
    [SerializeField] private Color _color = Color.white;

    private PlayerManager _playerManager;
    private SaveDatas _saveDatas;
    private Renderer _renderer;
    private string _playerManagerString = "PlayerData";

    public float Speed { get { return _speed; } set { _speed = value; } }
    public int HP { get { return _hp; } set { _hp = Mathf.Clamp(value, 0, _maxHP); } }
    public int MaxHP { get { return _maxHP; } set { _maxHP = value; } }

    private void Awake()
    {
       _playerManager  = GameObject.Find(_playerManagerString).GetComponent<PlayerManager>();
        _renderer = GetComponentInChildren<Renderer>();
    }
    private void Start()
    {
        _saveDatas = GameManager.I.GetComponent<SaveDatas>();
        if (_playerManager != null)
            GetCharacterStat(_playerManager.CurrentCharacter);
        _renderer.material.color = _color;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(_saveDatas._saveData.healingPotion >= 1)
            {
                _saveDatas._saveData.healingPotion--;
                HP += 10;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.instance.SFXPlay(SFX.DAMAGED);
    }

    public void GetCharacterStat(CharacterType currentCharacter)
    {
        switch (currentCharacter)
        {
            case CharacterType.normal:
                _speed = 120f;
                _hp = 100;
                _maxHP = 100;
                _color = Color.white;
                break;
            case CharacterType.speed:
                _speed = 200f;
                _hp = 50;
                _maxHP = 50;
                _color = Color.blue;
                break;
            case CharacterType.health:
                _speed = 90f;
                _hp = 200;
                _maxHP = 200;
                _color = Color.red;   
                break;
        }
    }
}
