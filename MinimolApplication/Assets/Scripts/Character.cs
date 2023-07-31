using UnityEngine;

namespace MinimolGames
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterSettings _characterSettings;

        private HealthController _healthController;
        private CharacterMovement _characterMovement;

        private void Start()
        {
            _healthController = GetComponent<HealthController>();
            _healthController.Init(_characterSettings);

            _characterMovement = GetComponent<CharacterMovement>();
            _characterMovement.Init(_characterSettings);

            Instantiate(_characterSettings.GFX, transform.GetChild(0));
        }
    }
}
