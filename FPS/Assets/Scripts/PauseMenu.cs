using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioSource ButtonSound;
    public bool isPaused;
    public string MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Pauses the game
    public void PauseGame()
    {
        ClickButtonSound();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    // Resumes the game
    public void ResumeGame()
    {
        ClickButtonSound();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    // Loads Options Menu
    public void OptionsMenu()
    {
        ClickButtonSound();
    }

    // Returns to Main Menu
    public void ReturnToMainMenu()
    {
        ClickButtonSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainMenu);
    }

    // Exits out of the game
    public void QuitGame()
    {
        ClickButtonSound();
        Application.Quit();
    }

    public void ClickButtonSound()
    {
        ButtonSound.Play();
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f); // Wait for 0.2 seconds
    }
}
