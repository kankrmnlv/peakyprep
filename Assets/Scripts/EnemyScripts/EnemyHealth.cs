using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Action<int> OnEnemyTakeDamage;

    private int currentHealth;
    private int maxHealthpoints = 3;

    [SerializeField] Slider healthBar;
    [SerializeField] GameObject enemyDeathParticles;

    private void OnEnable()
    {
        OnEnemyTakeDamage += TakeDamage;
    }
    private void OnDisable()
    {
        OnEnemyTakeDamage -= TakeDamage;
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
        GameEvents.EnemyDied(this);
        Destroy(gameObject);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.value = currentHealth;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
}
