using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWithinCircle : MonoBehaviour
{
    public LayerMask layerMask;
    public float radius = 3;

    public Collider2D[] collidersNearMe;
    public int numberOfCollidersNearMe;

    void Start()
    {
        collidersNearMe = new Collider2D[5];
    }

    void Update()
    {
        numberOfCollidersNearMe = Physics2D.OverlapCircleNonAlloc(transform.position, radius, collidersNearMe, layerMask);
        RaycastUtils.DebugHitInfo(collidersNearMe, numberOfCollidersNearMe);
    }
}