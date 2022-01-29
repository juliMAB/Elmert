using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GuilleUtils.PoolSystem;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private PoolObjectsManager poolObjectsManager = null;

    private float timeBetweenEnemies = 1f;

    [SerializeField] private float damageRate = 1f;

    private void SpawnEnemies(bool cuteEnemies, int amount)
    {
        IEnumerator SpawnEnemiesAtTime()//enemy.SetDamageRate(damageRate);
        {
            int enemiesAmount = amount;
            do
            {
                GameObject enemy = poolObjectsManager.ActivateEnemy(cuteEnemies);
                EnemyController enemyController = enemy.GetComponent<EnemyController>();

                enemyController.SetDamageRate(damageRate);
                enemyController.onDie = poolObjectsManager.DeactivateObject;

                enemiesAmount--;

                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            while (enemiesAmount > 0);
        }

        StopAllCoroutines();

        StartCoroutine(SpawnEnemiesAtTime());
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
}
