using UnityEngine;
using TMPro;

public class XPManager : MonoBehaviour
{
    public int currentXP = 0; // XP actuel du joueur
    public TextMeshProUGUI xpText; // Référence au TextMeshPro pour afficher l'XP actuel

    void Start()
    {
        UpdateXPText();
    }

    // Méthode pour gagner de l'XP
    public void GainXP(int amount)
    {
        currentXP += amount;
        UpdateXPText();
    }

    // Méthode pour utiliser de l'XP
    public bool UseXP(int amount)
    {
        if (currentXP >= amount)
        {
            currentXP -= amount;
            UpdateXPText();
            return true;
        }
        else
        {
            Debug.Log("Not enough XP");
            return false;
        }
    }

    // Méthode pour mettre à jour l'affichage de l'XP
    void UpdateXPText()
    {
        xpText.text = currentXP + " XP";
    }
}
