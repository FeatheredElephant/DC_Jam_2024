using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraw : ICuttable
{
    GameObject LinePrefab { get; set; }
    Line LineReference { get; set; }

    void CreateLine();
    void UpdateLine(Vector3 position);
}
