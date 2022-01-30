using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplayController : MonoBehaviour
{
    [SerializeField] private GameObject[] lives = null;
    [SerializeField] private Text enemiesKilledText = null;
    [SerializeField] private GameObject pauseButton = null;
    [SerializeField] private GameObject resumeButton = null;
    [SerializeField] private GameObject pausePanel = null;
    [SerializeField] private GameObject lostText = null;

    private void Start()
    {
        Pause(false);
        lostText.SetActive(false);
    }

    public void UpdateLives(int livesAmount)
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].SetActive(livesAmount > i);
        }
    }

    public void UpdateEnemiesKilled(int enemiesKilled)
    {
        enemiesKilledText.text = enemiesKilled.ToString();
    }

    public void Pause(bool pause)
    {
        pausePanel.SetActive(pause);
        pauseButton.SetActive(!pause);
        resumeButton.SetActive(pause);
    }

    public void DeactivatePauseButton()
    {
        pauseButton.SetActive(false);
        resumeButton.SetActive(false);
    }

    public void Lose()
    {
        lostText.SetActive(true);
    }
}
