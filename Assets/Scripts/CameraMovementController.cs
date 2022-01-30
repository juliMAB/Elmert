using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] private Transform player;

    public void FollowPlayer()
    {
        transform.position = Vector2.Lerp(transform.position, player.position, Time.deltaTime * 5);
    }
}
