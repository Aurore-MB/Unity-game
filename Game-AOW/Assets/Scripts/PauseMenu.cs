using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu; // Verifica que este campo esté correctamente asignado en el Inspector

    private void Start()
    {
        pauseMenu.SetActive(false); // Asegura que el menú esté inactivo al inicio
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToggleOptionsMenu() // Nueva función para abrir/cerrar el menú de opciones
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
}
