using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Controllers;
using TileVania2D.Controllers;
using UnityEngine;

namespace TileVania2D.Cores
{
    public class GameOverCanvas : MonoBehaviour
    {
        public void RestartButton()
        {
            ILevelController levelController = LevelController.Instance;
            levelController.Restart();
        }

        public void MenuButton()
        {
            ILevelController levelController = LevelController.Instance;
            levelController.Menu();
        }
    }
}

