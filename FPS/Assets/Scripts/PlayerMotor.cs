using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private StaminaBar staminaBar;
    private bool isGrounded;
    private float gravity = -9.8f;
    private float groundedForce = -2f;
    public float jumpHeight = 2f;
    public bool gameEnabled;
    public bool jumpEnabled;


    [Header("Stamina Speed Parameters")]
    [HideInInspector] bool hasRegenerated = true;
    [HideInInspector] float speed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float slowSpeed = 2f;
    [SerializeField] private float normalSpeed = 5f;
    [SerializeField] private AudioSource walkingSFX;
    [SerializeField] private AudioSource sprintingSFX;
    [SerializeField] private AudioSource slowWalkingSFX;
    [SerializeField] private AudioSource jumpSFX;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        staminaBar = GetComponent<StaminaBar>();
        gameEnabled = true;
        jumpEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input, bool isKeyHeld)
    {
        if (isKeyHeld && hasRegenerated && !hasNoInput(input)) // prevents sprinting on the spot
        {
            // if player is constantly holding sprint key, ensures that sprint sound still plays
            if (!sprintingSFX.isPlaying)
            {
                sprintingSFX.Play();
            }
            if (!isGrounded) // Stops sprinting sound if player is in the air
            {
                sprintingSFX.Stop();
            }
            Sprint();
        }
        else if (!isKeyHeld && hasRegenerated)
        {
            sprintingSFX.Play();
            speed = normalSpeed;
            staminaBar.RegenStamina();
        }
        else
        {   
            speed = slowSpeed;
            staminaBar.RegenStamina();
            if (staminaBar.fullStamina())
            {
                MuteMovement();
                hasRegenerated = true;
                if (!jumpEnabled)
                {
                    jumpEnabled = true;
                }
            }

        }
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = groundedForce;
        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded && gameEnabled && jumpEnabled)
        {
            jumpSFX.Play();
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Sprint()
    {
        speed = sprintSpeed;
        staminaBar.DrainStamina();
        if (staminaBar.zeroStamina())
        {
            MuteMovement();
            slowWalkingSFX.Play();
            hasRegenerated = false;
            jumpEnabled = false;
        }
    }

    public void MuteMovement()
    {
        slowWalkingSFX.Pause();
        sprintingSFX.Pause();
    }

    // Helper function to check if there is any movement input before sprinting
    public bool hasNoInput(Vector2 input)
    {
        // Debug.Log(input.x);
        // Debug.Log(input.y);
        return input.x == 0 && input.y == 0;
    }
}
