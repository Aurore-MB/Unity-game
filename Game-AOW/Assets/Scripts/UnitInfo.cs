using UnityEngine;
using UnityEngine.EventSystems;

public class UnitInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string unitName;
    public int cost;
    public int health;
    public int damage;
    public float walkSpeed;
    public float range;
    public float buildTime;
    public string description;

    private Tooltip tooltip;

    void Start()
    {
        tooltip = FindObjectOfType<Tooltip>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        string tooltipText = $"{unitName}\n" +
                             $"Cost: {cost} Gold\n" +
                             $"Health: {health}\n" +
                             $"Damage: {damage}\n" +
                             $"Walk Speed: {walkSpeed}\n" +
                             $"Range: {range}\n" +
                             $"Build Time: {buildTime} s\n" +
                             $"{description}";
        tooltip.ShowTooltip(tooltipText);
        tooltip.SetPosition(Input.mousePosition);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }
}
