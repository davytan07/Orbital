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
    private WeaponZoom zoom;


    void Awake()
    {
        playerInput = new PlayerInput();
        foot = playerInput.Foot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        zoom = GetComponent<WeaponZoom>();

        foot.Jump.performed += ctx => motor.Jump();
        foot.WeaponZoom.performed += ctx => zoom.ProcessZoom();
    }
    void FixedUpdate()
    {
        motor.ProcessMove(foot.Movement.ReadValue<Vector2>(), foot.Sprint.ReadValue<float>() > 0.1f );
    }
    private void LateUpdate() 
    {
        look.ProcessLook(foot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        foot.Enable();
    }

    private void OnDisable()
    {
        foot.Disable();
    }
}
