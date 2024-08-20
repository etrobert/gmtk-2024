using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Helices : MonoBehaviour
{
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, -10f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        int BossLevel = boss.GetComponent<BossLevel>().GetLevel();
        if (BossLevel >= 5)
        {
            transform.position = new Vector3(transform.position.x, 32f, transform.position.z);
        }

    }
}
