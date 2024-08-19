using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class BossAttackGrid : MonoBehaviour
{

    public GameObject cylinderAttack;
    public GameObject parentCylinderAttack;
    public GameObject floor;
    public Transform playerShapeT;

    // Interval spawn time
    public float intervalSpawnTime = 0.1f;
    // Last Spawn Time
    private float lastSpawnTime = 0f;

    public float lastSpawnTimeBelow = 0f;
    public float intervalSpawnTimeBelow = 2.5f;

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
            Vector2 pos = Random.insideUnitCircle * ((floor.transform.localScale.x / 2f) - (cylinderAttack.transform.localScale.x / 2f));
            SpawnCylinder(pos);
            // pos = Random.insideUnitCircle * ((floor.transform.localScale.x / 2f) - (cylinderAttack.transform.localScale.x / 2f));
            // SpawnCylinder(pos);

            lastSpawnTime = Time.time;
        }
        //If it's time to spawn new cylinder
        if (Time.time - lastSpawnTimeBelow >= intervalSpawnTimeBelow)
        {
            SpawnCylinder(new Vector2(playerShapeT.position.x, playerShapeT.position.z));
            lastSpawnTimeBelow = Time.time;
        }

    }

    void SpawnCylinder(Vector2 pos)
    {
        // Vector2 randomPoint = Random.insideUnitCircle * ((floor.transform.localScale.x / 5f) - (cylinderAttack.transform.localScale.x / 2f));
        Vector3 newPosition = new(pos[0], floor.transform.localScale.y, pos[1]);
        Instantiate(cylinderAttack, newPosition, cylinderAttack.transform.rotation, parentCylinderAttack.transform);

        // randomPoint = Random.insideUnitCircle * ((floor.transform.localScale.x / 2f) - (cylinderAttack.transform.localScale.x / 2f));
        // newPosition = new(randomPoint[0], floor.transform.localScale.y, randomPoint[1]);
        // Instantiate(cylinderAttack, newPosition, cylinderAttack.transform.rotation, parentCylinderAttack.transform);
    }
}
