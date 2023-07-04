using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 0;
    [SerializeField] TextMeshProUGUI ammoText;
    public delegate void ReduceAmmoFunc();
    public static ReduceAmmoFunc ReduceAmmo;

    private void OnEnable()
    {
        UnlimitedAmmo();
    }

    private void UnlimitedAmmo()
    {
        ReduceAmmo = ReducedAmmo;
    }

    public int GetCurrentAmmo()
    {
        return ammoAmount;
    }

    public void ReducedAmmo()
    {
        return;
    }

    public void ReduceOneShotAmmo()
    {
        ammoAmount--;
        UpdateAmmoText();
        if (GetCurrentAmmo() == 0)
        {
            UnlimitedAmmo();
        }
    }

    public void IncreaseAmmo(int numOfAmmo)
    {
        ammoAmount += numOfAmmo;
        UpdateAmmoText();
    }

    private void UpdateAmmoText()
    {
        ammoText.text = $"One Shot Ammo: {ammoAmount}";
    }
}
