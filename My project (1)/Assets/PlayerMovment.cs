using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private  Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private Collider2D col;
    private bool isGrounded;
    private float dirX;

    public LayerMask groundLayer;
    public float moveSpeed = 7f;
    public float jumpForce = 8f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = col.IsTouchingLayers(groundLayer);

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        anim.SetBool("IsJumping", !isGrounded);
        anim.SetFloat("Running", rb.velocity.x);
        anim.SetFloat("Speed", Mathf.Abs(dirX));
        if (dirX > 0)
        {
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            sprite.flipX = true;
        }
    }
}
