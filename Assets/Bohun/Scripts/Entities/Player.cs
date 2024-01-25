using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    public float Speed { get { return speed; } private set { speed = value; } }
    private int hP;
    public int HP { get { return hP; } private set { hP = value; } }

    private void OnEnable()
    {
        GetCharacterStat(PlayerManager.instance.CurrentCharacter); 
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
                speed = 120f;
                hP = 100;
                break;
            case Character.speed:
                speed = 200f;
                hP = 50;
                break;
            case Character.health:
                speed = 90f;
                hP = 200;
                break;
        }
    }
}
