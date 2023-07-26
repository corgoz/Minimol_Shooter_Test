using UnityEngine;

namespace MinimolGames
{
    public class Bullet : DamageDealer
    {
        [SerializeField] private float _lifeTime = 10f;
        [SerializeField] private float _moveSpeed = 10f;

        private void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        private void Update()
        {
            transform.Translate(_moveSpeed * Time.deltaTime * transform.forward, Space.World);
        }

        void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}