using UnityEngine;
using UnityEngine.UI;
using TMPro;  

public class GameSpeedController : MonoBehaviour
{
    public TextMeshProUGUI speedText; // Référence au TextMeshPro pour afficher la vitesse actuelle
    private int currentSpeedLevel = 1; // Niveau de vitesse actuel
    private int[] speedLevels = { 1, 2, 3 }; // Différents niveaux de vitesse possibles

    void Start()
    {
        UpdateSpeedText();
    }

    public void ChangeSpeed()
    {
        // Change le niveau de vitesse actuel
        currentSpeedLevel = (currentSpeedLevel + 1) % speedLevels.Length;
        // Met à jour le timeScale en fonction du niveau de vitesse actuel
        Time.timeScale = speedLevels[currentSpeedLevel];
        UpdateSpeedText();
    }

    void UpdateSpeedText()
    {
        // Met à jour le texte pour afficher la vitesse actuelle
        speedText.text = "Speed x" + speedLevels[currentSpeedLevel];
    }
}
