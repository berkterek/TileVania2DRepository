using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileVania2D.Abstracts.Cores
{
    public interface IGameSession
    {
        void TryAgain();
        void SetCurrentScore(int score);
        int GetCurrentScore();
        int CurrentChange { get; }
        event System.Action IncreaseScoreEvent;
    }
}

