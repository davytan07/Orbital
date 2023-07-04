using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AudioSource shootSFX;
    [SerializeField] GameObject pauseMenu;

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
   
    public void Shoot()
    {
        if (!pauseMenu.activeSelf)
        {
            shootSFX.Play();
            PlayMuzzleFlash();
            Ammo.ReduceAmmo();
            ProcessRaycast();
        }
        
        
        
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1f);
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            // call a method on EnemyHealth that decreases the enemy's health
            if (target == null) return;
            if (ammoSlot.GetCurrentAmmo() > 0)
            {
                damage = target.GetCurrentHealth();
            }
            else
            {
                damage = 30f;
            }
            target.TakeDamage(damage);

        }
        else
        {
            return;
        }
    }
}
