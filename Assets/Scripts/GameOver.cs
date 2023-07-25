using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void OnButtonClicked()
    {
       SceneManager.LoadScene(1);
       FindObjectOfType<LivesUI>().Start();
       PlayerController.sceneCount = 2;
       
    }
}
