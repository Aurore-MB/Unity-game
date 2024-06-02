using UnityEngine;
using UnityEngine.UI;

public class LanguageSelector : MonoBehaviour
{
    public Dropdown languageDropdown;

    private string[] languages = { "English", "French", "Spanish", "German", "Italian" };

    public void OnLanguageChanged(int index)
    {
        string selectedLanguage = languages[index];
        Debug.Log("Language changed to: " + selectedLanguage);
    }
}
