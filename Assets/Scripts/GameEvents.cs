using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action<EnemyHealth> OnEnemyDeath;
    public static event Action OnEnemyFinish;

    public static void EnemyDied(EnemyHealth enemy)
    {
        OnEnemyDeath?.Invoke(enemy);
    }

    public static void EnemyFinished()
    {
        OnEnemyFinish?.Invoke();
    }
}
