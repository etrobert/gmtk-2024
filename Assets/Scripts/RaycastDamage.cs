using UnityEngine;

public class RaycastDamage : MonoBehaviour
{
    public float range = 10f;

    // Layer mask to identify enemies
    public LayerMask enemyLayer;

    // loading time for raycast
    public float fireLoadingTime = 0.25f;
    // Loading iniatial time
    private float? startTime = null;

    void FixedUpdate()
    {
        // Debug.Log(startTime);
        //If the shape has load, shoot
        if (Time.time - startTime >= fireLoadingTime)
            Shoot();
    }

    void Update()
    {
        // If the player presses the space key, call the Shoot method
        if (Input.GetKey(KeyCode.Space) && startTime == null)
            startTime = Time.time;
    }

    void Shoot()
    {
        Ray ray = new(transform.position, transform.forward);

        // Perform the raycast and check if it hits an object on the enemy layer
        if (Physics.Raycast(ray, out RaycastHit hit, range, enemyLayer))
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 1.0f);
        else
            Debug.Log("No object hit by the ray.");

        startTime = null;
    }
}
