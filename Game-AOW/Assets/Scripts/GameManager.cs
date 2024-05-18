using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;          // Le joueur
    public GameObject enemy;           // Le joueur adverse
    public GameObject playerHealthBar; // Barre de vie du joueur
    public GameObject enemyHealthBar;  // Barre de vie de l'ennemi
    public float delayBeforeStart = 3.0f; // Délai avant l'apparition du joueur et le début du déplacement

    void Start()
    {
        Debug.Log("GameManager started");
        // Démarre une coroutine pour attendre avant d'activer les joueurs et de les déplacer
        StartCoroutine(WaitAndMovePlayers());
    }

    IEnumerator WaitAndMovePlayers()
    {
        Debug.Log("Coroutine WaitAndMovePlayers started");
        
        // Désactive les joueurs et les barres de vie au début
        player.SetActive(false);
        enemy.SetActive(false);
        playerHealthBar.SetActive(false);
        enemyHealthBar.SetActive(false);
        
        Debug.Log("Players and health bars deactivated");

        // Attendre le délai spécifié
        Debug.Log("Waiting for " + delayBeforeStart + " seconds");
        yield return new WaitForSeconds(delayBeforeStart);

        // Activer le joueur et sa barre de vie
        Debug.Log("Activating player and player health bar");
        player.SetActive(true);
        playerHealthBar.SetActive(true);

        // Activer la barre de vie du joueur en la liant à sa position
        HealthBarFollow playerHealthBarFollow = playerHealthBar.GetComponent<HealthBarFollow>();
        playerHealthBarFollow.target = player.transform;
        Debug.Log("Player HealthBar target set to " + playerHealthBarFollow.target.name);

        // Démarrer la coroutine de déplacement sur le script MovementController du joueur
        MovementController movementController = player.GetComponent<MovementController>();
        StartCoroutine(movementController.MoveToTarget());

        // Activer le joueur adverse et sa barre de vie
        Debug.Log("Activating enemy and enemy health bar");
        enemy.SetActive(true);
        enemyHealthBar.SetActive(true);

        // Activer la barre de vie de l'ennemi en la liant à sa position
        HealthBarFollow enemyHealthBarFollow = enemyHealthBar.GetComponent<HealthBarFollow>();
        enemyHealthBarFollow.target = enemy.transform;
        Debug.Log("Enemy HealthBar target set to " + enemyHealthBarFollow.target.name);

        // Démarrer la coroutine de déplacement sur le script EnemyMovementController du joueur adverse
        EnemyMovementController enemyMovementController = enemy.GetComponent<EnemyMovementController>();
        StartCoroutine(enemyMovementController.MoveToTarget());
    }
}
