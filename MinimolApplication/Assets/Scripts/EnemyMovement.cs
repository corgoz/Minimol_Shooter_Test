using System;
using UnityEngine;
using UnityEngine.AI;

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
            //var direction = (p_target.position - transform.position).normalized;
            //transform.Translate(_characterSettings.MoveSpeed * Time.deltaTime * direction, Space.World);
            _navMeshAgent.SetDestination(_player.transform.position);
        }
    }
}