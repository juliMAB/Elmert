using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GuilleUtils.PoolSystem;

public class EnemiesManager : MonoBehaviour
{
    private float time = 0f;
    private bool lastSpawnedCute = false;

    private List<EnemyController> activeEnemies = new List<EnemyController>();

    [SerializeField] private PoolObjectsManager poolObjectsManager = null;
    [SerializeField] private Transform[] spawnPoints = null;

    [Header("Spawn Configuration")]
    [SerializeField] private float timeBetweenEnemies = 1f;
    [SerializeField] private float timeBetweenSpawns = 5f;
    [SerializeField] private int[] spawnAmountLimits = null;
    [SerializeField] private float minDistanceFromTarget = 6f;

    [Header("Enemies Configuration")]
    [SerializeField] private float damageRate = 1f;
    [SerializeField] private Transform target = null;

    public void EnemiesFixedUpdate()
    {
        time += Time.fixedDeltaTime;

        if (time > timeBetweenSpawns)
        {
            int amountEnemies = UnityEngine.Random.Range(spawnAmountLimits[0], spawnAmountLimits[1]);
            SpawnEnemies(!lastSpawnedCute, amountEnemies);
            lastSpawnedCute = !lastSpawnedCute;
            time = 0;
        }

        for (int i = 0; i < activeEnemies.Count; i++)
        {
            activeEnemies[i].EnemyFixedUpdate();
        }
    }

    public void SetCanTakeDamageToEnemies(bool toCuteEnemies)
    {
        for (int i = 0; i < poolObjectsManager.CuteEnemies.objects.Length; i++)
        {
            poolObjectsManager.CuteEnemies.objects[i].GetComponent<EnemyController>().canTakeDamage = toCuteEnemies;
        }
        for (int i = 0; i < poolObjectsManager.DarkEnemies.objects.Length; i++)
        {
            poolObjectsManager.DarkEnemies.objects[i].GetComponent<EnemyController>().canTakeDamage = !toCuteEnemies;
        }
    }

    private void PositionEnemy(GameObject enemy)
    {
        Transform spawnPoint;

        do
        {
            int randomNum = UnityEngine.Random.Range(0, spawnPoints.Length);
            spawnPoint = spawnPoints[randomNum];
        }
        while (Vector2.Distance(spawnPoint.position, target.position) < minDistanceFromTarget);

        enemy.transform.position = spawnPoint.position;
    }

    private void SpawnEnemies(bool cuteEnemies, int amount)
    {
        IEnumerator SpawnEnemiesAtTime()
        {
            int enemiesAmount = amount;
            do
            {
                GameObject enemy = poolObjectsManager.ActivateEnemy(cuteEnemies);
                EnemyController enemyController = enemy.GetComponent<EnemyController>();

                enemyController.SetData(damageRate, target);
                enemyController.onDie = (a) => 
                {
                    poolObjectsManager.DeactivateObject(a);
                    activeEnemies.Remove(a.GetComponent<EnemyController>());
                };

                PositionEnemy(enemy);

                activeEnemies.Add(enemyController);

                enemiesAmount--;

                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            while (enemiesAmount > 0);
        }

        StopAllCoroutines();

        StartCoroutine(SpawnEnemiesAtTime());
    }
}
