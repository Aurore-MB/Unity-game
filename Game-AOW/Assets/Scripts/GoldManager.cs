using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    public int currentGold = 0; // Or actuel du joueur
    public TextMeshProUGUI goldText; // Référence au TextMeshPro pour afficher l'or actuel

    void Start()
    {
        UpdateGoldText();
    }

    // Méthode pour gagner de l'or
    public void GainGold(int amount)
    {
        currentGold += amount;
        UpdateGoldText();
    }

    // Méthode pour utiliser de l'or
    public bool UseGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            UpdateGoldText();
            return true;
        }
        else
        {
            Debug.Log("Not enough gold");
            return false;
        }
    }

    // Méthode pour mettre à jour l'affichage de l'or
    void UpdateGoldText()
    {
        goldText.text = currentGold + " Gold";
    }
}
