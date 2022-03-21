using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string bestPlayerName;

    public string newPlayerName;

    public int highScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveFile
    {
        public string bestPlayerName;

        public int highScore;
    }

    public void SaveData()
    {
        SaveFile data = new SaveFile();
        data.bestPlayerName = bestPlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveFile data = JsonUtility.FromJson<SaveFile>(json);

            bestPlayerName = data.bestPlayerName;

            highScore = data.highScore;
        }
    }
}
