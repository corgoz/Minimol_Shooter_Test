using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MinimolGames
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        [SerializeField] private GameObject _mainMenuPanel;
        [SerializeField] private GameObject _inGamePanel;
        [SerializeField] private GameObject _resultsPanel;
        [SerializeField] private TextMeshProUGUI _score;

        // Start is called before the first frame update
        void Awake()
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
    }
}
