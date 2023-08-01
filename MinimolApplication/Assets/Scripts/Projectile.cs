using Unity.VisualScripting;
using UnityEngine;

namespace MinimolGames
{
    public class Projectile : DamageDealer
    {
        private float _elapsedTime;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
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
            if(((ProjectileSettings)_settings).DestroyOnHit)
                gameObject.SetActive(false);
        }
    }
}