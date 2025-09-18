using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Transform> spawnLocations;
    public List<Enemy> spawnedEnemies;

    [SerializeField] private GameObject enemyPrefab;

    private float spawnCooldown;
    [SerializeField] private float cooldownDuration;
    [SerializeField] private int maxEnemyCount;

    // Update is called once per frame
    void Update()
    {
        if (spawnCooldown > 0)
        {
            spawnCooldown -= Time.deltaTime;
            return;
        }

        if (spawnedEnemies.Count < maxEnemyCount)
        {
            SpawnEnemy();
            spawnCooldown = cooldownDuration;
        }
    }

    void SpawnEnemy()
    {
        var randomSpawn = Random.Range(0, spawnLocations.Count);

        var enemy = Instantiate(enemyPrefab, spawnLocations[randomSpawn]);

        spawnedEnemies.Add(enemy.GetComponent<Enemy>());
    }
}
