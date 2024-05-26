using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;   // Tableaux des prefabs des ennemis
    public Canvas enemyCanvas;          // Canvas du joueur adverse
    public GameObject healthBarPrefab;  // Prefab pour les barres de vie
    public float initialDelay = 3.0f;   // Délai avant l'apparition du premier ennemi
    public float spawnInterval = 10.0f; // Intervalle entre les apparitions des ennemis
    public Transform enemySpawnPoint;   // Point de spawn des ennemis
    public Transform enemyTargetPoint;  // Point cible des ennemis

    void Start()
    {
        Debug.Log("GameManager started");
        // Démarre une coroutine pour attendre avant d'activer les joueurs et de les déplacer
        StartCoroutine(WaitAndMovePlayers());
        // Démarrer la génération automatique d'ennemis
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator WaitAndMovePlayers()
    {
        Debug.Log("Coroutine WaitAndMovePlayers started");

        // Désactive les Canvas au début
        enemyCanvas.gameObject.SetActive(false);

        Debug.Log("Canvases deactivated");

        // Attendre le délai spécifié
        Debug.Log("Waiting for " + initialDelay + " seconds");
        yield return new WaitForSeconds(initialDelay);

        // Activer le Canvas des ennemis
        Debug.Log("Activating enemy Canvas");
        enemyCanvas.gameObject.SetActive(true);
    }

    IEnumerator SpawnEnemies()
    {
        // Attendre avant de générer le premier ennemi
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            // Choisir un prefab d'ennemi au hasard
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Créer un nouvel ennemi à la position de spawn
            GameObject newEnemy = Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
            newEnemy.SetActive(true);
            Debug.Log("New enemy spawned: " + newEnemy.name);

            // Configurer la position cible de l'ennemi
            EnemyMovementController movementController = newEnemy.GetComponent<EnemyMovementController>();
            if (movementController != null)
            {
                movementController.targetPosition = enemyTargetPoint.position;
                Debug.Log("Target position set for new enemy");
            }

            // Créer et configurer la barre de vie
            GameObject healthBar = Instantiate(healthBarPrefab, enemyCanvas.transform);
            HealthBarFollow healthBarFollow = healthBar.GetComponent<HealthBarFollow>();
            healthBarFollow.target = newEnemy.transform;
            newEnemy.GetComponent<Health>().healthBarObject = healthBar; // Assurez-vous que healthBarObject est assigné

            Debug.Log("HealthBar created and configured for new enemy");

            // Attendre avant de générer l'ennemi suivant
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
