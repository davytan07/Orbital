using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotAmmoPickup : MonoBehaviour
{
    [SerializeField] private int numOfAmmo = 5;
    WaveSpawner totaPickups;
    GameObject waveSpawner;

    private void Start()
    {
        waveSpawner = GameObject.FindWithTag("Spawner");
        if (waveSpawner != null)
        {
            totaPickups = waveSpawner.GetComponent<WaveSpawner>();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseAmmo(numOfAmmo);
            Ammo.ReduceAmmo = FindObjectOfType<Ammo>().ReduceOneShotAmmo;
            totaPickups.currNumOfPickups -= 1;
            Destroy(gameObject);
        }
    }
}
