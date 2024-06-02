using UnityEngine;
using UnityEngine.UI;

public class SpecialButton : MonoBehaviour
{
    public string sceneName; // Le nom de la scène à charger

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            FindObjectOfType<SceneController>().LoadScene(sceneName);
        });
    }
}
