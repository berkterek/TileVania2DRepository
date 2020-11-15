using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Cores;
using TileVania2D.Abstracts.Gains;
using TileVania2D.Cores;
using UnityEngine;

namespace TileVania2D.Controllers
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] AudioClip pickupSound;

        IScore _score;

        private void Awake()
        {
            _score = GetComponent<IScore>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IGameSession gameSession = GameSession.Instance;
            gameSession.SetCurrentScore(_score.MyScore);
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            Destroy(this.gameObject);
        }
    }
}

