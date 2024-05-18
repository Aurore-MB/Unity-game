using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        Debug.Log(gameObject.name + " Health started");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Ajoutez ici ce qui doit se passer lorsque le personnage meurt
        Debug.Log(gameObject.name + " is dead!");
        gameObject.SetActive(false);
    }
}
