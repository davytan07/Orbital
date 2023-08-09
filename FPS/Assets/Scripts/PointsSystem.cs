using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsSystem : MonoBehaviour
{
    private int currPoints = 0;
    [SerializeField] Text scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;


    // Start is called before the first frame update
    private void Start()
    {
        UpdateHighScoreText();
    }
    public void AddPoints(int pointsFromSpider)
    {
        currPoints += pointsFromSpider;
        scoreText.text = currPoints.ToString();
        UpdateHighScore();
    }

    public int CurrentPoints()
    {
        return currPoints;
    }

    public void UpdateHighScore()
    {
        if (currPoints > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", currPoints);
            UpdateHighScoreText();
        }
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = $"HIGHSCORE:  {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
