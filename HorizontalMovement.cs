using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : Character
{
    public float speed;
    public float distanceToCollider;
    public LayerMask collisionLayer;

    private float horizontalInput;

    protected override void Initializtion()
    {
        base.Initializtion();
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
        else
        {
            horizontalInput = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y);
        if(horizontalInput > 0 && character.isFacingLeft)
        {
            character.isFacingLeft = false;
            Flip();
        }
        if(horizontalInput < 0 && !character.isFacingLeft)
        {
            character.isFacingLeft = true;
            Flip();
        }
        SpeedModifier();
    }

    private void SpeedModifier()
    {
        if((rb.velocity.x > 0 && CollisionCheck(Vector2.right, distanceToCollider, collisionLayer)) || (rb.velocity.x < 0 && CollisionCheck(Vector2.left, distanceToCollider, collisionLayer)))
        {
            rb.velocity = new Vector2(.01f, rb.velocity.y);
        }
    }
}
