using System;
using UnityEngine;

namespace Gameplay.Hunters
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Attacker))]
    public class Hunter : MonoBehaviour
    {
        #region Constants
        private const float JOYSTICK_DEATH_ZONE = 0.3f;
        private const float JUMP_FORCE = 14f;
        #endregion

        #region Fields
        [SerializeField] private HunterStats _stats;
        [SerializeField] private Joystick _joystick;
        private Rigidbody2D _rigidbody;
        private Attacker _attacker;
        private bool _isGrounded;

        private int _currentHealth;
        private float _movementSpeed;
        #endregion

        #region Properties
        public int Health
        {
            private get { return _currentHealth; }
            set
            {
                _currentHealth += value;
                // TODO:
                // Update UI Health Bar
                // Play Hit Sound
                // Show Hit Particle Effects

                if (_currentHealth <= 0)
                    Dead?.Invoke();
            }
        }
        #endregion

        #region Events
        public event Action Dead;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _attacker = GetComponent<Attacker>();
        }

        private void Start()
        {
            _attacker.Initialize(_stats.Damage, _stats.AttackCooldown, _stats.ReloadTime, _stats.AttackCount);
            _currentHealth = _stats.Health;
            _movementSpeed = _stats.MovementSpeed;
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
                _rigidbody.AddForce(Vector2.up * JUMP_FORCE, ForceMode2D.Impulse);
                _isGrounded = false;
            }
        }
        #endregion
    }



    // add comment





}