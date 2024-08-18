using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreHitt : MonoBehaviour
{
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

            Debug.Log("z: " + collision.transform.localScale.z);

            Destroy(collision.gameObject);
        }
    }

}
