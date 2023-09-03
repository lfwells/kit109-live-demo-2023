using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : Mover
{
	//who are we chasing?
	public Transform target;

	void FixedUpdate () 
	{
		var separationVector = target.transform.position - transform.position;
		desiredVelocity = separationVector.normalized * speed;

		base.Move ();
	}
}
