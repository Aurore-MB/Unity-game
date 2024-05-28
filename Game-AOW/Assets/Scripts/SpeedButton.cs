using UnityEngine;

public class SpeedButton : MonoBehaviour
{
    public UpgradeManager upgradeManager;

    public void OnClick()
    {
        upgradeManager.UpgradeSpeed();
    }
}
