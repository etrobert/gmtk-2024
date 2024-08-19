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
        if (Input.GetMouseButton(1)) return;

        var pos = MousePosition.GetMousePos();

        // Convert screen position to Canvas/RectTransform position
        Vector2 circleCenter = RectTransformUtility.WorldToScreenPoint(null, circleRectTransform.position);

        targetPosition = pos * radius * 2;

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

