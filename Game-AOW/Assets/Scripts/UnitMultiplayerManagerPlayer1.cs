using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMultiplayerManagerPlayer1 : MonoBehaviour
{
    public List<UnitCharacteristics> unitTypes; // List of different unit types
    public Transform spawnPoint; // Spawn point for player 1 units
    public Transform targetPoint; // Target point for player 1 units
    public GameObject healthBarPrefab; // Prefab for the health bar
    public List<int> unitCosts = new List<int> { 50, 25, 30, 75 }; // List of possible unit costs

    private Queue<UnitCharacteristics> unitQueue = new Queue<UnitCharacteristics>();
    private GoldManager goldManager; // Reference to the GoldManager for player 1

    private List<GameObject> currentUnits = new List<GameObject>(); // List of player 1's current units
    private const int maxUnits = 10; // Maximum number of units for player 1

    void Start()
    {
        // Find the GoldManager for player 1
        goldManager = GameObject.Find("Player1GoldManager").GetComponent<GoldManager>();
    }

    void Update()
    {
        // Check if there are units to create for player 1
        if (unitQueue.Count > 0 && currentUnits.Count < maxUnits)
        {
            StartCoroutine(SpawnUnit(unitQueue.Dequeue()));
        }
    }

    // Method to add a unit to the queue for player 1
    public void QueueUnit(UnitCharacteristics unit)
    {
        int randomCost = unitCosts[Random.Range(0, unitCosts.Count)]; // Get a random cost from the list
        if (goldManager.UseGold(randomCost))
        {
            if (currentUnits.Count < maxUnits)
            {
                unitQueue.Enqueue(unit);
                Debug.Log("Player 1 unit added to queue: " + unit.unitName + " with cost: " + randomCost);
            }
            else
            {
                Debug.Log("Player 1 reached maximum number of units, cannot add unit: " + unit.unitName);
            }
        }
        else
        {
            Debug.Log("Player 1 does not have enough gold to add unit: " + unit.unitName);
        }
    }

    // Coroutine to spawn a unit for player 1 after a certain time
    private IEnumerator SpawnUnit(UnitCharacteristics unit)
    {
        // Wait before spawning the unit (if necessary)
        yield return new WaitForSeconds(1.0f);

        // Spawn the unit at the spawn point
        GameObject newUnit = Instantiate(unit.unitPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("Unit spawned: " + unit.unitName);

        // Add the new unit to the list of current units
        currentUnits.Add(newUnit);

        // Set the target position of the unit
        MovementController movementController = newUnit.GetComponent<MovementController>();
        if (movementController != null)
        {
            movementController.targetPosition = targetPoint.position;
            Debug.Log("Target position set for unit: " + targetPoint.position);
        }

        // Add a health bar for the unit
        GameObject healthBar = Instantiate(healthBarPrefab, newUnit.transform);
        healthBar.transform.localPosition = new Vector3(0, 1.5f, 0); // Position it above the unit
        healthBar.transform.localScale = new Vector3(-1.32f, 0.24f, 1f); // Adjust scale to the required size

        Health health = newUnit.GetComponent<Health>();
        if (health != null)
        {
            health.healthBarPrefab = healthBarPrefab;
            health.onDeath += () => currentUnits.Remove(newUnit); // Remove the unit from the list when it dies
        }

        // Ensure the new units use the updated stats
        UnitInstance unitInstance = newUnit.GetComponent<UnitInstance>();
        if (unitInstance != null)
        {
            unitInstance.UpdateStats(unit);
        }
    }
}
