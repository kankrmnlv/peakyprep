using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool isGameOver;

    private void OnEnable()
    {
        GameEvents.OnEnemyFinish += OnGameOver;
        GameEvents.OnRestartGame += OnRestartRequested;
    }
    private void OnDisable()
    {
        GameEvents.OnEnemyFinish -= OnGameOver;
        GameEvents.OnRestartGame -= OnRestartRequested;
    }

    void OnGameOver()
    {
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

}
