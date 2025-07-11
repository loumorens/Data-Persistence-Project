using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{

    public TMP_InputField playerName;


    public void StartNewGame()
    {
        if (SaveManager.Instance.PlayerNameTemp != null && SaveManager.Instance.PlayerNameTemp.Length > 0)
        {
            if (SaveManager.Instance.PlayerName == null || SaveManager.Instance.PlayerName.Length == 0)
            {
                SaveManager.Instance.PlayerName = SaveManager.Instance.PlayerNameTemp;
            }
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }

    public void UpdatePlayerName()
    {
        Debug.Log("MenuUIHandler::UpdatePlayerName::Name : " + playerName.text);
        SaveManager.Instance.PlayerNameTemp = playerName.text;
    }
}
