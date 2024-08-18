using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class BossAttackGrid : MonoBehaviour
{

    public GameObject cylinderAttack;

    public GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        createAttack();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int nbCircle = 20;
    void createAttack()
    {
        for (int i = 0; i < nbCircle; ++i)
        {
            //Vector3(Random.Range(floor.transform.position.x, 2f);
            Instantiate(cylinderAttack);
        }
    }
}
