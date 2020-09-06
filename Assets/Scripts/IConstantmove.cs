using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConstantmove
{
    float Speed
    {
        get; set;
    }
    void Move(float speed);
}
