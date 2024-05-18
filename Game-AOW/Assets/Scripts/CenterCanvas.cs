using UnityEngine;

public class CenterCanvas : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        if (canvas.renderMode == RenderMode.WorldSpace)
        {
            transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5; // Ajustez la distance selon vos besoins
            transform.rotation = Camera.main.transform.rotation; // Alignez la rotation avec la caméra
        }
    }
}
