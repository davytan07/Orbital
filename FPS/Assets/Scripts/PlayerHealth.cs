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
    public delegate void TakeDamageFunc(float damage);
    public static TakeDamageFunc TakeDamage;

    [Header("Invunerability Elements")]
    [SerializeField] float invunerableTime = 10f;

    private void Start()
    {
        TurnDamageOn();
    }
    //create a public method which reduces hitpoints by the amount of damage

    private void TurnDamageOn()
    {
        TakeDamage = DoTakeDamage;
    }
    private void DoTakeDamage(float damage)
    {
        hitPoints -= damage;
        UpdateHealth();
        GetComponent<DisplayDamage>().ShowDamageImpact();
        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    public void NoTakeDamage(float damage)
    {
        Invoke("TurnDamageOn", invunerableTime);
        GetComponent<DisplayInvincibility>().ShowInvincibility(invunerableTime);
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
