using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{

    protected Vector3 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.z = Input.GetAxisRaw("Jump");

        AnimatorUpdate(movement);
    }
    private void FixedUpdate()
    {
        Move(movement);
    }
}
