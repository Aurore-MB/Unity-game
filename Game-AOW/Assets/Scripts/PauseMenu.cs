using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu; 

    private void Start()
    {
        pauseMenu.SetActive(false); 
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

    public void ToggleOptionsMenu() 
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
}
