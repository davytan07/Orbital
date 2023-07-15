using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    public AudioSource DeathSFX;
    PointsSystem ps;
    PlayerMotor motor;

    private void Start()
    {
        gameOverCanvas.enabled = false;
        motor = GetComponent<PlayerMotor>();
        ps = GetComponent<PointsSystem>();
    }

    public void HandleDeath()
    {
        DeathSFX.Play();
        motor.MuteMovement();
        motor.gameEnabled = false;
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        scoreText.text = $"SCORE:  {ps.CurrentPoints().ToString()}";
        highScoreText.text = $"HIGHSCORE:  {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
