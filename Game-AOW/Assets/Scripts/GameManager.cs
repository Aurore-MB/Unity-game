using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;        // Le joueur
    public GameObject enemy;         // Le joueur adverse
    public float delayBeforeStart = 3.0f; // Délai avant l'apparition du joueur et le début du déplacement

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager started");
        // Démarre une coroutine pour attendre avant d'activer les joueurs et de les déplacer
        StartCoroutine(WaitAndMovePlayers());
    }

    // Coroutine pour attendre et déplacer les joueurs
    IEnumerator WaitAndMovePlayers()
    {
        // Désactive les joueurs au début
        player.SetActive(false);
        enemy.SetActive(false);

        // Attendre le délai spécifié
        Debug.Log("Waiting for " + delayBeforeStart + " seconds");
        yield return new WaitForSeconds(delayBeforeStart);

        // Activer le joueur
        Debug.Log("Activating player");
        player.SetActive(true);
        // Démarrer la coroutine de déplacement sur le script MovementController du joueur
        MovementController movementController = player.GetComponent<MovementController>();
        StartCoroutine(movementController.MoveToTarget());

        // Activer le joueur adverse
        Debug.Log("Activating enemy");
        enemy.SetActive(true);
        // Démarrer la coroutine de déplacement sur le script EnemyMovementController du joueur adverse
        EnemyMovementController enemyMovementController = enemy.GetComponent<EnemyMovementController>();
        StartCoroutine(enemyMovementController.MoveToTarget());
    }
}
