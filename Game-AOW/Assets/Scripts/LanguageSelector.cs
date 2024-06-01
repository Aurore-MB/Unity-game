using UnityEngine;
using UnityEngine.UI;

public class LanguageSelector : MonoBehaviour
{
    public Dropdown languageDropdown;

    void Start()
    {
        languageDropdown.onValueChanged.AddListener(delegate {
            LanguageDropdownValueChanged(languageDropdown);
        });
    }

    void LanguageDropdownValueChanged(Dropdown change)
    {
        string selectedLanguage = change.options[change.value].text.ToLower();
        LocalizationManager.instance.LoadLocalizedText(selectedLanguage);
    }
}
