using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreHitt : MonoBehaviour
{
    [SerializeField] BossHealth bossHealth;
    public float damageMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

            Debug.Log("Core hit");

            Debug.Log("z: " + collision.transform.localScale.z * damageMultiplier);
            bossHealth.TakeDamage(collision.transform.localScale.z * damageMultiplier);

            Destroy(collision.gameObject);
        }
    }

}
