using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    void Start()
    {
        Debug.Log(gameObject.name + " HealthBar started");
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = Color.green;
        Debug.Log(gameObject.name + " max health set to " + health);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = Color.Lerp(Color.red, Color.green, (float)health / slider.maxValue);
        Debug.Log(gameObject.name + " health set to " + health);
    }
}
