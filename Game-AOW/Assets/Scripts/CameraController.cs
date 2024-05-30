using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5.0f; // Vitesse de déplacement de la caméra
    public bool enableAutomaticMovement = false; // Contrôle si la caméra doit se déplacer automatiquement

    public float minPositionX = 0f; // Limite gauche
    public float maxPositionX = 7f; // Limite droite

    void Update()
    {
        // Calcul du mouvement horizontal
        float moveHorizontal = enableAutomaticMovement ? speed : Input.GetAxis("Horizontal") * speed;
        float newPositionX = transform.position.x + moveHorizontal * Time.deltaTime;

        // Clamper la position X pour qu'elle ne dépasse pas les limites
        newPositionX = Mathf.Clamp(newPositionX, minPositionX, maxPositionX);

        // Mettre à jour la position de la caméra en respectant les limites
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

        Debug.Log("Camera position updated to: " + transform.position);
    }
}
