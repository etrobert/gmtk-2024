using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BossHealth bossHealth;
    private float damageMultiplier = 0.01f;
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
        if (other.CompareTag("Heart"))
        {
            bossHealth = GameObject.Find("Boss").GetComponent<BossHealth>();
            bossHealth.TakeDamage(transform.localScale.z * criticalMultiplier);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Shell"))
        {
            bossHealth = GameObject.Find("Boss").GetComponent<BossHealth>();
            bossHealth.TakeDamage(transform.localScale.z * damageMultiplier);
            Destroy(gameObject);
        }

        else if (other.CompareTag("CylinderBossAttack"))
        {
            Destroy(gameObject);
        }
    }
}
