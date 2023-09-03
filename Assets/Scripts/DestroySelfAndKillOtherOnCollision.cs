using UnityEngine;
using System.Collections;

public class DestroySelfAndKillOtherOnCollision : MonoBehaviour 
{
	public void OnTriggerEnter2D(Collider2D coll)
	{
		DestroySelfAndKillOther(coll.gameObject);
	}

	public void OnCollisionEnter2D(Collision2D coll)
	{
		DestroySelfAndKillOther(coll.gameObject);
	}

	public void DestroySelfAndKillOther(GameObject other)
	{
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
