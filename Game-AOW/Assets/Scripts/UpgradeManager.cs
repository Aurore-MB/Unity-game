using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public TextMeshProUGUI unitNameText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI speedText;
    public Button healthUpgradeButton;
    public Button damageUpgradeButton;
    public Button speedUpgradeButton;
    public Button unlockButton;

    private UnitCharacteristics selectedUnit;

    void Start()
    {
        // Désactiver les boutons d'amélioration et le texte des statistiques au début
        SetUpgradeOptionsActive(false);

        // Ajouter des listeners aux boutons
        healthUpgradeButton.onClick.AddListener(UpgradeHealth);
        damageUpgradeButton.onClick.AddListener(UpgradeDamage);
        speedUpgradeButton.onClick.AddListener(UpgradeSpeed);
        unlockButton.onClick.AddListener(UnlockUnit);
    }

    public void SelectUnit(UnitCharacteristics unit)
    {
        selectedUnit = unit;
        UpdateUnitInfo();
        SetUpgradeOptionsActive(true);
    }

    void UpdateUnitInfo()
    {
        if (selectedUnit != null)
        {
            unitNameText.text = "Nom de l'Unité: " + selectedUnit.unitName;
            healthText.text = "Health: " + selectedUnit.health;
            damageText.text = "Damage: " + selectedUnit.damage;
            speedText.text = "Speed: " + selectedUnit.speed;
        }
    }

    void SetUpgradeOptionsActive(bool isActive)
    {
        healthUpgradeButton.gameObject.SetActive(isActive);
        damageUpgradeButton.gameObject.SetActive(isActive);
        speedUpgradeButton.gameObject.SetActive(isActive);
        unlockButton.gameObject.SetActive(isActive);
        unitNameText.gameObject.SetActive(isActive);
        healthText.gameObject.SetActive(isActive);
        damageText.gameObject.SetActive(isActive);
        speedText.gameObject.SetActive(isActive);
    }

    public void UpgradeHealth()
    {
        if (selectedUnit != null)
        {
            selectedUnit.health += 10; // Augmente la santé de l'unité de 10 (ajustez la valeur selon vos besoins)
            UpdateUnitInfo();
            UpdateExistingUnits();
        }
    }

    public void UpgradeDamage()
    {
        if (selectedUnit != null)
        {
            selectedUnit.damage += 5; // Augmente les dégâts de l'unité de 5 (ajustez la valeur selon vos besoins)
            UpdateUnitInfo();
            UpdateExistingUnits();
        }
    }

    public void UpgradeSpeed()
    {
        if (selectedUnit != null)
        {
            selectedUnit.speed += 1; // Augmente la vitesse de l'unité de 1 (ajustez la valeur selon vos besoins)
            UpdateUnitInfo();
            UpdateExistingUnits();
        }
    }

    public void UnlockUnit()
    {
        // Logique pour déverrouiller l'unité, par exemple rendre l'unité disponible dans le jeu
        Debug.Log("Unit unlocked: " + selectedUnit.unitName);
        unlockButton.interactable = false; // Désactive le bouton de déverrouillage après utilisation
    }

    void UpdateExistingUnits()
    {
        // Parcourir toutes les instances de l'unité présente et mettre à jour leurs statistiques
        UnitInstance[] existingUnits = FindObjectsOfType<UnitInstance>();
        foreach (var unit in existingUnits)
        {
            if (unit.unitType.unitName == selectedUnit.unitName)
            {
                unit.UpdateStats(selectedUnit);
            }
        }
    }
}
