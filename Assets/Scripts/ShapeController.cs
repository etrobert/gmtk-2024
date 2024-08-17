using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeController : MonoBehaviour
{
    public MouseRestriction mouseRestriction;
    public PlayerScaling playerScaling;
    static readonly float pi6 = Mathf.Cos(Mathf.PI / 6);

    static readonly Vector2 yVector = new(0, 1);
    static readonly Vector2 xVector = new(-pi6 / 2, 0.25f);
    static readonly Vector2 zVector = new(pi6 / 2, 0.25f);
    static float PlanProjection(Vector2 mat, Vector2 vec)
    {
        return (mat.x * vec.x + mat.y * vec.y);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = PlanProjection(xVector, mouseRestriction.poiteurPosition) * -2;
        float y = PlanProjection(yVector, mouseRestriction.poiteurPosition);
        float z = PlanProjection(zVector, mouseRestriction.poiteurPosition) * -2;

        playerScaling.shape = new Vector3(Mathf.Exp(1.61f * x), Mathf.Exp(1.61f * y), Mathf.Exp(1.61f * z));

    }
}
