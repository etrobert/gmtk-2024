using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float health, maxHealth = 100f;

    [SerializeField] PlayerHealthBar healthBar;
    public GameObject floor;
    public float constantDamage = 5f;
    public float insideDamage = 0.5f;
    public float outsideDamage = 0.5f;
    private bool isInsideDamage = false;

    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    private void Die()
    {
        Debug.Log("YOU DIE!");
        MainMenu.QuitGame();
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
            isInsideDamage = true;
            TakeDamage(constantDamage);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CylinderBossAttack"))
        {
            isInsideDamage = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CylinderBossAttack") && isInsideDamage)
        {
            TakeDamage(insideDamage);
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("PositionX : " + transform.position.x);
        Debug.Log("PositionZ : " + transform.position.z);

        if ((Mathf.Abs(transform.position.x) > (floor.transform.localScale.x / 2f)) ||
            (Mathf.Abs(transform.position.z) > (floor.transform.localScale.z / 2f)))
        {
            TakeDamage(outsideDamage);
        }
    }
}
