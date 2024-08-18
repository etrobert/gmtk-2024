using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAttack : MonoBehaviour
{
    public GameObject onColliderEffect;

    // Interval destroy time
    public float timeToDestroy = 20f;
    // Initial Spawn Time
    private float initialSpawnTime = 0f;
    private float updateSizeTime = 0.2f;
    public float timeBeforeUpdateSize = 2f;

    private float height = 0.01f;

    private float maxHeight = 4f;


    // Start is called before the first frame update
    void Start()
    {
        initialSpawnTime = Time.time;
        transform.localScale = new Vector3(transform.localScale[0], height, transform.localScale[2]);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0.2f, 0);

        if ((Time.time - initialSpawnTime >= timeBeforeUpdateSize) && (height <= maxHeight))
        {
            height += 0.1f;
            transform.localScale = new Vector3(transform.localScale[0], height, transform.localScale[2]);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        }

        //If it's time to destroy the cylinder
        if (Time.time - initialSpawnTime >= timeToDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CylinderBossAttack"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("Attention ça brûle");
            // Instantiate(onColliderEffect, transform.position, transform.rotation);
        }
    }
}
