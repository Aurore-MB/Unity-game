using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    public Canvas upgradeCanvas; 
    public Button upgradeButton; 

    void Start()
    {
    
        upgradeCanvas.gameObject.SetActive(false);

       
        upgradeButton.onClick.AddListener(ToggleUpgradeCanvas);
    }

    void ToggleUpgradeCanvas()
    {
       
        upgradeCanvas.gameObject.SetActive(!upgradeCanvas.gameObject.activeSelf);
    }
}
