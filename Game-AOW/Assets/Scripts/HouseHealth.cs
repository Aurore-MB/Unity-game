using System.Collections;
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
        // Initialiser les points de vie actuels au maximum au démarrage
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // Méthode pour appliquer des dégâts à la maison
    public void TakeDamage(float damage)
    {
        Debug.Log(gameObject.name + " TakeDamage called with damage: " + damage);
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            // Ajouter ici ce qui se passe quand la maison est détruite
            Debug.Log(gameObject.name + " destroyed!");
        }
        UpdateHealthBar();
    }

    // Méthode pour mettre à jour l'affichage de la barre de vie
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

    // Gestion des collisions continues
    void OnTriggerStay2D(Collider2D other)
    {
        // Vérifier si l'objet entrant est une unité de l'équipe opposée
        if (other.gameObject.CompareTag(enemyTag))
        {
            Debug.Log(gameObject.name + " Collision detected with " + other.gameObject.name);
            // Appliquer des dégâts en continu tant que l'unité reste en collision
            TakeDamage(damagePerSecond * Time.deltaTime); // Ajustez les dégâts par seconde
        }
        else
        {
            Debug.Log(gameObject.name + " Ignored collision with: " + other.gameObject.name);
        }
    }
}
