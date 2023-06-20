using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] AudioSource EnemyDeath;
    [SerializeField] AudioSource EnemyNoise;
    [SerializeField] WaveSpawner enemyCount;
    GameObject player;
    PauseMenu pm;
    GameObject wavespawn;

    private float timeToFade = 3f;

    bool isDead = false;

    private void Start()
    {
        EnemyNoise.Play();
        
        wavespawn = GameObject.FindWithTag("Spawner");
        if (wavespawn != null)
        {
            enemyCount = wavespawn.GetComponent<WaveSpawner>();
        }

        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            pm = player.GetComponent<PauseMenu>();
        }
    }

    private void Update() 
    {
        if (EnemyNoise.isPlaying)
        {
            // Debug.Log(pm.isPaused);
            if (pm.isPaused)
            {
                EnemyNoise.Pause();
            }
            else
            {
                EnemyNoise.UnPause();
            }
        }            
    }
    public bool IsDead()
    {
        return isDead;
    }

    //create a public method which reduces hitpoints by the amount of damage
    public void TakeDamage(float damage)
    {
        
        //GetComponent<Animator>().SetBool("Walk Forward", false);
        //GetComponent<Animator>().SetTrigger("Take Damage");
        GetComponent<EnemyAI>().OnDamageTaken();
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        
        EnemyDeath.Play();
        EnemyNoise.Stop();
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
        Destroy(gameObject, timeToFade);
        enemyCount.totalEnemiesPresent -= 1;
    }

    


}
