using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private LinternController linternController = null;
    [SerializeField] private PlayerController playerController = null;

    private void Update()
    {
        playerController.PlayerUpdate();
        linternController.LinternUpdate();
    }

    private void FixedUpdate()
    {
        playerController.PlayerFixedUpdate();
    }
}
