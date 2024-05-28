using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject healthBarPrefab; // Prefab for the health bar
    private GameObject healthBar; // Instance of the health bar
    private SpriteRenderer healthBarSprite; // SpriteRenderer of the health bar
    public int xpReward = 50; // XP reward for destroying this enemy
    public int goldReward = 50; // Gold reward for destroying this enemy
    private XPManager xpManager; // Reference to the XPManager
    private GoldManager goldManager; // Reference to the GoldManager
    private bool isDead = false;

    void Start()
    {
        Debug.Log(gameObject.name + " Health started");
        currentHealth = maxHealth;
        xpManager = FindObjectOfType<XPManager>(); // Find the XPManager in the scene
        goldManager = FindObjectOfType<GoldManager>(); // Find the GoldManager in the scene

        // Instantiate the health bar
        healthBar = Instantiate(healthBarPrefab, transform);
        healthBar.transform.localPosition = new Vector3(0, 1.5f, 0); // Position it above the unit
        healthBar.transform.localScale = new Vector3(-1.32f, 0.24f, 1f); // Adjust scale to the required size
        healthBarSprite = healthBar.GetComponent<SpriteRenderer>();

        UpdateHealthBar();
    }

    public void SetHealth(int health)
    {
        maxHealth = health;
        currentHealth = health;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // Do not take damage if already dead

        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBarSprite != null)
        {
            float healthPercent = (float)currentHealth / maxHealth;
            healthBarSprite.transform.localScale = new Vector3(healthPercent * -1.32f, 0.24f, 1f); // Adjust the width based on health percentage
            healthBarSprite.color = Color.Lerp(Color.red, Color.green, healthPercent); // Color changes from red to green
        }
    }

    void Die()
    {
        if (isDead) return; // Do not die twice

        isDead = true;
        Debug.Log(gameObject.name + " is dead!");

        // Reward XP and gold if the entity dying is an enemy
        if (xpManager != null)
        {
            xpManager.GainXP(xpReward);
        }

        if (goldManager != null)
        {
            goldManager.GainGold(goldReward);
        }

        // Award extra XP if the entity dying is a player
        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("Player killed, awarding 100 XP");
            if (xpManager != null)
            {
                xpManager.GainXP(100); // Award 100 extra XP for the player's death
            }
        }

        // Disable the unit
        gameObject.SetActive(false);
        if (healthBar != null)
        {
            healthBar.SetActive(false);
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
