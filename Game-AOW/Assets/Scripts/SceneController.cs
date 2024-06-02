using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        GameDataManager.instance.SaveGameData();
        SceneManager.LoadScene(sceneName);
    }
}
