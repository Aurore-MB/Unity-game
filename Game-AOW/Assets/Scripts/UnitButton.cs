using UnityEngine;
using UnityEngine.UI;

public class UnitButton : MonoBehaviour
{
    public UnitCharacteristics unit; // Caractéristiques de l'unité associée au bouton
    private UnitManager unitManager;

    void Start()
    {
        unitManager = FindObjectOfType<UnitManager>(); // Trouver le UnitManager dans la scène

        // Ajouter un listener pour le clic sur le bouton
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        unitManager.QueueUnit(unit);
    }
}
