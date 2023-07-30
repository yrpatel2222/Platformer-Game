using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
        public float jumpForce = 8f;
        public float jumpInterval = 3f;

        private Rigidbody2D rb;
        private bool canJump = true;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            // Start the coroutine for automatic jumps
            StartCoroutine(AutoJump());
        }

        private void Update()
        {
            // Check for manual jump (you can implement boss's jump controls here if needed)
            if (canJump)
            {
                Jump();
            canJump = false;
            }
        }

        private void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

        private IEnumerator AutoJump()
        {
            while (true)
            {
                // Wait for the specified interval
                yield return new WaitForSeconds(jumpInterval);
                // Call the Jump() function to make the boss jump automatically
                Jump();
            }
        }
}
