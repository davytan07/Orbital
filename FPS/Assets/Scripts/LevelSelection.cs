using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public string Hall;
    public string Field;
    public string UTown;
    public string MainMenu;
    public AudioSource ButtonSound;

    // Loads Hall (Kent Ridge) Map
    public void LoadHall()
    {
        ClickButtonSound();
        SceneManager.LoadScene(Hall);
    }

    // Loads Field Map
    public void LoadField()
    {
        ClickButtonSound();
        SceneManager.LoadScene(Field);
    }

    // Loads UTown Map
    public void LoadUTown()
    {
        ClickButtonSound();
        SceneManager.LoadScene(UTown);
    }

    // Returns to Main Menu
    public void BackToMainMenu()
    {
        ClickButtonSound();
        SceneManager.LoadScene(MainMenu);
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
