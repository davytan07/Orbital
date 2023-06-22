using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelSelection;
    public string OptionsMenu;
    public AudioSource ButtonSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Loads Level Selection Scene
    public void StartGame()
    {
        ClickButtonSound();
        SceneManager.LoadScene("LevelSelection");
    }

    // Loads Options Menu
    public void OpenControls()
    {
        ClickButtonSound();
        SceneManager.LoadScene("Controls");
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
