using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelSprite : MonoBehaviour
{
    [SerializeField] private GameObject levelImage;
    private Transform _transform;
    private Vector3 _rotation;

    void Start()
    {
        _transform = levelImage.GetComponent<Transform>();
        _rotation = new Vector3(0.3f, 0.4f, 0.5f);
    }

    void Update()
    {
        _transform.Rotate(_rotation);
    }
}
