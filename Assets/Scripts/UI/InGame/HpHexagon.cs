using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class HpHexagon : MonoBehaviour
{
    [SerializeField] private GameObject hexagon;

    [SerializeField] [Range(0, 100)] private float hp;

    private SpriteRenderer _sprite;

    private Vector3 minScale;
    private Vector3 originScale;
    private float chunk;
    private float timer;
    private float zoomSpeed;
    private int bpm;
    private int count;



    private void Awake()
    {
        _sprite = hexagon.GetComponent<SpriteRenderer>();
        hp = 100;
        chunk = 0f;
        bpm = 110;
        timer = 0f;
        count = 1;
        zoomSpeed = 1.0f;
    }

    private void Start()
    {

    }

    private void Update()
    {
        SetScale();
        CheckBPM(bpm);
    }

    private void SetScale()
    {
        originScale = new Vector3(hp / 100 * 0.9f, hp / 100 * 0.9f, 1);
        minScale = originScale * 0.9f;
    }

    private void CheckBPM(int bpm)
    {
        chunk = 60f / bpm;
        timer += Time.deltaTime;

        if (timer >= chunk * count)
        {
            MakeScaleMin();
            Invoke("MakeScaleOrigin", chunk / 3);
            count++;
        }
    }

    private void MakeScaleMin()
    {
        _sprite.transform.localScale = Vector3.Lerp(originScale, minScale, Time.deltaTime * zoomSpeed);
    }

    private void MakeScaleOrigin()
    {
        _sprite.transform.localScale = Vector3.Lerp(minScale, originScale, Time.deltaTime * zoomSpeed);
    }

}
