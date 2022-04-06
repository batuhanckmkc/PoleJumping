using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    LineController lineController;
    LineRenderer lineRenderer;
    //public Transform ShotPoint;
    public int numPoints = 50;
    //public float blastPower = 5f;
    public float timeBetweenPoints = 0.1f;

    public LayerMask collidableLayers;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineController = GameObject.Find("ShotPoint").GetComponent<LineController>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = (int)numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = lineController.ShotPoint.transform.position;
        Vector3 startingVelocity = lineController.ShotPoint.transform.forward * lineController.blastPower;
        for (float t = 0; t < numPoints; t+= timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
            points.Add(newPoint);

            if(Physics.OverlapSphere(newPoint, 2, collidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }

        lineRenderer.SetPositions(points.ToArray());


    }
}
