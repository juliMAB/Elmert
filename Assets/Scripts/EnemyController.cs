using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterMovement, IDamageable
{
    public Transform target = null;

    private float life = 100;
    private float damageRate = 1f;

    public Action onDie = null;

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

    public void SetDamageRate(float damageRate)
    {
        this.damageRate = damageRate;
    }

    public void TakeDamage()
   {
        life -= damageRate;

        if (life <= 0)
        {
            Die();
        }
   }

    public void Die()
    {
        onDie?.Invoke();
    }
}
