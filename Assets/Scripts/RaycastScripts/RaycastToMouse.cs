using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastToMouse : MonoBehaviour
{
    public LayerMask layerMask;

    void Update()
    {
        Vector2 mousePositionInScreenSpace = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePositionInScreenSpace);
        Vector3 mousePositionInWorldSpace = ray.origin;
        mousePositionInWorldSpace.z = 0;

        Ray2D rayToMouse = new Ray2D(transform.position, mousePositionInWorldSpace - transform.position);
        var distance = (mousePositionInWorldSpace - transform.position).magnitude;
        RaycastHit2D[] hitObjects = Physics2D.RaycastAll(rayToMouse.origin, rayToMouse.direction, distance, layerMask);
        RaycastUtils.DebugHitInfo(hitObjects);

        if (hitObjects.Length == 0)
        {
            Debug.DrawLine(transform.position, mousePositionInWorldSpace, Color.white);
        }
        else
        {
            Debug.DrawLine(transform.position, hitObjects[0].point, Color.white);
        }
    }
}