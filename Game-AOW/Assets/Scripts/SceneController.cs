using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        GameDataManager.instance.SaveGameData(); // Sauvegarder les données avant de charger une nouvelle scène
        SceneManager.LoadScene(sceneName);
    }
}
