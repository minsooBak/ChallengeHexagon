using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHexagon : MonoBehaviour
{
    [SerializeField] private GameObject hexagon;

    [SerializeField] [Range(0, 100)] private float hp;

    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = hexagon.GetComponent<SpriteRenderer>();
        hp = 100;
    }

    private void Update()
    {
        _sprite.transform.localScale = new Vector3(hp / 100 * 0.9f, hp / 100 * 0.9f, 1);
    }

    private void MakeSpriteDance(int bpm)
    {
        float beatTime = 60f / bpm * Time.deltaTime;


    }
}
