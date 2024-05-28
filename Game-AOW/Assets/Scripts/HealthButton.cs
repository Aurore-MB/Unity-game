using UnityEngine;

public class HealthButton : MonoBehaviour
{
    public UpgradeManager upgradeManager;

    public void OnClick()
    {
        upgradeManager.UpgradeHealth();
    }
}
