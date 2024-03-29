using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    Rigidbody MyRigidbody { get; set; }
    void Move();
    void Rotate();
}
