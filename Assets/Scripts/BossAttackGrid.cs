using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class BossAttackGrid : MonoBehaviour
{

    public GameObject cylinderAttack;

    public GameObject floor;

    // Interval spawn time
    public float intervalSpawnTime = 0.25f;
    // Last Spawn Time
    private float lastSpawnTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
    }

    void FixedUpdate()
    {
        //If it's time to spawn new cylinder
        if (Time.time - lastSpawnTime >= intervalSpawnTime)
        {
            SpawnCylinder();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnCylinder()
    {
        Vector2 randomPoint = Random.insideUnitCircle * floor.transform.localScale.x / 2f;
        Vector3 newPosition = new(randomPoint[0], floor.transform.localScale.y + cylinderAttack.transform.localScale.y, randomPoint[1]);
        Instantiate(cylinderAttack, newPosition, cylinderAttack.transform.rotation);
    }
}
