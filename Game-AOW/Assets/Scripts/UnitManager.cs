using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<UnitCharacteristics> unitTypes; // Liste des différents types d'unités
    public Transform spawnPoint; // Point de spawn des unités
    public Transform targetPoint; // Point cible vers lequel les unités se déplaceront
    public GameObject healthBarPrefab; // Préfabriqué pour la barre de vie
    public Canvas healthBarCanvas; // Canvas pour les barres de vie

    private Queue<UnitCharacteristics> unitQueue = new Queue<UnitCharacteristics>();

    void Start()
    {
        // Initialisation, si nécessaire
    }

    void Update()
    {
        // Vérifier s'il y a des unités à créer
        if (unitQueue.Count > 0)
        {
            StartCoroutine(SpawnUnit(unitQueue.Dequeue()));
        }
    }

    // Méthode pour ajouter une unité à la file d'attente
    public void QueueUnit(UnitCharacteristics unit)
    {
        unitQueue.Enqueue(unit);
        Debug.Log("Unit added to queue: " + unit.unitName);
    }

    // Coroutine pour créer une unité après un certain temps
    private IEnumerator SpawnUnit(UnitCharacteristics unit)
    {
        // Attendre avant de créer l'unité (si nécessaire)
        yield return new WaitForSeconds(1.0f);

        // Créer l'unité à la position de spawn
        GameObject newUnit = Instantiate(unit.unitPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("Unit spawned: " + unit.unitName);

        // Configurer la position cible de l'unité
        MovementController movementController = newUnit.GetComponent<MovementController>();
        if (movementController != null)
        {
            movementController.targetPosition = targetPoint.position;
            Debug.Log("Target position set for unit: " + targetPoint.position);
        }

        // Créer et configurer la barre de vie
        GameObject healthBar = Instantiate(healthBarPrefab, healthBarCanvas.transform);
        HealthBarFollow healthBarFollow = healthBar.GetComponent<HealthBarFollow>();
        healthBarFollow.target = newUnit.transform;
        newUnit.GetComponent<Health>().healthBarObject = healthBar; // Assurez-vous que healthBarObject est assigné
    }
}
