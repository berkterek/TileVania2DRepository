using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Movements;
using UnityEngine;

namespace TileVania2D.Movements
{
    public class Move : MonoBehaviour,IMove
    {
        [Header("Move Infos")]
        [SerializeField] float speed = 5f;

        public void MoveCharacter(float horizontal)
        {
            transform.Translate(new Vector2(horizontal * Time.deltaTime*speed,0));
            transform.localScale = new Vector2(Mathf.Sign(horizontal), 1);
        }
    }
}

