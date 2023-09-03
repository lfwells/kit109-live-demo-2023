using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawner : MonoBehaviour
{
    //public GameObject enemyPrefab;
    public GameObject[] enemyPrefabsToChooseFrom;
    public Rigidbody2D target;
    public int totalEnemiesToSpawn = 5;
    public float spawnEvery = 1;
    public float spawnRadius = 5f;
    public int seed = 1234;


    void Start()
    {
        Random.InitState(seed);
        StartCoroutine(SpawnEnemies());
    }

    void SpawnEnemy()
    {
        var spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        GameObject enemyPrefab = enemyPrefabsToChooseFrom[Random.Range(0, enemyPrefabsToChooseFrom.Length)];
        var enemyGO = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        //link up the targets! 
        var moverScripts = enemyGO.GetComponentsInChildren<Mover>();
        foreach (var moverScript in moverScripts)
        {
            if (moverScript is Seek)
            {
                (moverScript as Seek).target = target.transform;
            }
            else if (moverScript is Flee)
            {
                (moverScript as Flee).target = target.transform;
            }
            else if (moverScript is Pursuit)
            {
                (moverScript as Pursuit).target = target;
            }
        }

        var colour = new Color(Random.value, Random.value, Random.value);
        var spriteRenderer = enemyGO.GetComponent<SpriteRenderer>();
        spriteRenderer.color = colour;
    }

    IEnumerator SpawnEnemies()
    {
        int enemiesSpawnedSoFar = 0;
        while (true)
        {
            yield return new WaitForSeconds(spawnEvery);
            SpawnEnemy();

            enemiesSpawnedSoFar++;
            if (enemiesSpawnedSoFar >= totalEnemiesToSpawn)
            {
                yield break;
            }
        }
    }
    void OnDrawGizmos()
    {
#if UNITY_EDITOR
        UnityEditor.Handles.color = new Color(1, 0, 0, 0.5f);
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.back, spawnRadius);
#endif
    }
}