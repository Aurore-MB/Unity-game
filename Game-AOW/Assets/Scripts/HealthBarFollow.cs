using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public Transform target;    // Le personnage que la barre de vie doit suivre
    public Vector3 offset = new Vector3(0, 1.5f, 0);  // Décalage de la barre de vie par rapport au personnage

    void Start()
    {
        Debug.Log(gameObject.name + " HealthBarFollow started");
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            Debug.Log(gameObject.name + " following target " + target.name + " at position " + target.position);
        }
        else
        {
            Debug.Log(gameObject.name + " has no target assigned.");
        }
    }
}
