using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileVania2D.Abstracts.Controllers
{
    public interface ILevelController
    {
        void LoadNextLevel();
        IEnumerator Restart();
        void Menu();
        void Exit();
        IEnumerator GameOverScene();
        event System.Action DestroyPersistents;
    }
}

