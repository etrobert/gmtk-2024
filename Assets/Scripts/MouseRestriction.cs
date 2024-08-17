using UnityEngine;

public class MouseRestriction : MonoBehaviour
{
    public RectTransform circleRectTransform;
    public RectTransform markerRectTransform;
    private float radius;

    void Start()
    {
        // Calculate the radius of the circle
        radius = circleRectTransform.rect.width * 0.5f;
    }

    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector2 mousePosition = Input.mousePosition;

        // Convert screen position to Canvas/RectTransform position
        Vector2 circleCenter = RectTransformUtility.WorldToScreenPoint(null, circleRectTransform.position);

        // Calculate the vector from the circle's center to the mouse position
        Vector2 offset = mousePosition - circleCenter;

        // If the mouse is outside the circle, clamp it to the edge
        if (offset.magnitude > radius)
        {
            offset = offset.normalized * radius;
        }

        Vector2 clampedMousePosition = circleCenter + offset;
        // Set the mouse position (Note: This will visually move the cursor, but Unity itself doesn't allow direct mouse repositioning)
        // Instead, you could use this position as input to your functions.


        // Move the marker to the clamped position
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(circleRectTransform, clampedMousePosition, null, out localPoint);
        markerRectTransform.localPosition = localPoint;

        Debug.Log("Clamped Mouse Position: " + clampedMousePosition);

        // Here, you would pass clampedMousePosition to your other functions
    }
}

