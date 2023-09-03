using UnityEngine;
using System.Collections;

public class StartMovingInRandomDirection : MonoBehaviour 
{
	public float speedToMove = 100;

	public void Start() 
	{
		float angle = Mathf.Deg2Rad * Random.Range(0, 360);
		GetComponent<Rigidbody2D>().AddForce(new Vector2(speedToMove * Mathf.Sin(angle), speedToMove * Mathf.Cos(angle)));
	}
}
