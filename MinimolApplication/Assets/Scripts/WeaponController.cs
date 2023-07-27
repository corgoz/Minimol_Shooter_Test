using UnityEngine;

namespace MinimolGames
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private WeaponSettings _weaponSettings;
        [SerializeField] private Transform _spawnPoint;

        private float _elapsedTime = 0;

        private void Update()
        {
            if(!GameManager.instance.IsPlaying) return;
            _elapsedTime += Time.deltaTime;
            if((_elapsedTime > 1/_weaponSettings.FireRate) && Input.GetMouseButton(0))
            {
                Instantiate(_weaponSettings.ProjectilePrefab, _spawnPoint.position, _spawnPoint.rotation);
                _elapsedTime = 0;
            }
        }
    }
}