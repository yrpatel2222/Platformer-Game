using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public GameObject livesScreen;
    public TextMeshProUGUI livesText;
    public int startingLives = 3;
    private int currentLives;
    // Start is called before the first frame update
    void Start()
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
            Debug.Log("Game Over!");
        }
    }

    private void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = currentLives.ToString();
        }
    }
}