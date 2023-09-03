using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float timeBetweenSpawns = 1f;
    public Transform player;

    float timeUntilNextSpawn = 0f;

    new BoxCollider2D collider2D;

	void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timeUntilNextSpawn <= Time.timeSinceLevelLoad)
        {
            timeUntilNextSpawn = Time.timeSinceLevelLoad + timeBetweenSpawns;

            Vector3 startingPosition = collider2D.bounds.center + new Vector3(collider2D.bounds.extents.x * Random.Range(-1f, 1f), collider2D.bounds.extents.y * Random.Range(-1f, 1f), 0);

            GameObject enemyGO = GameObject.Instantiate(enemy);
            enemyGO.transform.position = startingPosition;

            Vector2 directionToPlayer = (player.transform.position - startingPosition).normalized;

            enemyGO.GetComponent<Rigidbody2D>().velocity = directionToPlayer;
        }		
	}
}
