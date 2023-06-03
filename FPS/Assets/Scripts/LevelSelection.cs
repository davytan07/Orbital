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

    // Loads Hall (Kent Ridge) Map
    public void LoadHall()
    {
        SceneManager.LoadScene(Hall);
    }

    // Loads Field Map
    public void LoadField()
    {
        SceneManager.LoadScene(Field);
    }

    // Loads UTown Map
    public void LoadUTown()
    {
        SceneManager.LoadScene(UTown);
    }

    // Returns to Main Menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
