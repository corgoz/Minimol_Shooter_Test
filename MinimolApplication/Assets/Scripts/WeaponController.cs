using UnityEngine;

namespace MinimolGames
{
    public class WeaponController : MonoBehaviour
    {
        private WeaponSettings _weaponSettings;
        private ObjectPool<PoolObject> _projectilePool;
        private Transform _spawnPoint;
        private float _elapsedTime = 0;


        private void Update()
        {
            if(!GameManager.instance.IsPlaying) return;

            _elapsedTime += Time.deltaTime;
            if((_elapsedTime > 1/_weaponSettings.FireRate) && Input.GetMouseButton(0))
            {
                ShootProjectile();
                _elapsedTime = 0;
            }
        }

        public void Init(WeaponSettings p_weaponSettings)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
                Destroy(transform.GetChild(i).gameObject);

            _weaponSettings = p_weaponSettings;
            
            var weapon = Instantiate(_weaponSettings.WeaponPrefab, transform);
            _spawnPoint = weapon.transform.Find("SpawnPoint");
            _projectilePool = new ObjectPool<PoolObject>(_weaponSettings.ProjectilePrefab);
        }

        private void ShootProjectile()
        {
            Vector3 direction = transform.eulerAngles;
            direction.y -= (_weaponSettings.Spread/2) * (_weaponSettings.NumberOfProjectiles - 1);
            for (int i = 0; i < _weaponSettings.NumberOfProjectiles; i++)
            {

                _projectilePool.Pull(_spawnPoint.position, Quaternion.Euler(direction));
                direction.y += _weaponSettings.Spread;
            }
        }
    }
}