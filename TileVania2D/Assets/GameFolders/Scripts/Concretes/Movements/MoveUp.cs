using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileVania2D.Movements
{
    public class MoveUp : MonoBehaviour
    {
        [SerializeField] float speed = 0.2f;

        private void Update()
        {
            MoveUpDirection();
        }

        private void MoveUpDirection()
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
    }
}

