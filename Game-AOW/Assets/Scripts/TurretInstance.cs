using UnityEngine;

public class TurretInstance : MonoBehaviour
{
    public TurretCharacteristics turretType;

    public void UpdateStats(TurretCharacteristics newTurretType)
    {
        turretType = newTurretType;
        Debug.Log("Updated turret stats: " + turretType.turretName);
    }
}
