using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GuilleUtils.PoolSystem;

public class GameplayManager : MonoBehaviour
{
    //private bool cuteViewActive = true;
    [SerializeField] private EnemiesManager enemiesManager = null;
    [SerializeField] private LinternController linternController = null;

    private void Start()
    {
        linternController.onChangedView = (cuteView) => 
        {
            //cuteViewActive = cuteView;
            enemiesManager.SetCanTakeDamageToEnemies(cuteView);
        };

        //cuteViewActive = true;
    }
}
