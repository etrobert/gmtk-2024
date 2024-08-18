using UnityEngine;

public class RaycastDamage : MonoBehaviour
{
    public float range = 10f;

    // bullet to be instanciated
    public GameObject bulletPrefab;
    public GameObject bossShell;
    // Layer mask to identify enemies
    public LayerMask enemyLayer;

    // loading time for raycast
    public float fireLoadingTime = 0.25f;
    // Loading iniatial time
    private float? startTime = null;

    public bool Firing
    {
        get
        {
            return startTime is not null;
        }
    }

    void FixedUpdate()
    {
        if (Time.time - startTime >= fireLoadingTime)
            Shoot();
    }

    void Update()
    {
        // If the player presses the space key and the character is not loading, load the ray
        if (Input.GetKey(KeyCode.Space) && startTime == null)
            startTime = Time.time;
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, transform.position + transform.forward * transform.localScale.z, transform.rotation);
        bullet.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

        startTime = null;
    }
}
