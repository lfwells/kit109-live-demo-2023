using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : Mover
{
    public Rigidbody2D target;
    public float predictionTime = 1.0f;

    void FixedUpdate()
    {
        var targetFuturePosition = (Vector2)target.transform.position + target.velocity * predictionTime;

        //this is now effectively the same as the seeker code, just we are seeking targetFuturePosition 
        var separationVector = targetFuturePosition - (Vector2)transform.position;
        desiredVelocity = separationVector.normalized * speed;

        base.Move();
    }
}