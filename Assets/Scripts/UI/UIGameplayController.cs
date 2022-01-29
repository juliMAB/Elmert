using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplayController : MonoBehaviour
{
    [SerializeField] private GameObject[] lives = null;
    [SerializeField] private Text enemiesKilledText = null;

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
}
