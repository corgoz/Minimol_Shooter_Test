using UnityEngine;

namespace MinimolGames
{
    [CreateAssetMenu(fileName = "new CharacterSettings", menuName = "CharacterSettings", order = 1)]
    public class CharacterSettings : ScriptableObject
    {
        [SerializeField] private GameObject _gfx;
        [SerializeField] private GameObject _deathFX;
        [SerializeField] private WeaponSettings _weapon;
        [SerializeField] private int _maxHealth;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;

        public GameObject GFX => _gfx;
        public GameObject DeathFX => _deathFX;
        public WeaponSettings Weapon => _weapon;
        public int MaxHealth => _maxHealth;
        public float MoveSpeed => _moveSpeed;
        public float RotationSpeed => _rotationSpeed;

    }
}
