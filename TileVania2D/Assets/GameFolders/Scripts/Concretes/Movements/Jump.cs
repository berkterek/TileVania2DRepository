using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Movements;
using UnityEngine;

namespace TileVania2D.Movements
{
    public class Jump : MonoBehaviour, IJump
    {
        [SerializeField] float jumpForce = 5f;

        public void JumpAction(Rigidbody2D rigidbody2D)
        {
            if (rigidbody2D.velocity.y != 0) return;

            rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}

