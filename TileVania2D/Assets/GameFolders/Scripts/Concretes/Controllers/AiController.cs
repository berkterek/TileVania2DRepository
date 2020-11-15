using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Combats;
using TileVania2D.Abstracts.Movements;
using UnityEngine;

namespace TileVania2D.Controllers
{
    public class AiController : MonoBehaviour
    {
        [SerializeField] float moveDirection = 1f;
        private IMove _move;
        private IHealth _health;

        private void Awake()
        {
            _move = GetComponent<IMove>();
            _health = GetComponent<IHealth>();
        }

        private void Update()
        {
            if (!_health.IsAlive) return;

            _move.MoveCharacter(moveDirection);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            moveDirection *= -1;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            IDamage damage = collision.transform.GetComponent<IDamage>();

            if (damage != null && _health.IsAlive)
            {
                _health.SetCurrentHealth(damage.ToDamage);
            }
        }
    }
}

