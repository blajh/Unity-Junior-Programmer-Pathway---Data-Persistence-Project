using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TMP_InputField input;

    private string playerName;

    private void Awake() {

        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadStartLevel() {
        playerName = SetPlayerNameFromInputField();
        SceneManager.LoadScene(1);
    }

    public void Quit() {

        if (Application.isEditor) {
            EditorApplication.ExitPlaymode();
        } else {
            Application.Quit();
        }
    }

    private string SetPlayerNameFromInputField() {
        return input.text;
    }

    public string GetPlayerName() {
        return playerName;
    }
}
