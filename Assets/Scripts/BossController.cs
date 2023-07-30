using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float jumpForce = 8f;
    public float jumpInterval = 3f; // Time interval between jumps (in seconds)

    private Rigidbody2D rb;
    private bool canJump = true;
    public GameObject startPoint;
    public GameObject Player;

    private float jumpTimer = 0f;
    private bool isJumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
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
