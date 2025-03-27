using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnerTimer;
    public float spawnInterval;

    // Update is called once per frame
    void Update()
    {
        spawnerTimer+= Time.deltaTime;
        if(spawnerTimer >= spawnInterval)
        {
            spawnerTimer = 0;
            SpawnerEnemy();
        }
    }
    void SpawnerEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
