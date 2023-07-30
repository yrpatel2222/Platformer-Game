using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDown : MonoBehaviour
{
    // Start is called before the first frame update
    public float decreaseAmount = 0.5f; // Amount to decrease the object's size by in the y-direction
    private float originalYScale; // Store the original y-scale of the object

    private void Start()
    {
        originalYScale = transform.localScale.y; // Save the original y-scale of the object
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Decrease the object's y-scale
            Vector3 newScale = transform.localScale;
            newScale.y = originalYScale * decreaseAmount;
            transform.localScale = newScale;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reset the object's y-scale back to the original size
            Vector3 originalScale = transform.localScale;
            originalScale.y = originalYScale;
            transform.localScale = originalScale;
        }
    }
}
