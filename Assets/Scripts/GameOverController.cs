using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    public void OnButtonClicked()
    {
       SceneManager.LoadScene(1);
       FindObjectOfType<LivesUI>().Start();
       PlayerController.sceneCount = 2;
       FindObjectOfType<LevelsUI>().Start();
    }

    public void OnBackToMainButtonClicked()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<LivesUI>().Start();
        PlayerController.sceneCount = 2;
        FindObjectOfType<LevelsUI>().Start();
    }
}
