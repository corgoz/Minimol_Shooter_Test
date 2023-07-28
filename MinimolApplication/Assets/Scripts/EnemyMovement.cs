using UnityEngine;

namespace MinimolGames
{
    public class EnemyMovement : CharacterMovement
    {
        private PlayerMovement _player;

        private void Start()
        {
            _player = FindObjectOfType<PlayerMovement>(); 
        }

        private void Update()
        {
            if (_player == null) return;
            MoveTowards(_player.transform);
        }

        private void MoveTowards(Transform p_target)
        {
            _navMeshAgent.SetDestination(_player.transform.position);
        }
    }
}