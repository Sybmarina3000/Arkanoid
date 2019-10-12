using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPassiveMover
{
    float Speed { get; set; }
    Vector3 Direction { get; set; }

    void Move();
}
