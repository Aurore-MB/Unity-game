using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public Vector3 targetPosition;  // Position cible vers laquelle l'ennemi se déplacera
    public float speed = 1.0f;      // Vitesse de déplacement de l'ennemi
    public float stoppingDistance = 0.1f; // Distance minimale avant de s'arrêter
    private Animator animator;      // Référence à l'Animator
    private Health health;          // Référence au composant Health
    private Coroutine attackCoroutine; // Référence à la coroutine d'attaque

    void Start()
    {
        // Obtenir la référence à l'Animator
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();

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

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si l'ennemi entre en collision avec un joueur ou un obstacle
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Enemy collision detected with: " + other.gameObject.name);
            // Déclencher l'animation d'attaque
            animator.SetBool("isAttacking", true);
            // Arrêter le mouvement
            StopCoroutine(MoveToTarget());
            // Commencer l'attaque continue
            if (attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(AttackContinuously(other.GetComponent<Health>()));
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Si l'ennemi sort de la collision avec un joueur ou un obstacle
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Enemy collision ended with: " + other.gameObject.name);
            // Revenir à l'animation de marche
            animator.SetBool("isAttacking", false);
            // Reprendre le mouvement
            StartCoroutine(MoveToTarget());
            // Arrêter l'attaque continue
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;
            }
        }
    }

    // Coroutine pour attaquer continuellement
    private IEnumerator AttackContinuously(Health targetHealth)
    {
        while (true)
        {
            targetHealth.TakeDamage(10);
            yield return new WaitForSeconds(1.0f); // Attaque toutes les secondes, ajustez si nécessaire
        }
    }
}
