using UnityEngine;
using UnityEngine.UI;

public class TurretButton : MonoBehaviour
{
    public TurretCharacteristics turret;
    private TurretManager turretManager;

    void Start()
    {
        turretManager = FindObjectOfType<TurretManager>();
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        turretManager.ConstructTurret(turret);
    }
}
