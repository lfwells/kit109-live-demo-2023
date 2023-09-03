using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour 
{
	public void OnTriggerEnter2D(Collider2D coll)
	{
		DelayedDestroy();
	}

	public void OnCollisionEnter2D(Collision2D coll)
	{
		DelayedDestroy();
	}

	bool destroyed = false;

	public void DelayedDestroy()
	{
		// wait a bit before destroying self, to ensure that other object recognise the collison
		if (!destroyed)
		{
			Destroy(gameObject, Time.fixedDeltaTime * 0.5f);
			destroyed = true;
		}
	}
}
