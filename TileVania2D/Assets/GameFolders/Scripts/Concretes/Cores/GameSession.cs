using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Controllers;
using TileVania2D.Abstracts.Cores;
using TileVania2D.Controllers;
using UnityEngine;

namespace TileVania2D.Cores
{
    public class GameSession : MonoBehaviour, IGameSession
    {
        [SerializeField] int playerChange = 3;
        [SerializeField] int playerMaxChange = 3;
        [SerializeField] int currentScore = 0;

        private static GameSession _gameSession;

        public event System.Action IncreaseScoreEvent;

        public static GameSession Instance { get => _gameSession; private set => _gameSession = value; }
        public int CurrentChange => playerChange;

        private void Awake()
        {
            SingletonObject();
        }

        private void SingletonObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void TryAgain()
        {
            playerChange--;
            ILevelController levelController = LevelController.Instance;

            if (playerChange <= 0)
            {
                playerChange = playerMaxChange;
                StartCoroutine(levelController.GameOverScene());
            }
            else
            {
                StartCoroutine(levelController.Restart());
            }
        }

        public void SetCurrentScore(int score)
        {
            currentScore += score;

            if (IncreaseScoreEvent != null)
            {
                IncreaseScoreEvent();
            }
        }

        public int GetCurrentScore()
        {
            return currentScore;
        }
    }
}

