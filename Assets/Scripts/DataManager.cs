using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using JetBrains.Annotations;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;

    private SaveData _saveData;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void SetPlayerName([NotNull] string name)
    {
        playerName = name;
    }

    public int GetHighscore()
    {
        return _saveData.highscoreScore;
    }

    public string GetHighscorePlayerName()
    {
        return _saveData.highscorePlayerName;
    }

    [System.Serializable]
    class SaveData
    {
        public string highscorePlayerName;
        public int highscoreScore;
    }

    public void SaveHighscore(int points)
    {
        _saveData.highscoreScore = points;
        _saveData.highscorePlayerName = playerName;

        string json = JsonUtility.ToJson(_saveData);
        File.WriteAllText(string.Format("{0}/savefile.json", Application.persistentDataPath), json);
    }

    private void Load()
    {
        _saveData = new SaveData();
        string saveFile = string.Format("{0}/savefile.json", Application.persistentDataPath);
        if (File.Exists(saveFile))
        {
            string json = File.ReadAllText(saveFile);
            _saveData = JsonUtility.FromJson<SaveData>(json);
        }
    }
}
