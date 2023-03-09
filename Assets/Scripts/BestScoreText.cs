using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreText : MonoBehaviour
{
    private Text uiText;
    private string playerName;

    private void Awake() {
        uiText = GetComponent<Text>();        
    }

    private void Start() {
        RenderPlayerName();
    }

    private void RenderPlayerName() {
        playerName = ScoreManager.Instance.GetPlayerName();
        if (playerName != null) {
            uiText.text = "Best Score : " + playerName + " : 0";
        }
    }
}
