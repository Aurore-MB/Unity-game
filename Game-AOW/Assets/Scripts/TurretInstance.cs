using UnityEngine;

public class TurretInstance : MonoBehaviour
{
    public TurretCharacteristics turretType;

    public void UpdateStats(TurretCharacteristics newTurretType)
    {
        turretType = newTurretType;
        // Update turret stats based on the new characteristics
        Debug.Log("Updated turret stats: " + turretType.turretName);
    }
}
