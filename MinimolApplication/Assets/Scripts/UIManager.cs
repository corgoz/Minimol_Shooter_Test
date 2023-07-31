using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MinimolGames
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        [Header ("Panels")]
        [SerializeField] private GameObject _mainMenuPanel;
        [SerializeField] private GameObject _inGamePanel;
        [SerializeField] private GameObject _resultsPanel;

        [Header("UI Elements")]
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private GameObject _heartPrefab;
        [SerializeField] private Transform _healthBar;
        [SerializeField] private Sprite _fullHeartSprite;
        [SerializeField] private Sprite _emptyHeartSprite;

        private Image[] _heartArray;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        public void BeginGame()
        {
            _mainMenuPanel.SetActive(false);
            _inGamePanel.SetActive(true);
        }

        public void ShowGameResults()
        {
            _inGamePanel.SetActive(false);
            _resultsPanel.SetActive(true);
        }

        public void UpdateScore(int p_score) => _score.text = p_score.ToString("00");
    
        public void SetHealthBar(HealthController p_healthController)
        {
            _heartArray = new Image[p_healthController.MaxHealth];
            p_healthController.Hit += OnPlayerHit;

            for(int i = 0; i < _heartArray.Length; i++)
                _heartArray[i] = Instantiate(_heartPrefab, _healthBar).GetComponent<Image>();
        }

        public void OnPlayerHit(int p_currentHealth)
        {
            if (p_currentHealth < 0 || p_currentHealth >= _heartArray.Length) return;
            _heartArray[p_currentHealth].sprite = _emptyHeartSprite;
        }
    }
}