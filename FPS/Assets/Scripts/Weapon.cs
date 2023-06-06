using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
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
        if (ammoSlot.GetCurrentAmmo() > 0 && !pauseMenu.activeSelf)
        {
            shootSFX.Play();
            PlayMuzzleFlash();
            ammoSlot.ReducedAmmo();
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
            target.TakeDamage(damage);

        }
        else
        {
            return;
        }
    }
}
