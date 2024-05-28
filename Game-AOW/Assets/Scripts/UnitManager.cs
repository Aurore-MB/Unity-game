using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<UnitCharacteristics> unitTypes; // List of different unit types
    public Transform spawnPoint; // Spawn point for units
    public Transform targetPoint; // Target point for units
    public GameObject healthBarPrefab; // Prefab for the health bar

    private Queue<UnitCharacteristics> unitQueue = new Queue<UnitCharacteristics>();

    void Start()
    {
        // Initialization, if necessary
    }

    void Update()
    {
        // Check if there are units to create
        if (unitQueue.Count > 0)
        {
            StartCoroutine(SpawnUnit(unitQueue.Dequeue()));
        }
    }

    // Method to add a unit to the queue
    public void QueueUnit(UnitCharacteristics unit)
    {
        unitQueue.Enqueue(unit);
        Debug.Log("Unit added to queue: " + unit.unitName);
    }

    // Coroutine to spawn a unit after a certain time
    private IEnumerator SpawnUnit(UnitCharacteristics unit)
    {
        // Wait before spawning the unit (if necessary)
        yield return new WaitForSeconds(1.0f);

        // Spawn the unit at the spawn point
        GameObject newUnit = Instantiate(unit.unitPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("Unit spawned: " + unit.unitName);

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
        }

        // Ensure the new units use the updated stats
        UnitInstance unitInstance = newUnit.GetComponent<UnitInstance>();
        if (unitInstance != null)
        {
            unitInstance.UpdateStats(unit);
        }
    }
}
