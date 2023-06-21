using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public HealthPickup pickup;
    [SerializeField] private int currWave;
    private int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    private bool nextwavetospawn = false;

    public List<Transform> spawnPoints = new List<Transform>();
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
        GenerateEnemies();

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
        if (currNumOfPickups < 6 && Random.Range(0,5) == 2)
        {
            Vector3 new_position = position + Vector3.up;
            Instantiate(pickup, new_position, Quaternion.identity);
            currNumOfPickups += 1;
        }
    }

}

[System.Serializable]

public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}