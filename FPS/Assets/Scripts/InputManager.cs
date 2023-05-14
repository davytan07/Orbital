using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.FootActions foot;
    private PlayerMotor motor;
    private PlayerLook look;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        foot = playerInput.Foot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        
        foot.Jump.performed += ctx => motor.Jump();
        foot.Sprint.performed += ctx => motor.Sprint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(foot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate() {
        look.ProcessLook(foot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        foot.Enable();
    }

    private void onDisable()
    {
        foot.Disable();
    }
}
