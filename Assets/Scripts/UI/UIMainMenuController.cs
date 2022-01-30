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
    [SerializeField] private UIFader uIFader = null;


    private void Start()
    {
        SetActivePanel(PANEL.MAIN_MENU);
        uIFader.StartFader(false, null);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Tutorial");
    }


    public void GoToMainMenu()
    {
        uIFader.StartFader(true, () => 
        { 
            SetActivePanel(PANEL.MAIN_MENU); 
            uIFader.StartFader(false, null); 
        });
    }

    public void GoToCredits()
    {
       
        uIFader.StartFader(true, () => 
        { 
            SetActivePanel(PANEL.CREDITS);
            uIFader.StartFader(false, null);
        });
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
