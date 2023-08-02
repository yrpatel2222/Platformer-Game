using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public GameObject livesScreen;
    public TextMeshProUGUI livesText;
    public int startingLives;
    private int currentLives;
    public GameObject Player;
    public int maxLives;

    private static LivesUI instance;

    private void Awake()
    {
        // Singleton pattern: If an instance already exists, destroy this duplicate.
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    public void Start()
    {
        currentLives = startingLives;
        UpdateLivesText();
    }

    public void DecreaseLives(int amount = 1)
    {
        currentLives -= amount;
        UpdateLivesText();

        if (currentLives <= 0)
        {
            // Add game over logic here
            // For example: Reload the level, show game over screen, etc.
            SceneManager.LoadScene(0);
        }
    }

    public void IncreaseLives(int amount = 1)
    {
        currentLives += amount;

        // Clamp the lives value to the maximum allowed
        currentLives = Mathf.Clamp(currentLives, 0, maxLives);

        UpdateLivesText();
    }

    private void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = currentLives.ToString();
        }
    }
}
