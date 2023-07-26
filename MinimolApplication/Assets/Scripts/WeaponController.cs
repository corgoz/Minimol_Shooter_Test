using UnityEngine;

namespace MinimolGames
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPoint;
        
        private void Update()
        {
            if(!GameManager.instance.IsPlaying) return;

            if (Input.GetMouseButtonDown(0))
                Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
        }
    }
}