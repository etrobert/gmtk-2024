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

    private int nbCircle = 200;

    void createAttack()
    {
        for (int i = 0; i < nbCircle; ++i)
        {
            Vector2 randomPoint = Random.insideUnitCircle * floor.transform.localScale.x / 2f;
            Vector3 newPosition = new(randomPoint[0], floor.transform.localScale.y + cylinderAttack.transform.localScale.y, randomPoint[1]);

            Instantiate(cylinderAttack, newPosition, cylinderAttack.transform.rotation);
        }
    }
}
