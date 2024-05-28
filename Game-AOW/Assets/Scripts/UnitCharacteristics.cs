using UnityEngine;

[System.Serializable]
public class UnitCharacteristics
{
    public string unitName;
    public int health;
    public int damage;
    public float speed;
    public int unitCost; // Coût de l'unité en or
    public GameObject unitPrefab; // Préfabriqué de l'unité
}
