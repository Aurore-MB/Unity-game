using UnityEngine;
using UnityEngine.UI;

public class SpecialButton : MonoBehaviour
{
    public string sceneName; 

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            FindObjectOfType<SceneController>().LoadScene(sceneName);
        });
    }
}
