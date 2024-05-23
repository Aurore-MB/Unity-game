using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public Transform target;    // Le personnage que la barre de vie doit suivre
    public Vector3 offset = new Vector3(0, 1.5f, 0);  // Décalage de la barre de vie par rapport au personnage
    private RectTransform rectTransform;
    private Canvas canvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(target.position + offset);
            rectTransform.position = screenPoint;
        }
    }
}
