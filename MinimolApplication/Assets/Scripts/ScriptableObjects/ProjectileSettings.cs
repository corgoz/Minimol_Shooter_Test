using UnityEngine;

namespace MinimolGames
{
    [CreateAssetMenu(fileName = "new ProjectileSettings", menuName = "ProjectileSettings", order = 1)]
    public class ProjectileSettings : DamageDealerSettings
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private GameObject _hitParticle;

        public float LifeTime => _lifeTime;
        
        public float MoveSpeed => _moveSpeed;

        public GameObject HitParticle => _hitParticle;
    }
}