using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float health, maxHealth = 100f;

    [SerializeField] PlayerHealthBar healthBar;

    public float constantDamage = 5f;
    public float insideDamage = 0.5f;

    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    private void Die()
    {
        Debug.Log("YOU DIE!");
        //Destroy(gameObject);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CylinderBossAttack"))
        {
            TakeDamage(constantDamage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CylinderBossAttack"))
        {
            TakeDamage(insideDamage);
        }
    }
}
