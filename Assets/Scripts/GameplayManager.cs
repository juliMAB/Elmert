using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GuilleUtils.PoolSystem;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private EnemiesManager enemiesManager = null;
    [SerializeField] private LinternController linternController = null;
    [SerializeField] private PlayerController playerController = null;

    private void Start()
    {
        linternController.onChangedView = (cuteView) => 
        {
            enemiesManager.SetCanTakeDamageToEnemies(cuteView);
        };

        playerController.onDie = EndGame;
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        Debug.Log("The Game has ended");
    }
}
