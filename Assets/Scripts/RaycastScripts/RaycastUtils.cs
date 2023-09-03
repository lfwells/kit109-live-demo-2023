using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RaycastUtils
{

    public static void DebugHitInfo(Collider2D[] hitInfo)
    {
        foreach (var hit in hitInfo)
        {
            if (hit == null) continue;

            Debug.Log (hit.name, hit.gameObject);
            DebugHitInfo(hit);
        }
    }
    public static void DebugHitInfo(Collider2D[] hitInfoBuffer, int hitCount)
    {
        for (var i = 0; i < hitCount; i++)
        {
            var hit = hitInfoBuffer[i];
            Debug.Log(hit.name, hit.gameObject);
            DebugHitInfo(hit);
        }
    }

    public static void DebugHitInfo(RaycastHit2D[] hitInfo)
    {
        foreach (var hit in hitInfo)
        {
            //Debug.Log (hit.collider.name);
            DebugHitInfo(hit);
        }
    }
    public static void DebugHitInfo(RaycastHit2D[] hitInfoBuffer, int hitCount)
    {
        for (var i = 0; i < hitCount; i++)
        {
            var hit = hitInfoBuffer[i];
            DebugHitInfo(hit);
        }
    }

    public static void DebugFirstHit(RaycastHit2D[] hitInfo)
    {
        if (hitInfo.Length > 0)
        {
            DebugHitInfo(hitInfo[0]);
        }
    }

    public static void DebugHitInfo(RaycastHit2D hitInfo)
    {
        Debug.DrawLine(hitInfo.point, hitInfo.point + hitInfo.normal, Color.red);
    }
    public static void DebugHitInfo(Collider2D hitInfo)
    {
        float gizmoSize = 0.25f; float duration = 0f;
        Debug.DrawLine((Vector2)hitInfo.transform.position - new Vector2(-1, -1) * gizmoSize, (Vector2)hitInfo.transform.position - new Vector2(1, 1) * gizmoSize, Color.red, duration);
        Debug.DrawLine((Vector2)hitInfo.transform.position - new Vector2(-1, 1) * gizmoSize, (Vector2)hitInfo.transform.position - new Vector2(1, -1) * gizmoSize, Color.red, duration);
    }
    public static void RayCastOffNormal(Vector2 originalRayOrigin, RaycastHit2D originalRaycastHit, LayerMask layerMask, int repeats)
    {
        //Draw the normal, because that is useful
        DebugHitInfo(originalRaycastHit);

        //prepare a new ray 
        var ray = new Ray2D();
        
        //set the origin of the ray to be the hit point of the original raycast
        //offset the origin of the new ray, so that we don't collide with ourselves
        ray.origin = originalRaycastHit.point + originalRaycastHit.normal * 0.01f;

        //set the direction of the ray to reflect off the normal
        ray.direction = Vector3.Reflect(originalRaycastHit.point - originalRayOrigin, originalRaycastHit.normal);

        //cast the ray
        var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layerMask);

        //draw a line between the two points (if something was hit at all)
        if (hit.collider != null)
        {
            Debug.DrawLine(ray.origin, hit.point, Color.white);

            //recursively call this function, only if the repeats parameter says we should
            repeats--;
            if (repeats > 0)
            {
                RayCastOffNormal(ray.origin, hit, layerMask, repeats);
            }
        }    
    }
}
