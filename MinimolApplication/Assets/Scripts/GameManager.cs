using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MinimolGames
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private float _enemySpawnRate;
        
        private bool _isPlaying;
        private int _score;
        private float _elapsedTime;

        public bool IsPlaying => _isPlaying;
        // Start is called before the first frame update
        void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            _player.GetComponent<PlayerController>().Death += OnPlayerDeath;
        }

        // Update is called once per frame
        void Update()
        {
            if (_player == null || !_isPlaying) return;
            _elapsedTime += Time.deltaTime;
            if( _elapsedTime > 1 / _enemySpawnRate)
            {
                SpawnEnemy();
                _elapsedTime = 0;
            }
        }

        public void BeginGame() => _isPlaying = true;

        public void ReloadLevel()
        {
            SceneManager.LoadScene(0);
        }


        private void SpawnEnemy()
        {
            Vector3 randomPositionInCircle = Random.insideUnitCircle * 10;
            randomPositionInCircle.z = randomPositionInCircle.y;
            randomPositionInCircle.y = 0;

            Vector3 spawnPosition = _player.transform.position + randomPositionInCircle;

            var enemy = Instantiate(_enemyPrefab, _player.transform.position + spawnPosition, Quaternion.identity);
            enemy.GetComponent<EnemyController>().Death += OnEnemyDeath;
        }

        private void OnEnemyDeath()
        {
            _score++;
            UIManager.instance.UpdateScore(_score);
        }

        private void OnPlayerDeath()
        {
            _isPlaying = false;
            UIManager.instance.ShowGameResults();
        }
    }
}
