using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWithReflection : MonoBehaviour
{
    public LayerMask layerMask;

    void Update()
    {
        Vector2 mousePositionInScreenSpace = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePositionInScreenSpace);
        Vector3 mousePositionInWorldSpace = ray.origin;
        mousePositionInWorldSpace.z = 0;

        Ray2D rayToMouse = new Ray2D(transform.position, mousePositionInWorldSpace - transform.position);
        RaycastHit2D firstHitObject = Physics2D.Raycast(rayToMouse.origin, rayToMouse.direction, Mathf.Infinity, layerMask);
        if (firstHitObject.collider != null)
        {
            Debug.DrawLine(transform.position, firstHitObject.point, Color.white);
            RaycastUtils.RayCastOffNormal(transform.position, firstHitObject, layerMask, 2);
        }
    }
}
