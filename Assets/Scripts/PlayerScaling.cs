using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

// Controls player movement and rotation.
public class PlayerScaling : MonoBehaviour
{
  static readonly Vector3 square = new(1f, 1f, 1f);
  static readonly Vector3 plan = new(0.1f, 3f, 3f);
  static readonly Vector3 frite = new(0.5f, 0.5f, 5f);

  // Speed of scaling
  public float scalingSpeed = 0.07f;

  public float maxScale = 2f;
  public float minScale = 0.5f;

  private float scale = 1f;

  public Vector3 shape = frite;

  // Handle physics-based movement and rotation.
  private void FixedUpdate()
  {
    if (Input.GetKey(KeyCode.E) && scale < maxScale)
      scale += scalingSpeed;
    else if (Input.GetKey(KeyCode.Q) && scale > minScale)
      scale -= scalingSpeed;

    transform.localScale = shape * scale;
  }
}
