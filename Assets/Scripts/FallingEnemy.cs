using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 2f; // Adjust the speed as needed

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move the enemy to the right
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RestartScene();
            FindObjectOfType<LivesUI>().DecreaseLives();
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
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
