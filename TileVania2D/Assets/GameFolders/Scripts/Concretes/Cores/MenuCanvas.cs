using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Controllers;
using TileVania2D.Controllers;
using UnityEngine;

namespace TileVania2D.Cores
{
    public class MenuCanvas : MonoBehaviour
    {
        public void StartGameButton()
        {
            ILevelController levelController = LevelController.Instance;
            levelController.LoadNextLevel();
        }

        public void ExitButton()
        {
            ILevelController levelController = LevelController.Instance;
            levelController.Exit();
        }
    }
}

