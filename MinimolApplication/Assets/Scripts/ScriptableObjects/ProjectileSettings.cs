using UnityEngine;

namespace MinimolGames
{
    [CreateAssetMenu(fileName = "new ProjectileSettings", menuName = "ProjectileSettings", order = 1)]
    public class ProjectileSettings : DamageDealerSettings
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private bool _destroyOnHit;
        [SerializeField] private bool _followOwner;

        public float LifeTime => _lifeTime;
        public float MoveSpeed => _moveSpeed;
        public bool DestroyOnHit => _destroyOnHit;
        public bool FollowOwner => _followOwner;
    }
}
