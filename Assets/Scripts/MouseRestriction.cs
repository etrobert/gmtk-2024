using UnityEngine;

public class MouseRestriction : MonoBehaviour
{
    public RectTransform circleRectTransform;
    public RectTransform markerRectTransform;
    private float radius;

    public Vector2 poiteurPosition;

    private Vector2 targetPosition;

    // Speed of scaling
    public float morphSpeed = 0.07f;

    void Start()
    {
        // Calculate the radius of the circle
        radius = circleRectTransform.rect.width * 0.5f;
    }

    void Update()
    {
        if (!Input.GetMouseButton(1)) return;

        // Get the mouse position in screen coordinates
        Vector2 mousePosition = Input.mousePosition;

        // Convert screen position to Canvas/RectTransform position
        Vector2 circleCenter = RectTransformUtility.WorldToScreenPoint(null, circleRectTransform.position);

        // Calculate the vector from the circle's center to the mouse position
        targetPosition = mousePosition - circleCenter;

        // If the mouse is outside the circle, clamp it to the edge
        if (targetPosition.sqrMagnitude > radius * radius)
            targetPosition = targetPosition.normalized * radius;

        Vector2 clampedMousePosition = circleCenter + targetPosition;
        // Set the clampedMousePosition (Note: This will visually move the cursor, but Unity itself doesn't allow direct mouse repositioning)
        // Instead, you could use this position as input to your functions.

        // Move the marker to the clamped position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(circleRectTransform, clampedMousePosition, null, out Vector2 localPoint);
        markerRectTransform.localPosition = localPoint;

        targetPosition /= radius;
    }

    void FixedUpdate()
    {
        poiteurPosition = Vector2.Lerp(poiteurPosition, targetPosition, Time.fixedDeltaTime * morphSpeed);
    }
}

