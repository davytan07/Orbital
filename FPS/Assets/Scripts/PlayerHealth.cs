using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Main Parameters")]
    public float hitPoints = 100f;
    public float maxHealth = 100f;

    [Header("Health UI Elements")]
    [SerializeField] private Image healthProgressUI;
    [SerializeField] private CanvasGroup healthSliderCanvas;
    //create a public method which reduces hitpoints by the amount of damage
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        UpdateHealth();
        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    public void RecoverHealth(float health)
    {
        hitPoints += health;
        UpdateHealth();
        if (hitPoints >= 100)
        {
            hitPoints = 100;
        }
    }
    public void UpdateHealth()
    {
        healthProgressUI.fillAmount = hitPoints / maxHealth;
        // updates health on the UI
    }

    public bool ZeroHealth()
    {
        return hitPoints == 0;
        // returns a bool on whether players health is 0
    }

    public bool FullHealth()
    {
        return hitPoints == 100;
        // returns a bool on whether players health is full
    }

}
