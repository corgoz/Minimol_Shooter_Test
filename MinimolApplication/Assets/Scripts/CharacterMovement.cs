using UnityEngine;
using UnityEngine.AI;

namespace MinimolGames
{
    public abstract class CharacterMovement : MonoBehaviour
    {
        protected CharacterSettings _characterSettings;
        protected NavMeshAgent _navMeshAgent;

        public void Init(CharacterSettings p_characterSettigs)
        {
            _characterSettings = p_characterSettigs;
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.speed = _characterSettings.MoveSpeed;
            _navMeshAgent.angularSpeed = _characterSettings.RotationSpeed;
        }
    }
}