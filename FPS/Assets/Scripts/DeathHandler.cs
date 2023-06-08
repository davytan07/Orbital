using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    public AudioSource DeathSFX;
    PlayerMotor motor;

    private void Start()
    {
        gameOverCanvas.enabled = false;
        motor = GetComponent<PlayerMotor>();
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
    }
}
