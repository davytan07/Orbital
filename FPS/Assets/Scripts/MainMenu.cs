using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelSelection;

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
        SceneManager.LoadScene(LevelSelection);
    }

    // Loads Options Menu
    public void OptionsMenu()
    {

    }

    // Exits out of the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
