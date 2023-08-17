using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
   private  Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX;
    public float moveSpeed = 7f;
    public float jumpForce = 8f;

    private enum MovementState { idle , running , jumping , fall }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Update(new Vector2(dirX * moveSpeed, rb.velocity.y));
    }

    // Update is called once per frame
    void Update(Vector2 vector2)
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = vector2;

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }    

          UpdateAnimotionState();
    }

    private void UpdateAnimotionState()
    {
        MovementState state;

        if (dirX > 0f)
        {
           state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
            

        anim.SetInteger("state",(int)state);
    }
}
