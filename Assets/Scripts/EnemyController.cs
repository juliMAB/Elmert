using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterMovement, IDamageable
{
    private Transform target = null;
    private float life = 100;
    private float damageRate = 1f;
    private Vector2 direction = Vector2.zero;
    private Vector2 lastDirection = Vector2.zero;

    public Action<GameObject> onDie = null;

    public bool canTakeDamage = true;

    private void FixedUpdate()
    {
        direction = Vector2.Lerp(lastDirection, target.position - transform.position, Time.fixedDeltaTime * 1.5f);
        Move(direction);
        lastDirection = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageableObject))
        {
            damageableObject.TakeDamage();
        }
    }

    public void SetData(float damageRate, Transform target)
    {
        this.damageRate = damageRate;
        this.target = target;
        life = 100;
        lastDirection = target.position - transform.position;
    }

    public void TakeDamage()
    {
        if (!canTakeDamage)
        {
            return;
        }

        life -= damageRate;
        Debug.Log("An enemy has taken damage.");

        if (life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        onDie?.Invoke(gameObject);
        Debug.Log("An enemy has died.");
    }
}
