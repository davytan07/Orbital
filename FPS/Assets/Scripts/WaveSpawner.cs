using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<Enemy> enemies = new();
    public List<PickUp> pickups = new();
    [SerializeField] private int currWave;
    private int waveValue;
    private int pickupValue;
    public List<GameObject> enemiesToSpawn = new();
    public List<GameObject> pickupsToSpawn = new();
    private bool nextwavetospawn = false;
    public List<Transform> spawnPoints = new();
    Transform spawnLocation;
    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    public int totalEnemiesPresent = 0;
    public int currNumOfPickups = 0;

    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(NextWave());
    }
    
    public void GenerateWave()
    {
        waveValue = currWave * 10;
        pickupValue = currWave * 5;
        GenerateEnemies();
        GeneratePickups();

        spawnInterval = waveDuration / enemiesToSpawn.Count; //gives a fixed time between each enemies
        waveTimer = waveDuration; // wave duration is read only

    }
    

    public void GenerateEnemies()
    {
        // create a temporary list of enemies to generate 
        //
        // in a loop grab a random enemy
        // see if we can afford it
        // if possible, add it to the list and deduct cost.

        //repeat..

        // when points are zero, leave the loop
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue == 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    private void SpawnWave()
    {
        if (spawnTimer <= 0)
        {
            //spawn an enemy
            if (enemiesToSpawn.Count > 0)
            {
                int randSpawnLoc = Random.Range(0, spawnPoints.Count);
                spawnLocation = spawnPoints[randSpawnLoc];
                Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity); // spawn first enemy in our list
                totalEnemiesPresent += 1;
                enemiesToSpawn.RemoveAt(0); // remove it
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0; // if no enemies remain, end wave
                nextwavetospawn = false;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }


    public void GeneratePickups()
    {
        // create a temporary list of pickups to generate 
        // in a loop grab a random pickup
        // see if we can afford it
        // if possible, add it to the list and deduct cost.

        //repeat..

        // when points are zero, leave the loop
        List<GameObject> generatedPickups = new();
        while (pickupValue > 0)
        {
            int randPickupId = Random.Range(0, pickups.Count);
            int randPickupCost = pickups[randPickupId].cost;

            if (pickupValue - randPickupCost >= 0)
            {
                generatedPickups.Add(pickups[randPickupId].pickupPrefab);
                pickupValue -= randPickupCost;
            }
            else if (pickupValue == 0)
            {
                break;
            }
        }
        pickupsToSpawn.Clear();
        pickupsToSpawn = generatedPickups;
    }

    IEnumerator NextWave()
    {
        // generate wave
        // spawn wave
        // once wave is cleared,
        // currWave + 1 and generate next wave
        if (CurrentWaveDefeated())
        {
            currWave += 1;
            GenerateWave();
            nextwavetospawn = true;
        }
        yield return new WaitUntil(() => nextwavetospawn == true);
        SpawnWave();
        
    }

    private bool CurrentWaveDefeated()
    {
        if (totalEnemiesPresent == 0 && enemiesToSpawn.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SpawnPickup(Vector3 position)
    {
        if (pickupsToSpawn.Count >0 && currNumOfPickups < 6 && Random.Range(0,5) == 2)
        {
            Vector3 new_position = position + Vector3.up; //spawn location to be 1 unit higher than enemy's transform
            Instantiate(pickupsToSpawn[0], new_position, Quaternion.identity); //spawn the pickup
            currNumOfPickups += 1;
            pickupsToSpawn.RemoveAt(0); //remove it
        }
    }

}

[System.Serializable]

public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}

[System.Serializable]
public class PickUp
{
    public GameObject pickupPrefab;
    public int cost;
}