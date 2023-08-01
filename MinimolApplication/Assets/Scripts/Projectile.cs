using UnityEngine;

namespace MinimolGames
{
    public class Projectile : DamageDealer
    {
        private float _elapsedTime;
        private Transform _transform;
        private WeaponController _owner;

        public GameObject HitParticle => ((ProjectileSettings)_settings).HitParticle;

        private void Update()
        {
            _transform.Translate(((ProjectileSettings)_settings).MoveSpeed * Time.deltaTime * _transform.forward, Space.World);

            _elapsedTime += Time.deltaTime;
            if(_elapsedTime > ((ProjectileSettings)_settings).LifeTime)
            {
                _elapsedTime = 0;
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
            Transform hitParticle = _owner.GetProjectileHitParticle;
            hitParticle.position = _transform.position;
        }

        public void Init(WeaponController p_weaponController)
        {
            if (_owner) return;

            _transform = transform;
            _owner = p_weaponController;
        }
    }
}