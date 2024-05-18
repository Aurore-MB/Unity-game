using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;
    public GameObject healthBarObject; // Référence à l'objet de la barre de vie
    private bool isDead = false;

    void Start()
    {
        Debug.Log(gameObject.name + " Health started");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // Ne pas prendre de dégâts si déjà mort

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return; // Ne pas mourir deux fois

        isDead = true;
        Debug.Log(gameObject.name + " is dead!");

        // Désactiver le joueur et sa barre de vie
        gameObject.SetActive(false);
        if (healthBarObject != null)
        {
            healthBarObject.SetActive(false);
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
