using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private Transform rocket;

    private Rigidbody2D _rb2d;
    private RocketController _controller;
    private bool _isBoosted;
    private readonly float SPEED = 5f;
    private readonly float ROTATIONSPEED = 0.01f;

    private Vector2 movedir = Vector2.zero;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _controller = GetComponent<RocketController>();
    }

    private void Start()
    {
        _controller.moveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movedir);
        Debug.Log(movedir);
    }

    public void ApplyMovement(Vector2 direction)
    {
        // TODO : 회전을 적용하고 이동을 적용함 -> 이에 대한 구현을 아래에서 진행할 것
        // Rotate(direction);
        Move(movedir);
    }

    public void ApplyBoost(bool isPressed)
    {
        _isBoosted = isPressed;
    }

    private void Rotate(Vector2 direction)
    {
        // TODO : 완만한 회전을 적용함
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rocket.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void Move(Vector2 dir)
    {
        // TODO : 움직임 적용
        movedir = dir;
        dir = dir * 5f;
        
        _rb2d.velocity = dir;
    }
}