using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Gains;
using UnityEngine;

namespace TileVania2D.Gains
{
    public class Score : MonoBehaviour,IScore
    {
        [SerializeField] int score = 10;

        public int MyScore => score;
    }
}

