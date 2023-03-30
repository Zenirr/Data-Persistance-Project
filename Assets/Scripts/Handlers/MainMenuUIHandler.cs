using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


//скорее всего функционалу интерфейса не нужно инициализироваться первее всего, так что пусть подождёт
[DefaultExecutionOrder(1000)]
public class MainMenuUIHandler : MonoBehaviour
{
    public TMP_InputField nickname;
    public TMP_Text highscore;

    private void Awake()
    {
        nickname.text = "Your Name";
        highscore.text = 0.ToString();
    }

    public void StartNew()
    {
        if (string.IsNullOrEmpty(Data.instance.nickname))
        {
            return;
        }
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SaveUser()
    {
        Data.instance.nickname = nickname.text.Trim();
        Data.instance.userHighscore = int.Parse(highscore.text);
        Data.instance.SavePlayerRecord();
    }


    public void LoadUser()
    {
        Data.instance.LoadPlayerRecord();
        nickname.text = Data.instance.nickname;
        highscore.text = Data.instance.userHighscore.ToString();
    }
}
