using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellHitt : MonoBehaviour
{
    public float damageMultiplier = 0.05f;
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

            Debug.Log("Shell hit");

            Debug.Log("z: " + collision.transform.localScale.z);

            Destroy(collision.gameObject);
        }
    }

}
