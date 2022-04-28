using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
public class MenuUIHandler : MonoBehaviour
{
    public static string playerName;
    public static MenuUIHandler instance;
    public TextMeshProUGUI nameInput;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadBestScore();
        Debug.Log($"Name: {playerName}");
    }
    public void SetBestScore()
    {
        MainManager.bestScore = MainManager.instance.m_Points;
    }

    
    public void CheckEnteredName()
    {
        playerName = nameInput.text;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }



    [System.Serializable]
    class SaveData
    {
        public int bestScore;
    }
    public void SaveBestScore()
    {
        SaveData data = new SaveData();

        data.bestScore = MainManager.bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            MainManager.bestScore = data.bestScore;
        }
    }
}
