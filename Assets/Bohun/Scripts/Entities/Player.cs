using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed;
    public float Speed { get { return _speed; } private set { _speed = value; } }
    private int _hp;
    public int HP { get { return _hp; } private set { _hp = value; } }

    private void OnEnable()
    {
        GetCharacterStat(PlayerManager.Instance.CurrentCharacter); 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TriggerEnter");
    }

    public void GetCharacterStat(Character currentCharacter)
    {
        switch (currentCharacter)
        {
            case Character.normal:
                _speed = 120f;
                _hp = 100;
                break;
            case Character.speed:
                _speed = 200f;
                _hp = 50;
                break;
            case Character.health:
                _speed = 90f;
                _hp = 200;
                break;
        }
    }
}
