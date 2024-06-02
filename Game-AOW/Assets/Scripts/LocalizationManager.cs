using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;
    private Dictionary<string, string> localizedText;
    private string missingTextString = "Localized text not found";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void LoadLocalizedText(string language)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, "localization.json");

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            var jsonData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
            foreach (var item in jsonData.items)
            {
                if (item.language == language)
                {
                    foreach (var textItem in item.textItems)
                    {
                        localizedText.Add(textItem.key, textItem.value);
                    }
                    break;
                }
            }
            Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }
    }

    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;
    }
}

[System.Serializable]
public class LocalizationData
{
    public List<LanguageData> items;
}

[System.Serializable]
public class LanguageData
{
    public string language;
    public List<TextItem> textItems;
}

[System.Serializable]
public class TextItem
{
    public string key;
    public string value;
}
