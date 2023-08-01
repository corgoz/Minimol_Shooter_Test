using UnityEngine;
using UnityEngine.SceneManagement;

namespace MinimolGames
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [Header("Game Object References")]
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _enemyPrefab;

        [Header ("Enemy Spawn Settings")]
        [SerializeField] private float _enemySpawnRadius;
        [SerializeField] private float _enemySpawnRate;
        
        private bool _isPlaying;
        private int _score;
        private float _elapsedTime;
        private ObjectPool<PoolObject> _enemyPool;

        public bool IsPlaying => _isPlaying;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            _player.GetComponent<HealthController>().Death += OnPlayerDeath;
            _enemyPool = new ObjectPool<PoolObject>(_enemyPrefab);
        }

        private void Update()
        {
            if (_player == null || !_isPlaying) return;
            
            _elapsedTime += Time.deltaTime;
            if( _elapsedTime > 1 / _enemySpawnRate)
            {
                SpawnEnemy();
                _elapsedTime = 0;
            }
        }

        public void BeginGame() 
        {
            _isPlaying = true;
            UIManager.instance.SetHealthBar(_player.GetComponent<HealthController>());
        }

        public void ReloadLevel() => SceneManager.LoadScene(0);

        public void SetPlayerCharacter(CharacterSettings p_characterSettings) => _player.GetComponent<Character>().SetCharacter(p_characterSettings);

        private void SpawnEnemy()
        {
            Vector3 randomPositionInCircle = Random.insideUnitCircle.normalized * _enemySpawnRadius;
            randomPositionInCircle.z = randomPositionInCircle.y;
            randomPositionInCircle.y = 0;

            Vector3 spawnPosition = _player.transform.position + randomPositionInCircle;

            var enemy = _enemyPool.Pull(_player.transform.position + spawnPosition);
            enemy.GetComponent<HealthController>().Death += OnEnemyDeath;
        }

        private void OnEnemyDeath(HealthController p_healthController)
        {
            _score++;
            UIManager.instance.UpdateScore(_score);
        }

        private void OnPlayerDeath(HealthController p_healthController)
        {
            _isPlaying = false;
            UIManager.instance.ShowGameResults();
        }
    }
}