using UnityEngine;
using System.Collections;

public class ExplosionOnDestroy : MonoBehaviour 
{
	public GameObject explosionPrefab;
	private bool quitting = false; // Used to prevent incorrect triggering when editor play stops

	void OnApplicationQuit()
	{
		quitting = true;
	}

	void OnDestroy() 
	{
		// not really supposed to instatiate objects in OnDestroy, this stops things going really badly
		if (!quitting) 
		{
			Instantiate(explosionPrefab, transform.position, transform.rotation);
		}
	}
}
