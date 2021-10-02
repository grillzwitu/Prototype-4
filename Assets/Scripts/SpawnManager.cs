using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab; // variable for the enemy prefabs
    private float spawnRange = 9; // variable for the enemy spawn position limit
    public int enemyCount; //variable to count the current number of enemies in the game
    public int waveNumber = 1; //variable to handle the enemy wave number
    public GameObject powerupPrefab; //variable to handle spawning of power ups


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); //instantiate spawning of power ups
        SpawnEnemyWave(waveNumber);// spawn enemies
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; //finds and counts objects of type Enemy(objects that that have the enemy script applied to them)

        if(enemyCount == 0) //if there are no more enemies in the game.
        {
            waveNumber++; //increment wave number
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); //instantiate spawning of power ups
            SpawnEnemyWave(waveNumber); //spawn enemies based on current wave number
        }
    }

    //method to spawn enemies
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        //spawn three enemies at once
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); // instantiate the the spawn manager to spawn enemies
        }
    }

    // Method to generate random spawn position
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange); //variable for the enemy sapwn positon on the x axis
        float spawnPosZ = Random.Range(-spawnRange, spawnRange); //variable for the enemy sapwn positon on the z axis

        Vector3 randomSpawnPos = new Vector3(spawnPosX, 0, spawnPosZ); //variable for the enemy spawn position

        return randomSpawnPos;
    }


}
