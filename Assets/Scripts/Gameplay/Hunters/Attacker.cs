using System.Collections;
using UnityEngine;

namespace Gameplay.Hunters
{
    public abstract class Attacker : MonoBehaviour
    {
        private float _currentDamage;
        private float _attackCooldown;
        private float _reloadTime;
        private int _maxAttackCount;
        private int _currentAttackCount;
        private bool _isAttacking = false;

        public void Initialize(float damage, float attackCooldown, float reloadTime, int attackCount)
        {
            _currentDamage = damage;
            _attackCooldown = attackCooldown;
            _reloadTime = reloadTime;
            _maxAttackCount = attackCount;
            _currentAttackCount = _maxAttackCount;
        }


        public void StartAttack()
        {
            if (_isAttacking == false && _currentAttackCount > 0)
                StartCoroutine(Attacking());
            // TODO: else
                // Play Sound
        }

        public IEnumerator Attacking()
        {
            _currentAttackCount--;
            // TODO: update ui ammo
            Attack();
            yield return new WaitForSeconds(_attackCooldown);
            _isAttacking = true;
        }

        protected abstract void Attack();
    }
}