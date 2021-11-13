using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Hunters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Hunter : MonoBehaviour
    {
        #region Constants
        private const float JOYSTICK_DEATH_ZONE = 0.3f;
        #endregion

        #region Fields
        [SerializeField] private Joystick _joystick;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private Transform _groundCheck;
        private Rigidbody2D _rigidbody;
        private bool _isGrounded;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            TryMove();
            TryJump();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var contacts = collision.contacts;
            foreach (var contact in contacts)
            {
                if (contact.normal == Vector2.up)
                {
                    _isGrounded = true;
                    break;
                }
            }
        }
        #endregion

        #region Methods
        private void TryMove()
        {
            float velocityX = 0;

            if (_joystick.Horizontal >= JOYSTICK_DEATH_ZONE || _joystick.Horizontal <= -JOYSTICK_DEATH_ZONE)
                velocityX = _movementSpeed * (_joystick.Horizontal > 0 ? 1 : -1);

            _rigidbody.velocity = new Vector2(velocityX, _rigidbody.velocity.y);
        }

        private void TryJump()
        {
            if (_joystick.Vertical >= JOYSTICK_DEATH_ZONE && _isGrounded)
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _isGrounded = false;
            }
        }
        #endregion
    }
}