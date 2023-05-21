using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
   
    public void Shoot(bool clicked)
    {
        if (clicked)
        {
            RaycastHit hit;
            if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
            {
                Debug.Log("I hit this thing: " + hit.transform.name);
                // TODO: add some hit effects for visuals
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
}
