using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;

    }
}
