using UnityEngine;

namespace Gameplay.Hunters
{
    public abstract class Attacker : MonoBehaviour
    {
        private float _currentDamage;
        private float _attackCooldown;
        private float _reloadTime;

        public abstract void Attack();

        public void Initialize(float damage, float attackCooldown, float reloadTime)
        {
            _currentDamage = damage;
            _attackCooldown = attackCooldown;
            _reloadTime = reloadTime;
        }
    }
}