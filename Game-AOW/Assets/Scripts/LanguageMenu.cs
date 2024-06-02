using UnityEngine;
using UnityEngine.UI;

public class LanguageMenu : MonoBehaviour
{
    public GameObject languageDropdown;

    private bool dropdownActive = false;

    public void ToggleDropdown()
    {
        dropdownActive = !dropdownActive;
        languageDropdown.SetActive(dropdownActive);
    }
}
