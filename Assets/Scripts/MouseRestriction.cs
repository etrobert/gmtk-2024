using UnityEngine;

public class MouseRestriction : MonoBehaviour
{
    public RectTransform circleRectTransform;
    public RectTransform markerRectTransform;
    private float radius;

    public Vector2 poiteurPosition;

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
        poiteurPosition = mousePosition - circleCenter;

        // If the mouse is outside the circle, clamp it to the edge
        if (poiteurPosition.sqrMagnitude > radius * radius)
        {
            poiteurPosition = poiteurPosition.normalized * radius;
        }

        Vector2 clampedMousePosition = circleCenter + poiteurPosition;
        // Set the clampedMousePosition (Note: This will visually move the cursor, but Unity itself doesn't allow direct mouse repositioning)
        // Instead, you could use this position as input to your functions.

        // Move the marker to the clamped position
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(circleRectTransform, clampedMousePosition, null, out localPoint);
        markerRectTransform.localPosition = localPoint;

        poiteurPosition = poiteurPosition / radius;

    }
}

