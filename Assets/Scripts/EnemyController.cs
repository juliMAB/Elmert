using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterMovement, IDamageable
{
    public Transform target = null;

    private float life = 100;

    public Action onDie = null;

    private void Update()
    {
        Move(target.position - transform.position);
    }

   public void TakeDamage(float damage)
   {
        life -= damage;

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
