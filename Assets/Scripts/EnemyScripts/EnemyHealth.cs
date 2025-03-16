using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static event Action OnEnemyDeath;
    public Action<int> OnEnemyTakeDamage;

    private int currentHealth;
    private int maxHealthpoints = 3;

    [SerializeField] Slider healthBar;
    [SerializeField] GameObject enemyDeathParticles;

    private void OnEnable()
    {
        OnEnemyTakeDamage += TakeDamage;
        OnEnemyDeath += Die;
    }
    private void OnDisable()
    {
        OnEnemyTakeDamage -= TakeDamage;
        OnEnemyDeath -= Die;
    }
    private void Start()
    {
        currentHealth = maxHealthpoints;
        healthBar.maxValue = maxHealthpoints;
        healthBar.value = maxHealthpoints;
    }

    private void Die()
    {
        Instantiate(enemyDeathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void TakeDamage(int damageAmount)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damageAmount;
            healthBar.value = currentHealth;
        }
        else
        {
            currentHealth = 0;
            OnEnemyDeath?.Invoke();
        }
    }
}
