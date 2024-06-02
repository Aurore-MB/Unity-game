using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMultiplayerManagerPlayer1 : MonoBehaviour
{
    public List<UnitCharacteristics> unitTypes; 
    public Transform spawnPoint; 
    public Transform targetPoint;
    public GameObject healthBarPrefab; 
    public List<int> unitCosts = new List<int> { 50, 25, 30, 75 }; 

    private Queue<UnitCharacteristics> unitQueue = new Queue<UnitCharacteristics>();
    private GoldManager goldManager; 

    private List<GameObject> currentUnits = new List<GameObject>(); 
    private const int maxUnits = 10;

    void Start()
    {

        goldManager = GameObject.Find("Player1GoldManager").GetComponent<GoldManager>();
    }

    void Update()
    {
 
        if (unitQueue.Count > 0 && currentUnits.Count < maxUnits)
        {
            StartCoroutine(SpawnUnit(unitQueue.Dequeue()));
        }
    }


    public void QueueUnit(UnitCharacteristics unit)
    {
        int randomCost = unitCosts[Random.Range(0, unitCosts.Count)]; 
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


    private IEnumerator SpawnUnit(UnitCharacteristics unit)
    {
       
        yield return new WaitForSeconds(1.0f);


        GameObject newUnit = Instantiate(unit.unitPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("Unit spawned: " + unit.unitName);

       
        currentUnits.Add(newUnit);


        MovementController movementController = newUnit.GetComponent<MovementController>();
        if (movementController != null)
        {
            movementController.targetPosition = targetPoint.position;
            Debug.Log("Target position set for unit: " + targetPoint.position);
        }


        GameObject healthBar = Instantiate(healthBarPrefab, newUnit.transform);
        healthBar.transform.localPosition = new Vector3(0, 1.5f, 0); 
        healthBar.transform.localScale = new Vector3(-1.32f, 0.24f, 1f);
        Health health = newUnit.GetComponent<Health>();
        if (health != null)
        {
            health.healthBarPrefab = healthBarPrefab;
            health.onDeath += () => currentUnits.Remove(newUnit); 
        }

        UnitInstance unitInstance = newUnit.GetComponent<UnitInstance>();
        if (unitInstance != null)
        {
            unitInstance.UpdateStats(unit);
        }
    }
}
