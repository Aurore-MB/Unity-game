using System.Collections;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector3 targetPosition;
    public float stoppingDistance = 0.1f;
    public int damageAmount = 10;
    public float attackInterval = 1.0f;

    private Animator animator;
    private Health health;
    private Coroutine attackCoroutine;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 1;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        PositionOnGround();
        StartCoroutine(MoveToTarget());
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal2") * speed;
        float moveVertical = Input.GetAxis("Vertical2") * speed;
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    public IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyHouse"))
        {
            animator.SetBool("isAttacking", true);
            StopCoroutine(MoveToTarget());
            if (attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(AttackContinuously(other.GetComponent<Health>()));
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyHouse"))
        {
            animator.SetBool("isAttacking", false);
            StartCoroutine(MoveToTarget());
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;
            }
        }
    }

    private IEnumerator AttackContinuously(Health targetHealth)
    {
        while (!targetHealth.IsDead() && !health.IsDead())
        {
            targetHealth.TakeDamage(damageAmount);
            yield return new WaitForSeconds(attackInterval);
        }
    }

    private void PositionOnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + GetComponent<Collider2D>().bounds.extents.y, transform.position.z);
        }
    }
}
