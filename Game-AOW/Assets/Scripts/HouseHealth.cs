using UnityEngine;
using UnityEngine.UI;

public class HouseHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Points de vie maximum
    private float currentHealth;   // Points de vie actuels
    public Slider healthSlider;    // Référence au slider de la barre de vie
    public float damagePerSecond = 10f; // Dégâts par seconde
    public string enemyTag;        // Tag de l'unité qui peut attaquer cette maison

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(gameObject.name + " TakeDamage called with damage: " + damage);
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            Debug.Log(gameObject.name + " destroyed!");
        }
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth;
            Debug.Log(gameObject.name + " Health updated: " + currentHealth + "/" + maxHealth);
        }
        else
        {
            Debug.LogError(gameObject.name + " Health Slider is not assigned!");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            Debug.Log(gameObject.name + " Collision detected with " + other.gameObject.name);
            TakeDamage(damagePerSecond * Time.deltaTime);
        }
        else
        {
            Debug.Log(gameObject.name + " Ignored collision with: " + other.gameObject.name);
        }
    }
}
