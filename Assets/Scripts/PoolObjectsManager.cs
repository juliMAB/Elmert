﻿using System.Collections.Generic;
using UnityEngine;

namespace GuilleUtils.PoolSystem
{
    [System.Serializable]
    public class PoolObjects
    {
        public GameObject[] objects;
        public Queue<GameObject> pool;
    }

    public class PoolObjectsManager : MonoBehaviour
    {
        private static PoolObjectsManager instance = null;
        public static PoolObjectsManager Instance => instance;

        [Header("Pools")]
        [SerializeField] private PoolObjects cuteEnemies;
        [SerializeField] private PoolObjects darkEnemies;

        public PoolObjects CuteEnemies => cuteEnemies;
        public PoolObjects DarkEnemies => darkEnemies;

        private void Awake()
        {
            instance = this;

            void InitializePool(ref PoolObjects poolObjects)
            {
                poolObjects.pool = new Queue<GameObject>();

                for (int i = 0; i < poolObjects.objects.Length; i++)
                {
                    poolObjects.pool.Enqueue(poolObjects.objects[i]);
                }
            }

            InitializePool(ref cuteEnemies);
            InitializePool(ref darkEnemies);
        }

        public void DeactivateObject(GameObject gObject)
        {
            gObject.SetActive(false);

            void DeactivateIfPartOfGroup(ref PoolObjects poolObjects)
            {
                for (int i = 0; i < poolObjects.objects.Length; i++)
                {
                    if (poolObjects.objects[i] == gObject)
                    {
                        poolObjects.pool.Enqueue(gObject);
                        return;
                    }
                }
            }

            DeactivateIfPartOfGroup(ref cuteEnemies);
            DeactivateIfPartOfGroup(ref darkEnemies);
        }

        public GameObject ActivateEnemy(bool cuteEnemy)
        {
            if (cuteEnemy)
            {
                return ActivateObject(ref cuteEnemies.pool);
            }
            else
            {
                return ActivateObject(ref darkEnemies.pool);
            }
        }

        private GameObject ActivateObject(ref Queue<GameObject> queue)
        {
            GameObject gObject = queue.Dequeue();
            int index = 0;
            bool noObjectToReturn = false;

            while (gObject.activeSelf && !noObjectToReturn)
            {
                queue.Enqueue(gObject);
                gObject = queue.Dequeue();

                index++;

                if (index > queue.Count)
                {
                    noObjectToReturn = true;
                    queue.Enqueue(gObject);
                }
            }

            if (!noObjectToReturn)
            {
                gObject.SetActive(true);
                return gObject;
            }
            else
            {
                Debug.LogError("No objects available to activate!");
                return null;
            }
        }
    }
}