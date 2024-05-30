using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public Transform turretPlacementArea;
    public TurretCharacteristics flamingTurret;
    public TurretCharacteristics darkTurret;
    public TurretCharacteristics sacredTurret;
    public TurretCharacteristics naturalTurret;
    public TurretCharacteristics aquaticTurret;
    public List<int> unitCosts = new List<int> { 50, 25, 75, 30, 20 };

    public void ConstructTurret(TurretCharacteristics turret)
    {
        if (CanConstructTurret(turret))
        {
            GameObject newTurret = Instantiate(turret.turretPrefab, turretPlacementArea.position, Quaternion.identity);
            TurretInstance turretInstance = newTurret.GetComponent<TurretInstance>();
            if (turretInstance != null)
            {
                turretInstance.UpdateStats(turret);
            }
        }
        else
        {
            Debug.LogWarning("Cannot construct turret: " + turret.turretName);
        }
    }

    private bool CanConstructTurret(TurretCharacteristics turret)
    {
        return true; // Add construction conditions here if needed
    }

    public void SellTurret(GameObject turretObject)
    {
        Destroy(turretObject);
    }
}
