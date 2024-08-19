using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BossHealth bossHealth;
    public PlayerHealth playerHealth;
    private float damageMultiplier = 1f;
    private float criticalMultiplier = 1f;


    public float bulletSpeed = 20f;
    private float initialSpawnTime = 0f;
    private readonly float timeToDestroy = 5f;

    void Start()
    {
        initialSpawnTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;

        //If it's time to destroy the bullet
        if (Time.time - initialSpawnTime >= timeToDestroy)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        bossHealth = GameObject.Find("Boss").GetComponent<BossHealth>();
        playerHealth = GameObject.Find("Shape").GetComponent<PlayerHealth>();

        if (other.CompareTag("Heart"))
        {
            bossHealth.TakeDamage(transform.localScale.z * criticalMultiplier);
            Destroy(gameObject);
        }

        else if (other.CompareTag("Shell"))
        {
            Destroy(gameObject);
        }

        else if (other.CompareTag("PlayerShell"))
        {

            playerHealth.TakeDamage(transform.localScale.z * damageMultiplier);
            Destroy(gameObject);
        }

        else if (other.CompareTag("CylinderBossAttack"))
        {
            Destroy(gameObject);
        }


        else if (other.CompareTag("PlayButton"))
        {
            MainMenu.PlayGame();
        }
    }
}
