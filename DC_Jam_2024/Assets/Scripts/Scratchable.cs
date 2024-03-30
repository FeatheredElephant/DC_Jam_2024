using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scratchable : MonoBehaviour, IDraw
{
    [field: SerializeField] public GameObject LinePrefab { get; set; }
    public Line LineReference { get; set; }

    public void Cut(Vector3 position)
    {
        UpdateLine(position);
    }

    public void UpdateLine(Vector3 position)
    {
        if (LineReference == null) CreateLine();
        LineReference.UpdateLine(position);
    }

    public void CreateLine()
    {
        LineReference = Instantiate(LinePrefab, transform.position, transform.rotation).GetComponent<Line>();
    }
}
