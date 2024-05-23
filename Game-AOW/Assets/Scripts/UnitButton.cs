using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public UnitCharacteristics unit; // Caractéristiques de l'unité associée au bouton
    public bool isUpgradeButton; // Indique si ce bouton est pour la mise à niveau

    private UnitManager unitManager;
    private UpgradeManager upgradeManager;

    void Start()
    {
        // Trouver les managers dans la scène
        unitManager = FindObjectOfType<UnitManager>();
        upgradeManager = FindObjectOfType<UpgradeManager>();

        // Ajouter un listener pour le clic sur le bouton
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (isUpgradeButton)
        {
            // Sélectionner l'unité pour la mise à niveau
            upgradeManager.SelectUnit(unit);
        }
        else
        {
            // Ajouter l'unité à la file d'attente
            unitManager.QueueUnit(unit);
        }
    }
}
