using System.Collections;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public Vector3 targetPosition;  // Position cible vers laquelle l'ennemi se déplacera
    public float speed = 1.0f;      // Vitesse de déplacement de l'ennemi
    public float stoppingDistance = 0.1f; // Distance minimale avant de s'arrêter
    public int damageAmount = 10;   // Quantité de dégâts infligés à chaque attaque
    public float attackInterval = 4.0f; // Intervalle entre chaque attaque

    private Animator animator;      // Référence à l'Animator
    private Health health;          // Référence au composant Health
    private Coroutine attackCoroutine; // Référence à la coroutine d'attaque
    private Rigidbody2D rb;

    void Start()
    {
        // Obtenir la référence à l'Animator
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();

        // Configurer le Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 1; // Assurez-vous que la gravité est activée
            rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Empêche le personnage de tourner
        }

        // Positionner initialement le personnage sur le sol
        PositionOnGround();

        // Démarrer la coroutine de déplacement
        StartCoroutine(MoveToTarget());
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
        // Si l'ennemi entre en collision avec un joueur ou une maison
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerHouse"))
        {
            Debug.Log("Enemy collision detected with: " + other.gameObject.name);
            // Déclencher l'animation d'attaque
            animator.SetBool("isAttacking", true);
            // Arrêter le mouvement
            StopCoroutine(MoveToTarget());
            // Commencer l'attaque continue immédiatement
            if (attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(AttackContinuously(other.GetComponent<Health>()));
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Si l'ennemi sort de la collision avec un joueur ou une maison
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerHouse"))
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
        while (!targetHealth.IsDead() && !health.IsDead())
        {
            targetHealth.TakeDamage(damageAmount); // Utiliser la valeur de damageAmount
            yield return new WaitForSeconds(attackInterval); // Utiliser la valeur de attackInterval
        }
    }

    // Positionner initialement le personnage sur le sol
    private void PositionOnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + GetComponent<Collider2D>().bounds.extents.y, transform.position.z);
        }
    }
}
