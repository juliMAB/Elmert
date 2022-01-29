using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterMovement, IDamageable
{
    private Transform target = null;
    private float life = 100;
    private float damageRate = 1f;

    public Action<GameObject> onDie = null;

    public bool canTakeDamage = true;

    private void Update()
    {
        Move(target.position - transform.position);
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
