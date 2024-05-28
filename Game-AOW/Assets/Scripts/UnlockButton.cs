using UnityEngine;

public class UnlockButton : MonoBehaviour
{
    public UpgradeManager upgradeManager;

    public void OnClick()
    {
        upgradeManager.UnlockUnit();
    }
}
