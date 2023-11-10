using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float enemySpawnRange = 9.0f;
    public GameObject[] enemyPrefabs;
    int enemiesCount;
    int numberOfEnemiesPerWave = 1;
    public GameObject powerUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(numberOfEnemiesPerWave);
    }

    // Update is called once per frame
    void Update()
    {
        enemiesCount = FindObjectsOfType<Enemy>().Length;
        if (enemiesCount == 0)
        {
            numberOfEnemiesPerWave++;
            SpawnEnemyWave(numberOfEnemiesPerWave);
            Instantiate(powerUpPrefab, GenerateEnemySpawnPos(), powerUpPrefab.transform.rotation);
        }
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i= 0; i < enemiesToSpawn; i++)
        {
            int randomEnemyIndex = GenerateRandomEnemyIndex();
            Instantiate(enemyPrefabs[randomEnemyIndex], GenerateEnemySpawnPos(), enemyPrefabs[randomEnemyIndex].transform.rotation);
        }
    }
    private Vector3 GenerateEnemySpawnPos()
    {
        float randomPosX = Random.Range(-enemySpawnRange, enemySpawnRange);
        float randomPosZ = Random.Range(-enemySpawnRange, enemySpawnRange);
        Vector3 enemyRandomPosition = new Vector3(randomPosX, 0.15f, randomPosZ);
        return enemyRandomPosition;
    }
    private int GenerateRandomEnemyIndex()
    {
        int randInt = Random.Range(0, enemyPrefabs.Length);
        return randInt;
    }
}
