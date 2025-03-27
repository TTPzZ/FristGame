using UnityEngine;
using System.Collections.Generic;


public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;
        public float spawnerTimer;
        public float spawnInterval;
        public int enemiesPerWave;
        public int spawnerEnemyCount;
    }

    public List<Wave> waves;
    public int waveNumber;

    public Transform minPos;
    public Transform maxPos;

    void Update()
    {
        if(Player_controller.Instance.gameObject.activeSelf== true)
       { waves[waveNumber].spawnerTimer += Time.deltaTime;
        if (waves[waveNumber].spawnerTimer >= waves[waveNumber].spawnInterval)
        {
            waves[waveNumber].spawnerTimer = 0;
            SpawnerEnemy();
        }
        if (waves[waveNumber].spawnerEnemyCount >= waves[waveNumber].enemiesPerWave)
        {
            waves[waveNumber].spawnerEnemyCount = 0;
            if (waves[waveNumber].spawnInterval > 0.2f)
            {
                waves[waveNumber].spawnInterval *= 0.4f;
            }
            waveNumber++;
        }
        if (waveNumber >= waves.Count)
        {
            waveNumber = 0;
        }}
    }
    private void SpawnerEnemy()
    {
        Instantiate(waves[waveNumber].enemyPrefab, RandomSpawner(), transform.rotation);
        waves[waveNumber].spawnerEnemyCount++;
    }

    private Vector2 RandomSpawner()
    {
        Vector2 spawnPoint;
        if (Random.Range(0f, 1f) > 0.5f)
        {
            spawnPoint.x = Random.Range(minPos.position.x, maxPos.position.x);
            if (Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.y = minPos.position.y;
            }
            else
            {
                spawnPoint.y = maxPos.position.y;
            }
        }
        else
        {
            spawnPoint.y = Random.Range(minPos.position.y, maxPos.position.y);
            if (Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.x = minPos.position.x;
            }
            else
            {
                spawnPoint.x = maxPos.position.x;
            }

        }
        return spawnPoint;
    }
}
