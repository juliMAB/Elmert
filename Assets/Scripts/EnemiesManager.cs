using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    private float timeBetweenEnemies = 1f;

    [SerializeField] private float damageRate = 1f;
    
    public Func<bool, GameObject> onSpawnEnemy = null;
    public Action<GameObject> onDespawnEnemy = null;

    private void SpawnEnemies(bool cuteEnemies, int amount)
    {
        IEnumerator SpawnEnemiesAtTime()//enemy.SetDamageRate(damageRate);
        {
            int enemiesAmount = amount;
            do
            {
                GameObject enemy = onSpawnEnemy.Invoke(cuteEnemies);
                enemy.GetComponent<EnemyController>().SetDamageRate(damageRate);

                enemiesAmount--;

                yield return new WaitForSeconds(timeBetweenEnemies);
            }
            while (enemiesAmount > 0);
        }

        StopAllCoroutines();

        StartCoroutine(SpawnEnemiesAtTime());
    }
}
