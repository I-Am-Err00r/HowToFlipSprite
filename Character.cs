using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Collider2D col;
    protected Character character;

    [HideInInspector]
    public bool isFacingLeft;
    [HideInInspector] 
    public bool isGrounded;
    [HideInInspector]
    public bool isJumping;

    public bool spawnFacingLeft;
    private Vector2 facingLeft;


    // Start is called before the first frame update
    void Start()
    {
        Initializtion();
    }

    protected virtual void Initializtion()
    {
        character = GetComponent<Character>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
        if(spawnFacingLeft)
        {
            transform.localScale = facingLeft;
            isFacingLeft = true;
        }
    }

    protected virtual void Flip()
    {
        if (isFacingLeft)
        {
            transform.localScale = facingLeft;
        }
        if (!isFacingLeft)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    protected virtual bool CollisionCheck(Vector2 direction, float distance, LayerMask collision)
    {
        RaycastHit2D[] hits = new RaycastHit2D[10];
        int numHits = col.Cast(direction, hits, distance);
        for (int i = 0; i < numHits; i++)
        {
            if ((1 << hits[i].collider.gameObject.layer & collision) != 0)
            {
                return true;
            }
        }
        return false;
    }
}
