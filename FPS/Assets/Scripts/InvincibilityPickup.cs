using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPickup : MonoBehaviour
{
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
            PlayerHealth.TakeDamage = FindObjectOfType<PlayerHealth>().NoTakeDamage;
            PlayerHealth.TakeDamage(1f);
            Debug.Log("player did what players do");
            totaPickups.currNumOfPickups -= 1;
            Destroy(gameObject);
        }
    }
}
