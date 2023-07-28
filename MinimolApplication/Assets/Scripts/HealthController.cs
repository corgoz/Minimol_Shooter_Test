using System;
using UnityEngine;

namespace MinimolGames
{
    public class HealthController : MonoBehaviour
    {
        public Action Hit;
        public Action<HealthController> Death;

        private CharacterSettings _characterSettings;
        private GameObject _deathFX;
        private Vector3 _deathFXSpawnOffset;
        private int _currentHealth;
        
        public bool IsDead => _currentHealth <= 0;

        private void OnTriggerEnter(Collider other)
        {
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();
            if (damageDealer)
                GetHit(damageDealer.DamageAmount);
        }

        public void Init(CharacterSettings p_characterSettings)
        {
            _characterSettings = p_characterSettings;
            _currentHealth = _characterSettings.MaxHealth;

            if (!_deathFX && _characterSettings.DeathFX)
            {
                _deathFX = Instantiate(_characterSettings.DeathFX);
                _deathFX.SetActive(false);
                _deathFXSpawnOffset = _characterSettings.DeathFX.transform.position;
            }

        }

        public void Heal(int p_amount) => _currentHealth = Mathf.Min(_characterSettings.MaxHealth, _currentHealth + p_amount);

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
            gameObject.SetActive(false);
            if (!_deathFX) return;

            _deathFX.transform.position = transform.position + _deathFXSpawnOffset;
            _deathFX.SetActive(true);
        }
    }
}
