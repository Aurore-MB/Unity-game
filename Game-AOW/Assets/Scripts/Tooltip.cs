using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI tooltipText;
    public GameObject tooltipObject;

    public void ShowTooltip(string text)
    {
        tooltipObject.SetActive(true);
        tooltipText.text = text;
    }

    public void HideTooltip()
    {
        tooltipObject.SetActive(false);
    }

    public void SetPosition(Vector2 position)
    {
        tooltipObject.transform.position = position;
    }
}
