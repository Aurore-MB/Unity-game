using UnityEngine;

public class CenterCanvas : MonoBehaviour
{
    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        if (canvas.renderMode == RenderMode.WorldSpace)
        {
            transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5; 
            transform.rotation = Camera.main.transform.rotation; 
        }
    }
}
