using UnityEngine;

public class MousePosition : MonoBehaviour
{
  static public Vector2 GetMousePos()
  {
    // Get the mouse position relative to the screen's center
    return new Vector2(
        Mathf.Clamp(Input.mousePosition.x / Screen.width, 0f, 1f) - 0.5f,
        Mathf.Clamp(Input.mousePosition.y / Screen.height, 0f, 1f) - 0.5f
    );
  }
}
