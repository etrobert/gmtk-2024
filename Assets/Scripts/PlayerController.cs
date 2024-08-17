using UnityEngine;

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour
{
    public float speed = 500.0f; // Set player's movement speed.
    public float rotationSpeed = 120.0f; // Set player's rotation speed.

    public Transform bossTransform; // Boss Position

    private Rigidbody rb; // Reference to player's Rigidbody.

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.

        Quaternion turnRotation = Quaternion.Euler(0f, 180 * Mathf.Atan((bossTransform.position.x - rb.position.x) / (bossTransform.position.z - rb.position.z)) / Mathf.PI, 0f);
        rb.MoveRotation(turnRotation);
    }

    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        // Move player based on vertical input.
        float moveVertical = Input.GetAxis("Vertical");
        if (moveVertical != 0)
        {
            Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
        }

        // Rotate player based on horizontal input.
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal != 0)
            transform.RotateAround(bossTransform.position, Vector3.up, -moveHorizontal * rotationSpeed * Time.fixedDeltaTime);
    }
}
