using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour {

    [Tooltip("Use this to enable the cool visualization of the vectors")]
    public bool debug;
    
    [Tooltip("What speed should this character move at? (use this in child classes)")]
	public float speed = 1;

    [Tooltip("How much should we clamp the steering, to prevent over-powered characters that 'turn on a dime'?")]
    public float maxSteeringForce = 0.05f;

    [Tooltip("Set this to true when working with sprites than can be rotated to face the direction they are moving. If using the EightWayAnimator, set this to false")]
    public bool rotateSprite = true;
    
    //In the child classes, SET this value in desiredVelocity, then call base.Move();
	protected Vector2 desiredVelocity;

    //internal variables to make things work
	protected new Rigidbody2D rigidbody2D;
    Vector2 prevPosition;
    private Vector2 velocity;

    //link up the rigidbody, and set it up to begin as stationary
    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
        OnEnable();
    }
    protected virtual void OnEnable()
    {
        desiredVelocity = velocity = Vector2.zero;
        prevPosition = transform.position;
	}

    //This is the code in charge of moving the object around. Must be called from FixedUpdate() inside a child class
    protected void Move()
	{
        //calculate a steering value:
        var steering = (desiredVelocity * Time.fixedDeltaTime - velocity);

        //ensure the steering isn't too strong
        steering = Vector2.ClampMagnitude(steering, maxSteeringForce);

        //apply the steering force by setting the velocity
        velocity = velocity + steering;

        if (debug)
        {
            Debug.DrawLine(transform.position, (Vector2)transform.position + velocity * 60, Color.white);
            Debug.DrawLine(transform.position, (Vector2)transform.position + desiredVelocity * 60, Color.red);
            Debug.DrawLine((Vector2)transform.position + velocity * 60, (Vector2)transform.position + velocity * 60 + steering * 600, Color.green);
        }

        //Rigidbody moveposition function is used here, as it resolves collisions. As such, this function is written in FixedUpdate
        rigidbody2D.MovePosition(transform.position + (Vector3)velocity);

        //make the sprite face the direction it is travelling (unless we said not to, in the case of the player object)
		if (rotateSprite) transform.rotation = Quaternion.LookRotation (Vector3.forward, (Vector2)transform.position - prevPosition);

        //calculate the velocity (for others to read)
        velocity = (Vector2)transform.position - prevPosition;
		prevPosition = transform.position;
	} 

    //This is a little fudge for the "stop and cry" state in part 2 of the practical. When the behaviour is turned off, stop on the spot
    //if another behaviour is turned on, this function won't have any effect
    private void OnDisable()
    {
        if (rigidbody2D != null) rigidbody2D.velocity = velocity = desiredVelocity = Vector2.zero;
    }

    
}
