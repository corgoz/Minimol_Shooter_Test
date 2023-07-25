using System;
using UnityEngine;

namespace MinimolGames
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 10f;

        void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        void Update()
        {
            transform.Translate(10f * Time.deltaTime * transform.forward, Space.World);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}