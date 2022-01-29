using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenuController : MonoBehaviour
{ 
    enum PANEL
    { 
        MAIN_MENU, 
        CREDITS 
    }

    [SerializeField] private GameObject mainMenuPanel = null;
    [SerializeField] private GameObject creditsPanel = null;

    private void Start()
    {
        GoToMainMenu();
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }


    public void GoToMainMenu()
    {
        SetActivePanel(PANEL.MAIN_MENU);
    }

    public void GoToCredits()
    {
        SetActivePanel(PANEL.CREDITS);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void SetActivePanel(PANEL panel)
    {
        mainMenuPanel.SetActive(panel == PANEL.MAIN_MENU);
        creditsPanel.SetActive(panel == PANEL.CREDITS);
    }
}
