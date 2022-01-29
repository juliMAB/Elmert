using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GuilleUtils.PoolSystem;

public class GameplayManager : MonoBehaviour
{
    private bool cuteViewActive = true;

    [SerializeField] private EnemiesManager enemiesManager = null;
    [SerializeField] private LinternController linternController = null;
    [SerializeField] private PoolObjectsManager poolObjectsManager = null;

    private void Start()
    {
        enemiesManager.onSpawnEnemy = poolObjectsManager.ActivateEnemy;
        enemiesManager.onDespawnEnemy = poolObjectsManager.DeactivateObject;

        linternController.onChangedView = (cuteView) => cuteViewActive = cuteView;

        cuteViewActive = true;
    }

    void Update()
    {
        
    }
}
