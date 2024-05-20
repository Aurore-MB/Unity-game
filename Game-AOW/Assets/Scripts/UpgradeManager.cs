using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public XPManager xpManager; // Référence au XPManager
    public GoldManager goldManager; // Référence au GoldManager
    public int healthUpgradeCost = 100;
    public int damageUpgradeCost = 100;
    public TextMeshProUGUI healthText; // Référence au texte de la santé
    public TextMeshProUGUI damageText; // Référence au texte des dégâts

    private int healthLevel = 1;
    private int damageLevel = 1;

    public void UpgradeHealth()
    {
        if (xpManager.UseXP(healthUpgradeCost) && goldManager.UseGold(healthUpgradeCost))
        {
            healthLevel++;
            UpdateHealthText();
        }
    }

    public void UpgradeDamage()
    {
        if (xpManager.UseXP(damageUpgradeCost) && goldManager.UseGold(damageUpgradeCost))
        {
            damageLevel++;
            UpdateDamageText();
        }
    }

    void UpdateHealthText()
    {
        healthText.text = "Health Level: " + healthLevel;
    }

    void UpdateDamageText()
    {
        damageText.text = "Damage Level: " + damageLevel;
    }
}
