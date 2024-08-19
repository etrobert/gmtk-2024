using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossRotation : MonoBehaviour

{
    public int rotationDirection;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, rotationDirection * 0.1f, 0);
    }
}
