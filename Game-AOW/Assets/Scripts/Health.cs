using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;
    public GameObject healthBarObject; // Référence à l'objet de la barre de vie
    public int xpReward = 50; // XP récompense pour la destruction de cet ennemi
    public int goldReward = 50; // Or récompense pour la destruction de cet ennemi
    private XPManager xpManager; // Référence au XPManager
    private GoldManager goldManager; // Référence au GoldManager
    private bool isDead = false;

    void Start()
    {
        Debug.Log(gameObject.name + " Health started");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        xpManager = FindObjectOfType<XPManager>(); // Trouver le XPManager dans la scène
        goldManager = FindObjectOfType<GoldManager>(); // Trouver le GoldManager dans la scène
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

        // Attribuer de l'XP et de l'or si l'entité qui meurt est un ennemi
        if (xpManager != null)
        {
            xpManager.GainXP(xpReward);
        }

        if (goldManager != null)
        {
            goldManager.GainGold(goldReward);
        }

        // Attribuer de l'XP supplémentaire si l'entité qui meurt est un joueur
        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("Player killed, awarding 100 XP");
            if (xpManager != null)
            {
                xpManager.GainXP(100); // Attribuer 100 XP supplémentaires pour la mort du joueur
            }
        }

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
