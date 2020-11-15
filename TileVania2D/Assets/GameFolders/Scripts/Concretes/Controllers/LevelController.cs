using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Controllers;
using TileVania2D.Cores;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TileVania2D.Controllers
{
    public class LevelController : MonoBehaviour,ILevelController
    {
        [SerializeField] float waitNewScene = 1f;

        static LevelController _levelController;

        public static LevelController Instance { get => _levelController; private set => _levelController = value; }
        private int _currentLevel;

        public event System.Action DestroyPersistents;

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

        public void LoadNextLevel()
        {
            if (DestroyPersistents != null)
            {
                DestroyPersistents();
            }
            
            _currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadSceneAsync(_currentLevel);
        }

        public IEnumerator Restart()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadSceneAsync(_currentLevel);
        }

        public void Menu()
        {
            SceneManager.LoadSceneAsync(0);
        }

        public void Exit()
        {
            Application.Quit();
        }

        public IEnumerator GameOverScene()
        {
            if (DestroyPersistents != null)
            {
                DestroyPersistents();
            }
            yield return new WaitForSeconds(3f);
            SceneManager.LoadSceneAsync("GameOverScene");
        }
    }
}
