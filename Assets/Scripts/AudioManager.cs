using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource source1;
    public AudioSource source2;
    public AudioClip level1_4;
    public AudioClip level5;
    bool m_start = true;

    private static AudioManager instance;

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

        SceneManager.sceneLoaded += OnSceneLoaded; // Register the event callback
    }


    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unregister the event callback when the object is destroyed
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "level5")
        {
            AudioLevel5();
        }
        else if (SceneManager.GetActiveScene().name == "LoadScene" || SceneManager.GetActiveScene().name == "StartScene")
        {
            source1.Stop();
            source2.Stop();
            m_start = true;
        }
        else if (scene.name != "LoadScene" && scene.name != "level5" && m_start == true)
        {
            AudioLevel1_4();
        }
    }

    private void AudioLevel1_4()
    {
        source1.clip = level1_4;
        source1.Play();
        source2.Stop();
        m_start = false;
    }

    private void AudioLevel5()
    {
        //source2.clip = level5;
        //source2.Play();
        source1.Stop();
        m_start = false;
    }
}

