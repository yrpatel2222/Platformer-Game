using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 2f;

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Reset the character position to the starting point
            RestartScene();
            //FindObjectOfType<LivesUI>().DecreaseLives();
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
