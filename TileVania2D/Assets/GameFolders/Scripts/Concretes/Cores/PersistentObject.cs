using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Controllers;
using UnityEngine;

namespace TileVania2D.Cores
{
    public class PersistentObject : MonoBehaviour
    {
        ILevelController _levelController;

        private void Awake()
        {
            _levelController = Controllers.LevelController.Instance;
            SingletonWithoutStatic();
        }

        private void OnEnable()
        {
            _levelController.DestroyPersistents += DestroyThisGameObject;
        }

        private void OnDisable()
        {
            _levelController.DestroyPersistents -= DestroyThisGameObject;
        }

        private void SingletonWithoutStatic()
        {
            var persistentObjects = GameObject.FindGameObjectsWithTag("PersistentObject");
            if (persistentObjects.Length > 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }

        private void DestroyThisGameObject()
        {
            Destroy(this.gameObject);
        }
    }
}

