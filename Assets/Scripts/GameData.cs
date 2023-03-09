using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    [SerializeField] private TMP_InputField input;

    private string playerName;
    private int highScore;

    private void Awake() {

        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
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

    public int GetHighScore() {
        return highScore;
    }

    public void SetHighScore(int score) {
        if (score > highScore) {
            highScore = score;
        }
    }
}
