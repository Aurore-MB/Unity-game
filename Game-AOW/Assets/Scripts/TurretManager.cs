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
    public float spawnInterval = 0.5f;
    public float spawnDuration = 5.0f;
    public Vector2 spawnAreaSize = new Vector2(10, 10); 

    public void ConstructTurret(TurretCharacteristics turret)
    {
        StartCoroutine(SpawnTurretRepeatedly(turret));
    }

    private IEnumerator SpawnTurretRepeatedly(TurretCharacteristics turret)
    {
        float endTime = Time.time + spawnDuration;
        while (Time.time < endTime)
        {
            SpawnTurret(turret);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnTurret(TurretCharacteristics turret)
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(turretPlacementArea.position.x - spawnAreaSize.x / 2, turretPlacementArea.position.x + spawnAreaSize.x / 2),
            turretPlacementArea.position.y + 10.0f,
            turretPlacementArea.position.z
        );

        GameObject newTurret = Instantiate(turret.turretPrefab, spawnPosition, Quaternion.identity);
        TurretInstance turretInstance = newTurret.GetComponent<TurretInstance>();
        if (turretInstance != null)
        {
            turretInstance.UpdateStats(turret);
        }
    }

    public void SellTurret(GameObject turretObject)
    {
        Destroy(turretObject);
    }
}
