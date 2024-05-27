using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    public GameObject healthBarPrefab; // Prefab pour les barres de vie
    public Canvas mainCanvas; // Canvas principal pour les barres de vie
    private List<HealthBarFollow> healthBars = new List<HealthBarFollow>();

    void Start()
    {
        if (!mainCanvas.gameObject.activeSelf)
        {
            mainCanvas.gameObject.SetActive(true);
        }
    }

    public void AddHealthBar(Transform target)
    {
        GameObject healthBar = Instantiate(healthBarPrefab, mainCanvas.transform);
        HealthBarFollow healthBarFollow = healthBar.GetComponent<HealthBarFollow>();
        healthBarFollow.Initialize(target);
        healthBars.Add(healthBarFollow);
    }

    void Update()
    {
        foreach (var healthBar in healthBars)
        {
            healthBar.UpdatePosition();
        }
    }
}
