using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Jump n run
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck; // empty GameObject at the feet of the player
    public LayerMask groundLayer; // create and assign
    private Rigidbody2D rb; // add rigidbody2d and collider2d (gravityScale = 2)
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;

    // Top Down
    //public float moveSpeed = 5f;
    //private Rigidbody2D rb; // add rigidbody2d and collider2d (gravityScale = 0)

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        JumpNRunMovement();
        //TopDownMovement();
    }

    private void JumpNRunMovement()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Player movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Player jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void TopDownMovement()
    {
        // Player movement
        float moveInputX = Input.GetAxis("Horizontal");
        float moveInputY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveInputX, moveInputY);

        // Normalize the movement vector to prevent faster diagonal movement
        movement = movement.normalized;

        rb.velocity = movement * moveSpeed;
    }

    public void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPos.x, newPos.y, 0f);

        rb.velocity = Vector2.zero;
    }
}
