using UnityEngine;

public class RaycastDamage : MonoBehaviour
{
    public float range = 10f;

    // bullet to be instanciated
    public GameObject bulletPrefab;
    public GameObject boss;
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
        var width = 0.05f;

        var vectPlayerBoss = transform.forward;
        Vector3 planOrtho = new(vectPlayerBoss.z, 0, -vectPlayerBoss.x);

        var basePos = transform.position + transform.forward * transform.localScale.z;
        for (float x = 0f; x < transform.localScale.x; x += width)
        {
            // OK
            var bullet = Instantiate(bulletPrefab, basePos - planOrtho * transform.localScale.x / 2
            + new Vector3(x * planOrtho.x, 0, x * planOrtho.z)
            , transform.rotation);
            bullet.transform.localScale =
                new Vector3(width, transform.localScale.y, transform.localScale.z);
        }

        startTime = null;
    }
}
