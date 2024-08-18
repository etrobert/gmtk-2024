using UnityEngine;

public class RaycastDamage : MonoBehaviour
{
    public float range = 10f;

    // Layer mask to identify enemies
    public LayerMask enemyLayer;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) Shoot();
    }

    void Shoot()
    {
        Ray ray = new(transform.position, transform.forward);

        // Perform the raycast and check if it hits an object on the enemy layer
        if (Physics.Raycast(ray, out RaycastHit hit, range, enemyLayer))
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 1.0f);
        else
            Debug.Log("No object hit by the ray.");
    }
}
