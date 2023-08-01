using UnityEngine;

namespace MinimolGames
{
    public class EnemyMovement : CharacterMovement
    {
        private PlayerMovement _player;

        private void Start()
        {
            _player = FindObjectOfType<PlayerMovement>();
            _player.GetComponent<HealthController>().Death += OnPlayerDeath;
        }

        private void Update()
        {
            if (_player == null) return;
            MoveTowards(_player.transform);
        }

        private void MoveTowards(Transform p_target) => _navMeshAgent.SetDestination(_player.transform.position);

        private void OnPlayerDeath(HealthController p_healthController)
        {
            _player.GetComponent<HealthController>().Death -= OnPlayerDeath;
            _player = null;
            _navMeshAgent.isStopped = true;
        }
    }
}