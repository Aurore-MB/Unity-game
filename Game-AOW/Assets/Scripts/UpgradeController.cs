using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    public Canvas upgradeCanvas; // Référence au Canvas des mises à niveau
    public Button upgradeButton; // Référence au bouton "Upgrades"

    void Start()
    {
        // Assurez-vous que le Canvas des mises à niveau est désactivé au début
        upgradeCanvas.gameObject.SetActive(false);

        // Ajouter un listener pour le clic sur le bouton "Upgrades"
        upgradeButton.onClick.AddListener(ToggleUpgradeCanvas);
    }

    void ToggleUpgradeCanvas()
    {
        // Activer ou désactiver le Canvas des mises à niveau
        upgradeCanvas.gameObject.SetActive(!upgradeCanvas.gameObject.activeSelf);
    }
}
