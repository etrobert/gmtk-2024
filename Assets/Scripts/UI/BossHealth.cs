using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] public float health, maxHealth = 1000;

    [SerializeField] BossHealthBar healthBar;

    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    private void Die()
    {
        Debug.Log("YOU WIN!");
        MainMenu.QuitGame();
        Destroy(gameObject);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            GetComponent<BossLevel>().IncreaseLevel();
            Start();
        }
    }
}
