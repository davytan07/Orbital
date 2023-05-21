using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.FootActions foot;
    private PlayerInput.WeaponsActions weapon;
    private PlayerMotor motor;
    private PlayerLook look;
    private Weapon shoot;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        foot = playerInput.Foot;
        weapon = playerInput.Weapons;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        shoot = GetComponent<Weapon>();
        
        foot.Jump.performed += ctx => motor.Jump();
        foot.Sprint.performed += ctx => motor.Sprint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(foot.Movement.ReadValue<Vector2>());
    }

    private void Update()
    {
        shoot.Shoot(weapon.Shoot.IsPressed());
    }
    private void LateUpdate() 
    {
        look.ProcessLook(foot.Look.ReadValue<Vector2>());
        
    }

    private void OnEnable()
    {
        foot.Enable();
        weapon.Enable();
    }

    private void OnDisable()
    {
        foot.Disable();
        weapon.Disable();
    }
}
