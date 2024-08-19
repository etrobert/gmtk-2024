using UnityEngine;

public class Bullet : MonoBehaviour
{
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
}
