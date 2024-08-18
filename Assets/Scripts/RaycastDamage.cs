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

    public float bulletWidth = 0.05f;


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
        if ((Input.GetKey(KeyCode.Space) || (Input.GetMouseButton(0))) && startTime == null)
            startTime = Time.time;
    }

    void Shoot()
    {
        var vectPlayerBoss = transform.forward;

        Vector3 planOrtho = new(vectPlayerBoss.z, 0, -vectPlayerBoss.x);
        Vector3 planOrthoY = transform.forward + new Vector3(0, -Mathf.PI / 2, 0);

        var basePos = transform.position + transform.forward * transform.localScale.z;
        for (float x = 0f; x < transform.localScale.x; x += bulletWidth)
        {
            for (float y = 0f; y < transform.localScale.y; y += bulletWidth)
            {
                var bullet = Instantiate(bulletPrefab,
                    basePos

                    - planOrtho * transform.localScale.x / 2
                    - planOrthoY * transform.localScale.y / 2

                    + x * planOrtho
                    + y * planOrthoY

                    , transform.rotation);
                bullet.transform.localScale =
                    new Vector3(bulletWidth, bulletWidth, transform.localScale.z);
            }
        }

        startTime = null;
    }
}
