using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GuilleUtils.PoolSystem;

public class GameplayManager : MonoBehaviour
{
    private bool pause = false;

    [SerializeField] private EnemiesManager enemiesManager = null;
    [SerializeField] private LinternController linternController = null;
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private UIGameplayController uIGameplayController = null;

    private void Start()
    {
        linternController.onChangedView = (cuteView) => 
        {
            enemiesManager.SetCanTakeDamageToEnemies(cuteView);
        };

        enemiesManager.onEnemyDeath = uIGameplayController.UpdateEnemiesKilled;

        playerController.onDie = EndGame;
        playerController.onDamage = uIGameplayController.UpdateLives;
    }

    private void Update()
    {
        if (pause) return;

        playerController.PlayerUpdate();
        linternController.LinternUpdate();
    }

    private void FixedUpdate()
    {
        if (pause) return;

        playerController.PlayerFixedUpdate();
        enemiesManager.EnemiesFixedUpdate();
    }

    private void EndGame()
    {
        pause = true;
        Time.timeScale = 0;
        Debug.Log("The Game has ended");
    }
}
