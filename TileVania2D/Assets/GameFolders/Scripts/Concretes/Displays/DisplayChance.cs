using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Cores;
using UnityEngine;
using TMPro;

namespace TileVania2D.Displays
{
    public class DisplayChance : MonoBehaviour
    {
        IGameSession _gameSession;

        private void Awake()
        {
            _gameSession = Cores.GameSession.Instance;
        }

        private void Start()
        {
            GetComponent<TextMeshProUGUI>().text = _gameSession.CurrentChange.ToString();
        }
    }
}

