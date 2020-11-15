using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Movements;
using UnityEngine;

namespace TileVania2D.Movements
{
    public class Climb : MonoBehaviour,IClimb
    {
        [SerializeField] float speed = 3f;

        public void ClimbAction(float vertical)
        {
            transform.Translate(new Vector2(0,vertical * Time.deltaTime * speed));
        }
    }
}

