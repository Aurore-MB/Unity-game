using System.Collections;
using UnityEngine;

public class MultiplayerGameManager : MonoBehaviour
{
    public GameObject player1Prefab; // Prefab du joueur 1
    public GameObject player2Prefab; // Prefab du joueur 2
    public Transform player1SpawnPoint; // Point de spawn pour le joueur 1
    public Transform player2SpawnPoint; // Point de spawn pour le joueur 2
    public GameObject healthBarPrefab; // Prefab pour les barres de vie
    public Transform player1TargetPoint; // Point cible pour le joueur 1
    public Transform player2TargetPoint; // Point cible pour le joueur 2

    private GameObject player1;
    private GameObject player2;

    void Start()
    {
        Debug.Log("MultiplayerGameManager started");
        SpawnPlayers();
    }

    void SpawnPlayers()
    {
        // Spawn le joueur 1
        player1 = Instantiate(player1Prefab, player1SpawnPoint.position, Quaternion.identity);
        player1.GetComponent<MovementController>().targetPosition = player1TargetPoint.position;

        // Configurer la barre de vie du joueur 1
        GameObject healthBar1 = Instantiate(healthBarPrefab, player1.transform);
        healthBar1.transform.localPosition = new Vector3(0, 1.5f, 0);
        healthBar1.transform.localScale = new Vector3(-1.32f, 0.24f, 1f);
        player1.GetComponent<Health>().healthBarPrefab = healthBarPrefab;

        // Spawn le joueur 2
        player2 = Instantiate(player2Prefab, player2SpawnPoint.position, Quaternion.identity);
        player2.GetComponent<MovementController>().targetPosition = player2TargetPoint.position;

        // Configurer la barre de vie du joueur 2
        GameObject healthBar2 = Instantiate(healthBarPrefab, player2.transform);
        healthBar2.transform.localPosition = new Vector3(0, 1.5f, 0);
        healthBar2.transform.localScale = new Vector3(-1.32f, 0.24f, 1f);
        player2.GetComponent<Health>().healthBarPrefab = healthBarPrefab;

        Debug.Log("Players spawned");
    }
}
