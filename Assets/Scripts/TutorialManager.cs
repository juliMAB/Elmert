using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    private bool cameraFollowsPlayer = false;

    [SerializeField] private LinternController linternController = null;
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private CameraMovementController cameraController = null;
    [SerializeField] private TriggerObject[] startTrigger = null;
    [SerializeField] private TriggerObject[] endTrigger = null;
    [SerializeField] private TriggerObject startGameTrigger = null;
    [SerializeField] private UIFader uIFader = null;

    private void Start()
    {
        for (int i = 0; i < startTrigger.Length; i++)
        {
            startTrigger[i].action = () => cameraFollowsPlayer = true;
        }
        for (int i = 0; i < endTrigger.Length; i++)
        {
            endTrigger[i].action = () => cameraFollowsPlayer = false;
        }
        
        startGameTrigger.action = () =>
        {
            uIFader.StartFader(true, GoToGame);
        };
    }

    private void Update()
    {
        playerController.PlayerUpdate();
        linternController.LinternUpdate();
    }

    private void FixedUpdate()
    {
        playerController.PlayerFixedUpdate();

        if (cameraFollowsPlayer)
        {
            cameraController.FollowPlayer();
        }
    }

    private void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
