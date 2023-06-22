using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBGM : MonoBehaviour
{
    private static MenuBGM instance;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        AudioSource audioSource = MenuBGM.instance.GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name != "MainMenu"
            && SceneManager.GetActiveScene().name != "LevelSelection"
            && SceneManager.GetActiveScene().name != "Controls")
        {
            audioSource.Stop();
        }
        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
