using UnityEngine;

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour
{
    public float speed = 500.0f; // Set player's movement speed.
    public float rotationSpeed = 120.0f; // Set player's rotation speed.

    public float maxLookOffset = 10f;
    public float baseHeight = 2f;

    public Transform bossTransform; // Boss Position

    public RaycastDamage raycastDamage;

    public Transform playerShapeT;

    private Vector3 GetLookTarget()
    {
        if (!Input.GetMouseButton(1)) return bossTransform.position;

        var pos = MousePosition.GetMousePos();

        var vectPlayerBoss = bossTransform.position - transform.position;
        vectPlayerBoss.y = 0;

        vectPlayerBoss.Normalize();
        Vector2 planOrtho = new(vectPlayerBoss.z, -vectPlayerBoss.x);

        var paneLooking = new Vector3(planOrtho.x * pos.x, pos.y, planOrtho.y * pos.x) * maxLookOffset;

        return bossTransform.position + paneLooking;
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
        {
            var vectPlayerBoss = bossTransform.position - transform.position;
            vectPlayerBoss.y = 0;
            var distance = vectPlayerBoss.magnitude;
            transform.RotateAround(bossTransform.position, Vector3.up, -moveHorizontal * rotationSpeed * Time.fixedDeltaTime / distance);
        }

    }

    private void HandleYPostoScaling()
    {
        transform.position = new Vector3(transform.position.x, baseHeight + playerShapeT.localScale.y / 2, transform.position.z);
    }

    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        HandleMovement();
        HandleYPostoScaling();

        transform.LookAt(GetLookTarget());
    }
}
