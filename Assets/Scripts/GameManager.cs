using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text ammoText;

    private int score;

    private bool isGameOver;

    private void OnEnable()
    {
        GameEvents.OnEnemyFinish += OnGameOver;
        GameEvents.OnRestartGame += OnRestartRequested;
        GameEvents.OnEnemyDeath += IncreaseScore;
        InputReader.OnShootInput += UpdateAmmoText;
    }
    private void OnDisable()
    {
        GameEvents.OnEnemyFinish -= OnGameOver;
        GameEvents.OnEnemyDeath -= IncreaseScore;
        GameEvents.OnRestartGame -= OnRestartRequested;
        InputReader.OnShootInput -= UpdateAmmoText;
    }

    private void Start()
    {
        score = 0;
        UpdateAmmoText();
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

    void IncreaseScore(EnemyHealth enemy)
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    void UpdateAmmoText()
    {
        ammoText.text = PlayerShoot.currentAmmo.ToString();
    }
}
