using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Controllers;
using TileVania2D.Controllers;
using UnityEngine;

namespace TileVania2D.Cores
{
    public class LevelExit : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            ILevelController levelController = LevelController.Instance;
            levelController.LoadNextLevel();
        }
    }
}

