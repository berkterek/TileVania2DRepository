using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Combats;
using UnityEngine;

namespace TileVania2D.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] int health = 100;
        [SerializeField] Vector2 deathAct;
        [SerializeField] float waitTime = 1.5f;

        bool _isAlive = true;

        public bool IsAlive => _isAlive;

        public void SetCurrentHealth(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                StartCoroutine(DyingProcess());
            }
        }

        private IEnumerator DyingProcess()
        {
            _isAlive = false;
            GetComponent<Animator>().SetTrigger("Death");
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            rigidbody2D.AddForce(deathAct);

            yield return new WaitForSeconds(waitTime);

            rigidbody2D.gravityScale = 0f;

            foreach (var item in GetComponents<Collider2D>())
            {
                item.enabled = false;
            }

            rigidbody2D.velocity = new Vector2(0f,0f);
        }
    }
}

