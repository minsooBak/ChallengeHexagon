using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _hp;
    [SerializeField] private int _maxHP;

    private PlayerManager _playerManager;
    private string _playerManagerString = "PlayerData";

    public float Speed { get { return _speed; } set { _speed = value; } }
    public int HP { get { return _hp; } set { _hp = Mathf.Clamp(value, 0, _maxHP); } }
    public int MaxHP { get { return _maxHP; } set { _maxHP = value; } }

    private void Awake()
    {
       _playerManager  = GameObject.Find(_playerManagerString).GetComponent<PlayerManager>();
    }
    private void Start()
    {
        GetCharacterStat(_playerManager.CurrentCharacter);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.instance.SFXPlay(SFX.DAMAGED);
        if (_hp <= 0)
        {
            GameManager.I.isGameOver = true;
        }
    }

    public void GetCharacterStat(Character currentCharacter)
    {
        switch (currentCharacter)
        {
            case Character.normal:
                _speed = 120f;
                _hp = 100;
                _maxHP = 100;
                break;
            case Character.speed:
                _speed = 200f;
                _hp = 50;
                _maxHP = 50;
                break;
            case Character.health:
                _speed = 90f;
                _hp = 200;
                _maxHP = 200;
                break;
        }
    }
}
