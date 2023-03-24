using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data instance;

    public int userHighscore;
    public string nickname;
    public int bestScore;

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

    public void SavePlayerRecord()
    {
        //передаём в класс Savedata данные из инстенса
        SaveData saveData = new()
        {
            nickName = nickname,
            userHighscore = userHighscore,
            bestScore = bestScore
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

            userHighscore = saveData.userHighscore;
            nickname = saveData.nickName;
            bestScore = saveData.bestScore;
        }
    }
}

[SerializeField]
class SaveData
{
    public string nickName;
    public int userHighscore;
    public int bestScore;
}