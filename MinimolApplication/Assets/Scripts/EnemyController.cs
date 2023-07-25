using System;
using UnityEngine;

namespace MinimolGames
{
    public class EnemyController : MonoBehaviour
    {
        public Action Death;

        [SerializeField] float _moveSpeed = 3f;
        [SerializeField] PlayerController _player;

        private void Start()
        {
            _player = FindObjectOfType<PlayerController>();
        }

        void Update()
        {
            if (_player == null) return;
            MoveTowards(_player.transform);
        }

        private void OnDestroy()
        {
            Death?.Invoke();
        }

        void MoveTowards(Transform p_target)
        {
            var direction = (p_target.position - transform.position).normalized;
            transform.Translate(_moveSpeed * Time.deltaTime * direction, Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().Death?.Invoke();
                Destroy(other.gameObject);
            }
        }
    }
}