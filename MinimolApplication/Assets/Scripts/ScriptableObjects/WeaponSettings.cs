using UnityEngine;

namespace MinimolGames
{
    [CreateAssetMenu(fileName = "new WeaponSettings", menuName = "WeaponSettings", order = 1)]
    public class WeaponSettings : ScriptableObject
    {
        [SerializeField] private float _fireRate;
        [SerializeField] private GameObject _weaponPrefab;
        [SerializeField] private GameObject _projectilePrefab;

        public float FireRate => _fireRate;
        public GameObject WeaponPrefab => _weaponPrefab;
        public GameObject ProjectilePrefab => _projectilePrefab;
    }
}
