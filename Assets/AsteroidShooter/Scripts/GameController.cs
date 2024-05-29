using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image timerImage;

    [Header("Timer in seconds")]
    [SerializeField] private float gameTime;

    [Header("Score Components")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Game Over Component")]
    [SerializeField] private GameObject gameOverScreen;

    [Header("High Score Component")]
    [SerializeField] private TextMeshProUGUI highScoreText;

    private int highScore;


    private int playerScore;

    private float sliderCurrentFillAmount = 1f;

    public enum GameState
    {
        Waiting,
        Playing,
        GameOver,
    }

    public static GameState currentGameStatus;

    private void Awake()
    {
        currentGameStatus = GameState.Waiting;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    private void Update()
    {
        if (currentGameStatus == GameState.Playing)
            AdjustTimer();
    }

    private void AdjustTimer()
    {
        timerImage.fillAmount = sliderCurrentFillAmount - (Time.deltaTime / gameTime);

        sliderCurrentFillAmount = timerImage.fillAmount;

        if (sliderCurrentFillAmount <= 0f)
        {
            GameOver();
        }
    }

    public void UpdatePlayerScore(int asteroidHitScore)
    {
        if (currentGameStatus != GameState.Playing)
            return;

        playerScore += asteroidHitScore;
        scoreText.text = playerScore.ToString();
    }

    public void StartGame()
    {
        currentGameStatus = GameState.Playing;
    }
    private void GameOver()
    {
        currentGameStatus = GameState.GameOver;

        gameOverScreen.SetActive(true);

        // Check the high score
        if (playerScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScoreText.text = playerScore.ToString();
        }
    }
    public void ResetGame()
    {
        currentGameStatus = GameState.Waiting;

        // put timer to 1
        sliderCurrentFillAmount = 1f;
        timerImage.fillAmount = 1f;
        // reset score
        playerScore = 0;
        scoreText.text = "0";
    }    

}
