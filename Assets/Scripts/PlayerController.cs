using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterMovement, IDamageable
{
    private Vector3 movement;
    private int life = 3;
    private bool coolDownOn = false;
    private SoundManager soundManager;

    [SerializeField] private float coolDownTime = 1f;

    public Action onDie = null;
    public Action<int> onDamage = null;

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
        if (coolDownOn) return;

        IEnumerator StartCoolDown()
        {
            coolDownOn = true;
            yield return new WaitForSeconds(coolDownTime);
            coolDownOn = false;
        }

        StartCoroutine(StartCoolDown());
        if (soundManager==null)
        {
            soundManager = FindObjectOfType<SoundManager>();
        }
        soundManager.SelectAudio(2, 1.0f);
        life -= 1;
        onDamage?.Invoke(life);
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
