using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healthAmount = 40;
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
            FindObjectOfType<PlayerHealth>().RecoverHealth(healthAmount);
            Debug.Log("player did what players do");
            totaPickups.currNumOfPickups -= 1;
            Destroy(gameObject);
        }
    }
}
