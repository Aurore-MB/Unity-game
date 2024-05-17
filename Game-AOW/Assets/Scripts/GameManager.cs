using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;        // Le joueur
    public float delayBeforeStart = 3.0f; // Délai avant l'apparition du joueur et le début du déplacement

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager started");
        // Démarre une coroutine pour attendre avant d'activer le joueur et de le déplacer
        StartCoroutine(WaitAndMovePlayer());
    }

    // Coroutine pour attendre et déplacer le joueur
    IEnumerator WaitAndMovePlayer()
    {
        // Désactive le joueur au début
        player.SetActive(false);

        // Attendre le délai spécifié
        Debug.Log("Waiting for " + delayBeforeStart + " seconds");
        yield return new WaitForSeconds(delayBeforeStart);

        // Activer le joueur
        Debug.Log("Activating player");
        player.SetActive(true);

        // Démarrer la coroutine de déplacement sur le script MovementController du joueur
        MovementController movementController = player.GetComponent<MovementController>();
        StartCoroutine(movementController.MoveToTarget());
    }
}
