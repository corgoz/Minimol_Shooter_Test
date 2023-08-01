using UnityEngine;

namespace MinimolGames
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterSettings _characterSettings;

        private HealthController _healthController;
        private CharacterMovement _characterMovement;
        private WeaponController _weaponController;
        private Transform _gfx;

        private void Start()
        {
            _healthController = GetComponent<HealthController>();
            _characterMovement = GetComponent<CharacterMovement>();
            _weaponController = GetComponentInChildren<WeaponController>();
            _gfx = transform.Find("GFX");

            if (_characterSettings)
                SetCharacter(_characterSettings);
        }

        public void SetCharacter(CharacterSettings p_characterSettings)
        {
            _characterSettings = p_characterSettings;
            _healthController.Init(_characterSettings);
            _characterMovement.Init(_characterSettings);

            for(int i = _gfx.childCount -1; i >= 0; i--)
                Destroy(_gfx.GetChild(i).gameObject);

            Instantiate(_characterSettings.GFX, _gfx);

            if (_weaponController)
                _weaponController.Init(_characterSettings.Weapon);
                
        }

    }
}
