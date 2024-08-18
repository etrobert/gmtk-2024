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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Core hit");
            Destroy(other.gameObject);
        }
    }

}
