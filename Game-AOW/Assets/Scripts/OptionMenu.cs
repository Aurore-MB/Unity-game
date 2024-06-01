using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] GameObject optionMenu;

    public void Pause()
    {
        optionMenu.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        optionMenu.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
