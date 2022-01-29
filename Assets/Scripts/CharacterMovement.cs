using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator animator;
	

    protected void AnimatorUpdate(Vector3 dir)
    {
        if (animator)
        {

            animator.SetFloat("Horizontal", dir.x);
            animator.SetFloat("Vertical", dir.y);
            animator.SetFloat("Speed", dir.sqrMagnitude);
            if (dir.x!=0)
            {
            transform.localScale = new Vector3( dir.x,transform.localScale.y,transform.localScale.y);
            }
        }
    }

    protected void Move(Vector2 dir)
    {
        rb.MovePosition(rb.position + (dir.normalized * moveSpeed * Time.fixedDeltaTime));
    }
}
