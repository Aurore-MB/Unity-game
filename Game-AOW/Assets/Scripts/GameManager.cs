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
        GameDataManager.instance.LoadGameData(); // Charger les données du jeu au début du niveau
        UpdateUI(); // Mettre à jour l'interface utilisateur avec les données chargées
        InitializeHealth(); // Initialiser la santé de base des joueurs et des ennemis

        StartCoroutine(WaitAndMovePlayers());
        StartCoroutine(SpawnEnemies());
    }

    void UpdateUI()
    {
        // Mettez à jour l'interface utilisateur avec les données chargées
        // Par exemple :
        // goldText.text = GameDataManager.instance.gameData.gold.ToString();
        // xpText.text = GameDataManager.instance.gameData.xp.ToString();
    }

    void InitializeHealth()
    {
        // Assurez-vous que les objets de santé de base sont correctement référencés
        HouseHealth playerBaseHealth = FindObjectOfType<HouseHealth>(true); // Changer en fonction de votre implémentation
        HouseHealth enemyBaseHealth = FindObjectOfType<HouseHealth>(false); // Changer en fonction de votre implémentation

        if (playerBaseHealth != null)
        {
            playerBaseHealth.SetHealth(GameDataManager.instance.gameData.playerBaseHealth);
        }

        if (enemyBaseHealth != null)
        {
            enemyBaseHealth.SetHealth(GameDataManager.instance.gameData.enemyBaseHealth);
        }
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
