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
    PlayerMotor motor;
    [SerializeField] AudioSource bgMusic;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        motor = GetComponent<PlayerMotor>();
    }

    public void TogglePause()
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

    // Pauses the game
    public void PauseGame()
    {
        bgMusic.Pause();
        motor.gameEnabled = false;
        motor.MuteMovement();
        // AudioListener.volume = 0f;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        ClickButtonSound();
        // Debug.Log(motor.gameEnabled);
    }

    // Resumes the game
    public void ResumeGame()
    {
        bgMusic.Play();
        motor.gameEnabled = true;
        // AudioListener.volume = 1f;
        Cursor.visible = false;
        ClickButtonSound();
        pauseMenu.SetActive(false);
        isPaused = false;
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
