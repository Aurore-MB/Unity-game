using UnityEngine;

public class DamageButton : MonoBehaviour
{
    public UpgradeManager upgradeManager;

    public void OnClick()
    {
        upgradeManager.UpgradeDamage();
    }
}
