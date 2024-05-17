using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour {

    [SerializeField] private Image timerImage;
    [SerializeField] private float gameTime;
    private float sliderCurrentFillAmount = 1f;

    [Header("Score Components")]
    [SerializeField] private TextMeshProUGUI scoreText;

    private int playerScore;

    public enum GameState
    {
        Waiting,
        Playing,
        GameOver
    }
    public static GameState currentGameStatus;

    private void Awake()
    {
        currentGameStatus = GameState.Waiting;
    }

    private void Update()
    {
        if (currentGameStatus == GameState.Playing) 
        AdjustTimer();
    }

    void AdjustTimer()
    {
        timerImage.fillAmount = sliderCurrentFillAmount - (Time.deltaTime / gameTime);
        sliderCurrentFillAmount = timerImage.fillAmount;
    }

    public void UpdatePlayerScore(int asteroidHitPoints)
    {
        if (currentGameStatus != GameState.Playing)
            return;

        playerScore += asteroidHitPoints; 
        scoreText.text = playerScore.ToString();
    }
}
