using System;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public String PlayerName;

    public String PlayerNameTemp;

    public int score;




    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
        LoadDatas();

    }
    [System.Serializable]
    class SaveData
    {
        public String PlayerName;
        public int score;
    }

    public void SaveDatas()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        //Debug.Log("path : " + Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/DataPersistenceProject_savefile.json", json);
    }

    public void LoadDatas()
    {
        string path = Application.persistentDataPath + "/DataPersistenceProject_savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("Save file exist - get data");
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            score = data.score;
        }
        else
        {
            Debug.Log("Save file doesn't exist - initialize data");
            score = 0;
        }
    }

}
