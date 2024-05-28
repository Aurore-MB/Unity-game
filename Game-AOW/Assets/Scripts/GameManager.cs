using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs
    public float initialDelay = 3.0f; // Delay before the first enemy appears
    public float spawnInterval = 10.0f; // Interval between enemy spawns
    public Transform enemySpawnPoint; // Spawn point for enemies
    public Transform enemyTargetPoint; // Target point for enemies
    public GameObject healthBarPrefab; // Reference to the health bar prefab

    void Start()
    {
        Debug.Log("GameManager started");
        StartCoroutine(WaitAndMovePlayers());
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator WaitAndMovePlayers()
    {
        Debug.Log("Coroutine WaitAndMovePlayers started");

        // Wait for the specified delay
        Debug.Log("Waiting for " + initialDelay + " seconds");
        yield return new WaitForSeconds(initialDelay);
    }

    IEnumerator SpawnEnemies()
    {
        // Wait before spawning the first enemy
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            GameObject newEnemy = Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
            newEnemy.SetActive(true);
            Debug.Log("New enemy spawned: " + newEnemy.name);

            EnemyMovementController movementController = newEnemy.GetComponent<EnemyMovementController>();
            if (movementController != null)
            {
                movementController.targetPosition = enemyTargetPoint.position;
                Debug.Log("Target position set for new enemy");
            }

            Health health = newEnemy.GetComponent<Health>();
            if (health != null)
            {
                health.healthBarPrefab = healthBarPrefab;
            }

            Debug.Log("HealthBar created and configured for new enemy");

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
