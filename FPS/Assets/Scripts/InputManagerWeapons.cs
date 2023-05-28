using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerWeapons : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.WeaponsActions weapon;
    private Weapon shoot;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        weapon = playerInput.Weapons;
        shoot = GetComponent<Weapon>();

        weapon.Shoot.performed += ctx => shoot.Shoot();
    }

   
    
    private void OnEnable()
    {
        
        weapon.Enable();
    }

    private void OnDisable()
    {
      
        weapon.Disable();
    }
}
