using UnityEngine;

namespace MinimolGames
{
    [CreateAssetMenu(fileName = "new CharacterSettings", menuName = "CharacterSettings", order = 1)]
    public class CharacterSettings : ScriptableObject
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;

        public int MaxHealth => _maxHealth;
        public float MoveSpeed => _moveSpeed;
        public float RotationSpeed => _rotationSpeed;
    
    }
}
