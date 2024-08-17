using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

// Controls player movement and rotation.
public class PlayerScaling : MonoBehaviour
{
  // Speed of scaling
  public float scalingSpeed = 0.07f;

  public float maxScale = 2f;
  public float minScale = 0.5f;

  private float scale = 1f;

  // Handle physics-based movement and rotation.
  private void FixedUpdate()
  {
    if (Input.GetKey(KeyCode.E) && scale < maxScale)
      scale += scalingSpeed;
    else if (Input.GetKey(KeyCode.Q) && scale > minScale)
      scale -= scalingSpeed;

    transform.localScale = Vector3.one * scale;
  }
}
