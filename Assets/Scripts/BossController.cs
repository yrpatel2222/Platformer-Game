using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float jumpForce = 8f;
    public float jumpInterval = 3f; // Time interval between jumps (in seconds)
    public float moveRange = 2f; // Maximum distance boss can move left and right

    private Rigidbody2D rb;
    private bool canJump = true;
    public GameObject startPoint;
    public GameObject Player;

    private float jumpTimer = 0f;
    private bool isJumping = false;

    private bool moveRight = true; // Direction for boss movement
    private float originalX; // Original X position of the boss

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        // Store the original X position of the boss
        originalX = transform.position.x;
    }

    private void Update()
    {
        // Check for manual jump (you can implement boss's jump controls here if needed)
        if (canJump && !isJumping)
        {
            jumpTimer += Time.deltaTime;

            if (jumpTimer >= jumpInterval)
            {
                Jump();
                canJump = false;
                jumpTimer = 0f;
            }
        }

        // Move the boss left and right slightly
        MoveHorizontally();
    }

    private void MoveHorizontally()
    {
        if (moveRight)
        {
            // Move right
            transform.Translate(Vector2.right * Time.deltaTime);
            if (transform.position.x >= originalX + moveRange)
                moveRight = false;
        }
        else
        {
            // Move left
            transform.Translate(Vector2.left * Time.deltaTime);
            if (transform.position.x <= originalX - moveRange)
                moveRight = true;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Player.transform.position = startPoint.transform.position;
            FindObjectOfType<LivesUI>().DecreaseLives();
        }
    }
}
