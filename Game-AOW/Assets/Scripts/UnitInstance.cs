using UnityEngine;

public class UnitInstance : MonoBehaviour
{
    public UnitCharacteristics unitType;
    private Health health;
    private MovementController movementController;

    void Start()
    {
        health = GetComponent<Health>();
        movementController = GetComponent<MovementController>();

        ApplyStats();
    }

    public void UpdateStats(UnitCharacteristics updatedUnit)
    {
        unitType = updatedUnit;
        ApplyStats();
    }

    void ApplyStats()
    {
        if (health != null)
        {
            health.SetHealth(unitType.health);
        }
        if (movementController != null)
        {
            movementController.speed = unitType.speed;
        }
        
    }
}
