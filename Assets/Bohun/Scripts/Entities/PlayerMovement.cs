using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Rigidbody2D _rigid;
    private Vector2 dirVec = Vector2.zero;
    private Vector3 rotateVec = Vector3.zero;
    [SerializeField] private Transform _pivot;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyRotation(dirVec);
    }

    private void ApplyRotation(Vector2 dir)
    {
        transform.RotateAround(_pivot.position, -rotateVec, 90f * Time.deltaTime);
    }

    private void Move(Vector2 dir)
    {
        rotateVec = new Vector3(0,0,dir.x);
    }
}
