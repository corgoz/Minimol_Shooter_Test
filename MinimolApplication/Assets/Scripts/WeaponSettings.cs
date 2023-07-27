using UnityEngine;

namespace MinimolGames
{
    [CreateAssetMenu(fileName = "new WeaponSettings", menuName = "WeaponSettings", order = 1)]
    public class WeaponSettings : ScriptableObject
    {
        [SerializeField] private float _fireRate;
        [SerializeField] private GameObject _gfx;
        [SerializeField] private GameObject _projectilePrefab;

        public float FireRate => _fireRate;
        public GameObject Gfx => _gfx;
        public GameObject ProjectilePrefab => _projectilePrefab;
    }
}
