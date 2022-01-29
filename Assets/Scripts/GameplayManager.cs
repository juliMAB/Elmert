using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GuilleUtils.PoolSystem;

public class GameplayManager : MonoBehaviour
{
    private bool pause = false;

    [SerializeField] private EnemiesManager enemiesManager = null;
    [SerializeField] private LinternController linternController = null;
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private UIGameplayController uIGameplayController = null;
    [SerializeField] private SoundManager SoundManager = null;

    private void Start()
    {
        Time.timeScale = 1;

        linternController.onChangedView = (cuteView) => 
        {
            enemiesManager.SetCanTakeDamageToEnemies(cuteView);
        };
        enemiesManager.onEnemyDeath = uIGameplayController.UpdateEnemiesKilled;
        enemiesManager.LoadSounds(SoundManager);
        playerController.onDie = EndGame;
        playerController.onDamage = uIGameplayController.UpdateLives;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(!pause);
        }

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
        PauseGame(true);
        uIGameplayController.DeactivatePauseButton();
        Debug.Log("The Game has ended");
    }

    public void PauseGame(bool pause)
    {
        uIGameplayController.Pause(pause);
        this.pause = pause;
        Time.timeScale = pause ? 0 : 1;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Game");
    }
}
