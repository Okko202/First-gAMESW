using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;

    public Animator animator;

    private CharacterController controller;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private float fallSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f) * moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        fallSpeed = moveDirection.y;
        animator.SetFloat("FallSpeed", fallSpeed);
    }
}
