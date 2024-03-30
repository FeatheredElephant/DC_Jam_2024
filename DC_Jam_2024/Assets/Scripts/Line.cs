using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(LineRenderer))]
public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    List<Vector3> Points;

    void SetPoint(Vector3 point)
    {
        Points.Add(point);
        lineRenderer.positionCount = Points.Count;
        lineRenderer.SetPosition(Points.Count - 1, point);
    }

    public void UpdateLine(Vector3 position)
    {
        if (Points == null)
        {
            Points = new List<Vector3>();
            SetPoint(position);
            return;
        }
        if (Vector3.Distance(Points.Last(), position) > .1f)
        {
            SetPoint(position);
        }
    }
}
