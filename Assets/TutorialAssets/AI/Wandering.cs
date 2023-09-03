using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : Mover 
{
	Vector2 baseLocation, wanderTarget;
	public float wanderTimeMin = 2;
	public float wanderTimeMax = 4;
	public float wanderRadius = 5;

	protected override void OnEnable () 
	{
        base.OnEnable();

		baseLocation = transform.position;
		SelectNewWanderTarget ();
	}

	void SelectNewWanderTarget()
	{
		wanderTarget = baseLocation + Random.insideUnitCircle * wanderRadius;
		nextWanderUpdate = Time.time + Random.Range(wanderTimeMin, wanderTimeMax);
	}

	float nextWanderUpdate;
	void FixedUpdate () 
	{
		var sep = wanderTarget - (Vector2)transform.position;

		if (Time.time >= nextWanderUpdate || sep.magnitude < 0.2f) 
		{
			SelectNewWanderTarget ();
		}

		desiredVelocity = sep.normalized * speed;

		base.Move ();
	}
}
