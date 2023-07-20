using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    public Transform startPoint;  // The starting point of the level

    // OnTriggerEnter2D is called when the character collides with the death barrier
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Reset the character position to the starting point
            RestartScene();
            FindObjectOfType<LivesUI>().DecreaseLives();
            // You can also reset any other variables or states related to the character here
        }
    }

    private void RestartScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Restart the scene
        SceneManager.LoadScene(currentSceneIndex);
    }
}

