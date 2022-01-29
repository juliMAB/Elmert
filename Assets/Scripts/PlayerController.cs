using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterMovement, IDamageable
{
    private Vector3 movement;
    private int life = 3;

    public Action onDie = null;

    public void PlayerUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        AnimatorUpdate(movement);
    }
    public void PlayerFixedUpdate()
    {
        Move(movement);
    }

    public void TakeDamage()
    {
        life -= 1;
        Debug.Log("Player has taken damage.");

        if (life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        onDie?.Invoke();
        Debug.Log("Player has died.");
    }
}
