using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float velocityX = 0;
        float velocityY = 0;

        if (_joystick.Horizontal != 0)
            velocityX = _movementSpeed * (_joystick.Horizontal > 0 ? 1 : -1);

        if (_joystick.Vertical >= 0.4f)
            velocityY = _jumpForce;

        _rigidbody.velocity = new Vector2(velocityX, velocityY);
    }
}
