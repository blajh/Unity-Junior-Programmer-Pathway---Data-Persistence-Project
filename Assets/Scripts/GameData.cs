using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.Drawing;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    [SerializeField] private TMP_InputField input;
    
    [System.Serializable]
    class SaveData {
        public int highScore;
        public string playerName;
    }

    private string currentPlayerName;
    private string highScorePlayerName;
    private int highScore;

    private void Awake() {

        Debug.Log(Application.persistentDataPath);

        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void LoadStartLevel() {
        currentPlayerName = SetPlayerNameFromInputField();
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
        return currentPlayerName;
    }

    public int GetHighScore() {
        return highScore;
    }

    public string GetHighScorePlayerName() {
        return highScorePlayerName;
    }

    public void SetNewHighScore(int score) {
        if (score > highScore) {
            highScore = score;
            Save();
            Load();
        }
    }

    public void Save() {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerName = currentPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScorePlayerName = data.playerName;
        }
    }
}
