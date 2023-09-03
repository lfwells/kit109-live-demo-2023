using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : Mover
{
    //who are we chasing? 
    public Transform target;

    void FixedUpdate()
    {
        var separationVector = transform.position - target.transform.position;
        desiredVelocity = separationVector.normalized * speed;

        base.Move();
    }
}