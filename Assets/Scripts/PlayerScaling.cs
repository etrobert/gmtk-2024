using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

// Controls player movement and rotation.
public class PlayerScaling : MonoBehaviour
{
  // Speed of scaling
  public float scalingSpeed = 0.1f;

  public float maxScale = 2f * 2f * 2f;
  public float minScale = 0.5f * 0.5f * 0.5f;


  private float LocalScaleVolume()
  {
    return transform.localScale.x * transform.localScale.y * transform.localScale.z;
  }

  // Handle physics-based movement and rotation.
  private void FixedUpdate()
  {
    if (Input.GetKey(KeyCode.E) && LocalScaleVolume() < maxScale)
      transform.localScale += Vector3.one * scalingSpeed;
    else if (Input.GetKey(KeyCode.Q) && LocalScaleVolume() > minScale)
      transform.localScale -= Vector3.one * scalingSpeed;
  }
}
