using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineGenerator : MonoBehaviour
{
    Spline spline;
    public SplineContainer splineContainer;
    BezierCurve curve;
    BezierKnot knot;
    BezierTangent tangent;
    
    
    // Start is called before the first frame update
    void Start()
    {
        knot.Position = new Vector3(18.0599995f, 1.74000001f, -7.150000f);

        splineContainer.Spline.Add(knot);
    }

    // Update is called once per frame
    
}
