using UnityEngine;

namespace MinimolGames
{
    public class Projectile : DamageDealer
    {
//        private ProjectileSettings _projectileSettings;

        private float _elapsedTime;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
         //   _projectileSettings = (ProjectileSettings)_settings;
        }

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
        }
    }
}