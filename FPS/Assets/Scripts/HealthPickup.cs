using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healthAmount = 40;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerHealth>().RecoverHealth(healthAmount);
            Debug.Log("player did what players do");
            Destroy(gameObject);
        }
    }
}
