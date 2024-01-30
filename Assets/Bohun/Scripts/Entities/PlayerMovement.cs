using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterBaseController _controller;
    private Rigidbody2D _rigid;
    private Vector2 dirVec = Vector2.zero;
    private Vector3 rotateVec = Vector3.zero;
    [SerializeField] private Transform _pivot;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _controller = GetComponent<CharacterBaseController>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyRotation(rotateVec);
    }

    private void ApplyRotation(Vector3 dir)
    {
        transform.RotateAround(_pivot.position, -dir, _player.Speed * Time.deltaTime);
    }

    private void Move(Vector2 dir)
    {
        rotateVec = new Vector3(0,0,dir.x);
    }
}
