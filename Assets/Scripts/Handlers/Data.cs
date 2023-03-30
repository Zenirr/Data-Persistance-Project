using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data instance;

    public int userHighscore; //best user score
    public string highscoreNick; // best user nickname
    public string nickname; //nick name of current user
    public int bestScore; //best score of current user

    private void Awake()
    {
        //На пробуждении мы проверяем есть ли в instance объект, если есть, то текущий геймобджект не нужен
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadHighscore()
    {
        string savePath = Application.persistentDataPath + "/saveDate.json";

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            userHighscore = saveData.userHighscore;
            highscoreNick = saveData.highscoreNick;
        }
    }

    public void SavePlayerRecord()
    {
        //передаём в класс Savedata данные из инстенса
        SaveData saveData = new()
        {
            nickName = nickname,
            highscoreNick = highscoreNick,
            userHighscore = userHighscore,

        };

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/saveDate.json", json);
    }

    public void LoadPlayerRecord()
    {
        string savePath = Application.persistentDataPath + "/saveDate.json";

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            nickname = saveData.highscoreNick;
        }
    }
}

[SerializeField]
class SaveData
{
    public int bestScore;
    public string nickName;
    public int userHighscore;
    public string highscoreNick;
}