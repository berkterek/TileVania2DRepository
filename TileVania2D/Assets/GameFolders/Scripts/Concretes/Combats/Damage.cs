using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Combats;
using UnityEngine;

namespace TileVania2D.Combats
{
    public class Damage : MonoBehaviour,IDamage
    {
        [SerializeField] int damage = 100;

        public int ToDamage => damage;
    }
}

