using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;
    public GameData gameData;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ne pas détruire ce GameObject lors du chargement d'une nouvelle scène
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGameData()
    {
        PlayerPrefs.SetInt("Gold", gameData.gold);
        PlayerPrefs.SetInt("XP", gameData.xp);
        PlayerPrefs.SetInt("PlayerBaseHealth", gameData.playerBaseHealth);
        PlayerPrefs.SetInt("EnemyBaseHealth", gameData.enemyBaseHealth);
        // Sauvegardez d'autres variables si nécessaire
    }

    public void LoadGameData()
    {
        gameData.gold = PlayerPrefs.GetInt("Gold", 0);
        gameData.xp = PlayerPrefs.GetInt("XP", 0);
        gameData.playerBaseHealth = PlayerPrefs.GetInt("PlayerBaseHealth", 100); // valeur par défaut à 100
        gameData.enemyBaseHealth = PlayerPrefs.GetInt("EnemyBaseHealth", 100); // valeur par défaut à 100
        // Chargez d'autres variables si nécessaire
    }
}
