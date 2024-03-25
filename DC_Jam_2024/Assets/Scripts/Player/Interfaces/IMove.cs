using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    Rigidbody MyRigidbody { get; set; }
    float MoveSpeed { get; set; }
    LayerMask DetectsCollitionsWith { get; set; }
    void Move();
    void Rotate();
}
