using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileVania2D.Abstracts.Combats
{
    public interface IHealth
    {
        bool IsAlive { get; }
        void SetCurrentHealth(int damage);
    }
}

