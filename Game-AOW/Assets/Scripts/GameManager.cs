using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Tableaux des prefabs des ennemis
    public HealthBarManager healthBarManager; // Référence au HealthBarManager
    public float initialDelay = 3.0f; // Délai avant l'apparition du premier ennemi
    public float spawnInterval = 10.0f; // Intervalle entre les apparitions des ennemis
    public Transform enemySpawnPoint; // Point de spawn des ennemis
    public Transform enemyTargetPoint; // Point cible des ennemis

    void Start()
    {
        Debug.Log("GameManager started");
        StartCoroutine(WaitAndMovePlayers());
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator WaitAndMovePlayers()
    {
        Debug.Log("Coroutine WaitAndMovePlayers started");

        // Attendre le délai spécifié
        Debug.Log("Waiting for " + initialDelay + " seconds");
        yield return new WaitForSeconds(initialDelay);

        // Activer le Canvas des ennemis (s'il est désactivé)
        if (!healthBarManager.mainCanvas.gameObject.activeSelf)
        {
            healthBarManager.mainCanvas.gameObject.SetActive(true);
        }
    }

    IEnumerator SpawnEnemies()
    {
        // Attendre avant de générer le premier ennemi
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

            healthBarManager.AddHealthBar(newEnemy.transform);

            Debug.Log("HealthBar created and configured for new enemy");

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
