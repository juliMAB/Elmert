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
    [SerializeField] private List<EnemyController> enemies = new List<EnemyController>();

    private void Start()
    {
        Time.timeScale = 1;
        linternController.onChangedView = (cuteView) =>
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].canTakeDamage = enemies[i].IsCute ? cuteView : !cuteView;
            }
        };

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
            GoToGame();
        };

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].SetData(1, playerController.gameObject.transform);
            enemies[i].onDie = (a) => 
            { 
                enemies.Remove(a.GetComponent<EnemyController>());
                Destroy(a);
            };
        }

        uIFader.StartFader(false, null);
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

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].EnemyFixedUpdate();
        }
    }

    public void GoToGame()
    {
        uIFader.StartFader(true, () => { SceneManager.LoadScene("Game"); });
    }
}
