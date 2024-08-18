using UnityEngine;

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour
{
    public float speed = 500.0f; // Set player's movement speed.
    public float rotationSpeed = 120.0f; // Set player's rotation speed.

    public float maxLookOffset = 10f;

    public Transform bossTransform; // Boss Position

    public RaycastDamage raycastDamage;

    private Vector3 GetLookTarget()
    {
        if (Input.GetMouseButton(1)) return bossTransform.position;

        var pos = MousePosition.GetMousePos();

        return bossTransform.position + new Vector3(pos.x, pos.y) * maxLookOffset;
    }

    private void HandleMovement()
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

    }

    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        if (!raycastDamage.Firing) HandleMovement();

        transform.LookAt(GetLookTarget());
    }
}
