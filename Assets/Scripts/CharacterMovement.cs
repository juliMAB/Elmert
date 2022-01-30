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
        }
        if (dir.x<0)
        {
            transform.rotation = new Quaternion(0, 180, 0,1);
        }
        if (dir.x > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 1);
        }
    }

    protected void Move(Vector2 dir)
    {
        rb.MovePosition(rb.position + (dir.normalized * moveSpeed * Time.fixedDeltaTime));
    }
}
