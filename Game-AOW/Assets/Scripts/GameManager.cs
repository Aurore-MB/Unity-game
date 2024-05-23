using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;           // Le joueur adverse
    public Canvas enemyCanvas;         // Canvas du joueur adverse
    public Canvas prefabsCanvas;       // Canvas pour les barres de vie des unités préfabriquées
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

        // Désactive les joueurs et les Canvas au début
        enemy.SetActive(false);
        enemyCanvas.gameObject.SetActive(false);
        prefabsCanvas.gameObject.SetActive(false);

        Debug.Log("Players and Canvases deactivated");

        // Attendre le délai spécifié
        Debug.Log("Waiting for " + delayBeforeStart + " seconds");
        yield return new WaitForSeconds(delayBeforeStart);

        // Activer le joueur adverse et son Canvas
        Debug.Log("Activating enemy and enemy Canvas");
        enemy.SetActive(true);
        enemyCanvas.gameObject.SetActive(true);

        // Activer la barre de vie de l'ennemi en la liant à sa position
        HealthBarFollow enemyHealthBarFollow = enemyCanvas.GetComponentInChildren<HealthBarFollow>();
        enemyHealthBarFollow.target = enemy.transform;
        enemy.GetComponent<Health>().healthBarObject = enemyHealthBarFollow.gameObject; // Assurez-vous que healthBarObject est assigné

        Debug.Log("Enemy HealthBar target set to " + enemyHealthBarFollow.target.name);

        // Démarrer la coroutine de déplacement sur le script EnemyMovementController du joueur adverse
        EnemyMovementController enemyMovementController = enemy.GetComponent<EnemyMovementController>();
        StartCoroutine(enemyMovementController.MoveToTarget());
    }
}
