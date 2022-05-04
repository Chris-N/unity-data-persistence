using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [HideInInspector] public RecordHighScore Rhs;
    public TextMeshProUGUI HighScoreText;
    public TMP_InputField NameInput;
    public string PlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        SetupFromFile();
        DontDestroyOnLoad(gameObject);
    }

    private void SetupFromFile()
    {
        RecordHighScore.CheckSaveFile(Rhs);
        if (Rhs.Name == null)
            return;

        NameInput.text = Rhs.Name;
        HighScoreText.text += $" : {Rhs.Name} : {Rhs.HighScore}";
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnEditEnd(string name)
    {
        PlayerName = name;
    }
}
