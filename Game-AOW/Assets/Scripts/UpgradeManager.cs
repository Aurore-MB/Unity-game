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
        
        SetUpgradeOptionsActive(false);

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
            selectedUnit.health += 10; 
            UpdateUnitInfo();
            UpdateExistingUnits();
        }
    }

    public void UpgradeDamage()
    {
        if (selectedUnit != null)
        {
            selectedUnit.damage += 5; 
            UpdateUnitInfo();
            UpdateExistingUnits();
        }
    }

    public void UpgradeSpeed()
    {
        if (selectedUnit != null)
        {
            selectedUnit.speed += 1; 
            UpdateUnitInfo();
            UpdateExistingUnits();
        }
    }

    public void UnlockUnit()
    {
        Debug.Log("Unit unlocked: " + selectedUnit.unitName);
        unlockButton.interactable = false; 

    void UpdateExistingUnits()
    {

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
