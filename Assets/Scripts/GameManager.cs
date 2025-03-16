using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    InputReader reader;

    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text scoreText;

    private int score;

    private bool isGameOver;

    private void Awake()
    {
        reader = FindFirstObjectByType<InputReader>();
    }

    private void OnEnable()
    {
        EnemyMove.OnFinish += OnGameOver;
        reader.OnRestartRequest += OnRestartRequested;
        EnemyHealth.OnEnemyDeath += IncreaseScore;
    }
    private void OnDisable()
    {
        EnemyMove.OnFinish -= OnGameOver;
        EnemyHealth.OnEnemyDeath -= IncreaseScore;
        reader.OnRestartRequest -= OnRestartRequested;
    }

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    void OnGameOver()
    {
        panel.SetActive(true);
        isGameOver = true;
    }

    void OnRestartRequested()
    {
        if (isGameOver)
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
