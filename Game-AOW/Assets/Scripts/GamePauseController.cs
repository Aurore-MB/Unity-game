using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePauseController : MonoBehaviour
{
    public TextMeshProUGUI pauseText; // Référence au TextMeshPro pour afficher l'état actuel de la pause
    private bool isPaused = false; // État actuel de la pause

    void Start()
    {
        UpdatePauseText();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        UpdatePauseText();
    }

    void UpdatePauseText()
    {
        pauseText.text = isPaused ? "Resume" : "Pause";
    }
}
