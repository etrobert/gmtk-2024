using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAttack : MonoBehaviour
{

    // Initial Spawn Time
    private float initialSpawnTime = 0f;
    private float timeBeforeUpdateSize = 1f;
    private float timeReduceSize = 3f;

    private float height;
    private float minHeight = 0.01f;

    private float maxHeight = 4f;

    public bool earlyDestroy = false;

    // Start is called before the first frame update
    void Start()
    {
        height = minHeight;
        initialSpawnTime = Time.time;
        transform.localScale = new Vector3(transform.localScale[0], height, transform.localScale[2]);
    }

    private void SetEarlyDestroy()
    {
        earlyDestroy = true;
    }
    private void CyinderGoDownAndDestroy()
    {
        if (height >= minHeight)
        {
            height -= 0.1f;
            transform.localScale = new Vector3(transform.localScale[0], height, transform.localScale[2]);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0.2f, 0);

        var elapsedTime = Time.time - initialSpawnTime;

        if (earlyDestroy)
        {
            CyinderGoDownAndDestroy();
        }
        else if (elapsedTime <= timeBeforeUpdateSize)
        {
            // nothing to do, just wait
        }
        else if (elapsedTime <= timeReduceSize)
        {
            if (height <= maxHeight)
            {
                height += 0.3f;
                transform.localScale = new Vector3(transform.localScale[0], height, transform.localScale[2]);
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            }
        }
        else
        {
            CyinderGoDownAndDestroy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CylinderBossAttack"))
        {
            other.GetComponent<ZoneAttack>().SetEarlyDestroy();
        }
        else if (other.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
