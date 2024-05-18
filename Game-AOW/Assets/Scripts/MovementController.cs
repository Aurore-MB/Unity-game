using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Vector3 targetPosition;  // Position cible vers laquelle le joueur se déplacera
    public float speed = 1.0f;      // Vitesse de déplacement du joueur
    public float stoppingDistance = 0.1f; // Distance minimale avant de s'arrêter
    private Animator animator;      // Référence à l'Animator

    void Start()
    {
        // Obtenir la référence à l'Animator
        animator = GetComponent<Animator>();

        // Définir la gravité à 0 si nécessaire
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0;
        }
    }

    // Coroutine pour déplacer le joueur
    public IEnumerator MoveToTarget()
    {
        Debug.Log("Moving to target: " + targetPosition);

        // Tant que le joueur n'a pas atteint la position cible ou qu'il est très proche
        while (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si le joueur entre en collision avec un ennemi ou un obstacle
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision detected with: " + other.gameObject.name);
            // Déclencher l'animation d'attaque
            animator.SetBool("isAttacking", true);
            // Arrêter le mouvement
            StopCoroutine(MoveToTarget());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Si le joueur sort de la collision avec un ennemi ou un obstacle
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision ended with: " + other.gameObject.name);
            // Revenir à l'animation de marche
            animator.SetBool("isAttacking", false);
            // Reprendre le mouvement
            StartCoroutine(MoveToTarget());
        }
    }
}
