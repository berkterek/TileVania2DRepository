using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Cores;
using TMPro;
using UnityEngine;

namespace TileVania2D.Displays
{
    public class DisplayScore : MonoBehaviour
    {
        TextMeshProUGUI _scoreText;
        IGameSession _gameSession;

        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
            _gameSession = Cores.GameSession.Instance;
        }

        private void OnEnable()
        {
            _gameSession.IncreaseScoreEvent += IncreaseScore;
        }

        private void Start()
        {
            IncreaseScore();
        }

        private void OnDisable()
        {
            _gameSession.IncreaseScoreEvent -= IncreaseScore;
        }

        private void IncreaseScore()
        {
            _scoreText.text = _gameSession.GetCurrentScore().ToString();
        }
    }
}

