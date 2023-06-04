using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    public float playerStamina = 100f;
    public float maxStamina = 100f;
   
    [Header("Stamina Regen Parameters")]
    [Range(0, 50)] [SerializeField] float staminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] float staminaRegen = 0.5f;

    

    [Header("Stamina UI Elements")]
    [SerializeField] private Image staminaProgressUI;
    [SerializeField] private CanvasGroup sliderCanvas;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    public void UpdateStamina(int value)
    {
        staminaProgressUI.fillAmount = playerStamina / maxStamina;
        if (value == 0)
        {
            sliderCanvas.alpha = 0;
        }
        else
        {
            sliderCanvas.alpha = 1;
        }
    }

    public void RegenStamina()
    {
        if (playerStamina <= maxStamina - 0.01)
        {
            playerStamina += staminaRegen * Time.deltaTime;
            UpdateStamina(1);
        }
        else
        {
            playerStamina = maxStamina;
            UpdateStamina(0);
        }
    }

    public void DrainStamina()
    {
        if (playerStamina <= 0)
        {
            playerStamina = 0f;
            return;
        }
        playerStamina -= staminaDrain * Time.deltaTime;
        UpdateStamina(1);

        
    }

    public bool zeroStamina()
    {
        return playerStamina == 0;
    }

    public bool fullStamina()
    {
        return playerStamina == 100;
    }
}
