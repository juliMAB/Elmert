using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GuilleUtils.PoolSystem;
using GuilleUtils.Score;

public class GameplayManager : MonoBehaviour
{
    private bool pause = false;

    [SerializeField] private EnemiesManager enemiesManager = null;
    [SerializeField] private LinternController linternController = null;
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private UIGameplayController uIGameplayController = null;
    [SerializeField] private SoundManager SoundManager = null;
    [SerializeField] private UIFader uIFader = null;
    [SerializeField] private HighscoreManager highscoreManager = null;

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

        uIFader.StartFader(false, null);
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
        uIGameplayController.Lose();
        this.pause = pause;
        Time.timeScale = pause ? 0 : 1;
        highscoreManager.SetScore(enemiesManager.EnemiesKilled);
    }

    public void GoToMainMenu()
    {
        uIFader.StartFader(true, () => { SceneManager.LoadScene("MainMenu"); });
    }

    public void ResetGame()
    {
        uIFader.StartFader(true, () => { SceneManager.LoadScene("Game"); });
    }
}
