using UnityEngine;

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour
{
    public float speed = 500.0f; // Set player's movement speed.
    public float rotationSpeed = 120.0f; // Set player's rotation speed.

    public Transform bossTransform; // Boss Position

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        // Move player based on vertical input.
        float moveVertical = Input.GetAxis("Vertical");
        if (moveVertical != 0)
        {
            var forw = transform.forward;
            forw.y = 0;
            Vector3 movement = forw * moveVertical * speed * Time.fixedDeltaTime;
            transform.position += movement;
        }

        // Rotate player based on horizontal input.
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal != 0)
            transform.RotateAround(bossTransform.position, Vector3.up, -moveHorizontal * rotationSpeed * Time.fixedDeltaTime);
            
            transform.LookAt(bossTransform);
    }
}
