using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public Vector3 targetPosition;  // Position cible vers laquelle l'ennemi se déplacera
    public float speed = 1.0f;      // Vitesse de déplacement de l'ennemi
    public float stoppingDistance = 0.1f; // Distance minimale avant de s'arrêter

    void Start()
    {
        // Définissez ici la position cible de l'ennemi
        targetPosition = new Vector3(-10, 0, 0); // Exemple : déplacer l'ennemi vers la gauche
    }

    // Coroutine pour déplacer l'ennemi
    public IEnumerator MoveToTarget()
    {
        Debug.Log("Enemy moving to target: " + targetPosition);

        // Tant que l'ennemi n'a pas atteint la position cible ou qu'il est très proche
        while (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            // Déplace l'ennemi vers la position cible à chaque frame
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            Debug.Log("Enemy current position: " + transform.position);
            yield return null; // Attend la prochaine frame
        }
        
        // Assure que l'ennemi atteint précisément la position cible
        Debug.Log("Enemy reached target position: " + targetPosition);
        transform.position = targetPosition;
    }
}
