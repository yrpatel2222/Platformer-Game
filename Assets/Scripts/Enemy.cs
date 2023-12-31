using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject Player;
    
    public float movementRange = 2f; // Range of movement in units
    public float movementSpeed = 2f; // Speed of movement in units per second

    private bool movingRight = true; // Flag to determine movement direction
    private Vector2 startingPosition; // Starting position of the enem
    

    void Start()
    {
        startingPosition = transform.position; // Store the starting position
    }

    void Update()
    {
        // Calculate the movement direction based on the movingRight flag
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;

        // Calculate the target position for the enemy to move to
        Vector2 targetPosition = startingPosition + (direction * movementRange);

        // Move the enemy towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // Check if the enemy has reached the target position
        if (Mathf.Approximately(Vector2.Distance(transform.position, targetPosition), 0f))
        {
            // Reverse the movement direction
            movingRight = !movingRight;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = collision.collider.GetComponent<Rigidbody2D>();

            // Check if the player is above the enemy and moving downwards
            if (playerRigidbody.velocity.y < 0 && collision.contacts[0].point.y > transform.position.y)
            {
                // Stomp on the enemy
                Destroy(gameObject);  // Remove the enemy from the scene
            }
            else
            {
                Player.transform.position = startPoint.transform.position;
                FindObjectOfType<LivesUI>().DecreaseLives();
            }
        }
    }
}