using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    float MovementSpeed { get; }

    void Translate(Vector3 direction);

}
