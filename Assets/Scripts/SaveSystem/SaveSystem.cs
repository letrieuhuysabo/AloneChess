using Esper.ESave;
using UnityEngine;
using BayatGames.SaveGameFree;

public class SaveSystem : MonoBehaviour
{
    static SaveSystem singleton;

    public static SaveSystem Singleton { get => singleton; set => singleton = value; }

    void Awake()
    {
        singleton = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        // saveFile.AddOrUpdateData("currentLevel",0);
        // saveFile.Save();

        int currentLevel = SaveGame.Load<int>("currentLevel");
        Debug.Log(currentLevel);
        if (currentLevel == 0)
        {
            Configs.currentLevel = 1;
            UpdateCurrentLevelFromConfigs();
        }
        else
        {
            Configs.currentLevel = currentLevel;
        }
    }
    public void UpdateCurrentLevelFromConfigs()
    {
        // saveFile.AddOrUpdateData("currentLevel",Configs.currentLevel);
        // saveFile.Save();
        SaveGame.Save<int>("currentLevel",Configs.currentLevel);
    }
    public void Save(string key, string data)
    {
        // saveFile.AddOrUpdateData(key,data);
        // saveFile.Save();
        SaveGame.Save<string>(key, data);
        
    }
    public string Load(string key)
    {
        string data = SaveGame.Load<string>(key);
        return data;
    }
}
