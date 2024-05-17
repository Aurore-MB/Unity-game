using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Vector3 targetPosition;  // Position cible vers laquelle le joueur se déplacera
    public float speed = 1.0f;      // Vitesse de déplacement du joueur

    // Coroutine pour déplacer le joueur
    public IEnumerator MoveToTarget()
    {
        Debug.Log("Moving to target: " + targetPosition);
        // Tant que le joueur n'a pas atteint la position cible
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            // Déplace le joueur vers la position cible à chaque frame
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            Debug.Log("Current position: " + transform.position);
            yield return null; // Attend la prochaine frame
        }
        
        // Assure que le joueur atteint précisément la position cible
        Debug.Log("Reached target position: " + targetPosition);
        transform.position = targetPosition;
    }
}
