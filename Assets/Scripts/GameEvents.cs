using System;
using UnityEngine;

public static class GameEvents
{
    //enemy
    public static event Action<EnemyHealth> OnEnemyDeath;
    public static event Action OnEnemyFinish;

    //game
    public static event Action OnRestartGame;
    public static void EnemyDied(EnemyHealth enemy)
    {
        OnEnemyDeath?.Invoke(enemy);
    }

    public static void EnemyFinished()
    {
        OnEnemyFinish?.Invoke();
    }

    public static void RestartGame()
    {
        OnRestartGame?.Invoke();
    }
}
