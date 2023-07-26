using System;
using UnityEngine;

namespace MinimolGames
{
    public class HealthController : MonoBehaviour
    {
        public Action Hit;
        public Action<HealthController> Death;

        private int _maxHealth;
        private int _currentHealth;
        
        public bool IsDead => _currentHealth <= 0;

        private void OnTriggerEnter(Collider other)
        {
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();
            if (damageDealer)
                GetHit(damageDealer.DamageAmount);
        }

        public void Init(int p_maxHealth)
        {
            _maxHealth = p_maxHealth;
            _currentHealth = p_maxHealth; 
        }

        public void Heal(int p_amount) => _currentHealth = Mathf.Min(_maxHealth, _currentHealth + p_amount);

        public void GetHit(int p_amount)
        {
            _currentHealth = _currentHealth - p_amount;
            Hit?.Invoke();
            if( _currentHealth <= 0)
                Die();
        }

        private void Die()
        {
            Death?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
