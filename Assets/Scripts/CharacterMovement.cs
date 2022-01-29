using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;

    private Animator animator;

    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    protected void AnimatorUpdate(Vector3 dir)
    {
        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);
        animator.SetFloat("Speed", dir.sqrMagnitude);
    }

   
    protected void Move(Vector3 dir)
    {
        rb.MovePosition(rb.position + (dir * moveSpeed * Time.fixedDeltaTime));
    }
}
