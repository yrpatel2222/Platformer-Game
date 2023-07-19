using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    public Transform startPoint;  // The starting point of the level

    // OnTriggerEnter2D is called when the character collides with the death barrier
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Reset the character position to the starting point
            collision.transform.position = startPoint.position;
            // You can also reset any other variables or states related to the character here
        }
    }
}

