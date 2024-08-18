using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAttack : MonoBehaviour
{
    public GameObject onColliderEffect;

    // Interval destroy time
    public float timeToDestroy = 3f;
    // Initial Spawn Time
    private float initialSpawnTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initialSpawnTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0.2f, 0);
        //If it's time to destroy the cylinder
        if (Time.time - initialSpawnTime >= timeToDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Attention ça brûle ");
            // Instantiate(onColliderEffect, transform.position, transform.rotation);
        }
    }
}
