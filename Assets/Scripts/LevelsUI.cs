using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelsUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI levelsText;
    public int startLevel;
    private int currentLevel;

    public void Start()
    {
        currentLevel = startLevel;
        UpdateLevelsText();
    }

    public void NextLevel()
    {
        currentLevel++;
        UpdateLevelsText();
    }

    private void UpdateLevelsText()
    {
        if (levelsText != null)
        {
            levelsText.text = currentLevel.ToString();
        }
    }

}
