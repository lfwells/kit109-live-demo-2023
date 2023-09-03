using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TripWire : MonoBehaviour
{
    public Transform end;
    public LayerMask layerMask;

    //YOU TODO: add UnityEvent public variables here
    public UnityEvent onTripWireBroken;
    public UnityEvent onTripWireUnbroken;

    void Update()
    {
        Ray2D rayToEnd = new Ray2D(transform.position, end.position - transform.position);
        var distance = (end.position - transform.position).magnitude;
        RaycastHit2D hitObject = Physics2D.Raycast(rayToEnd.origin, rayToEnd.direction, distance, layerMask);
        RaycastUtils.DebugHitInfo(hitObject);

        if (hitObject.collider == null)
        {
            Debug.DrawLine(transform.position, end.position, Color.white);

            onTripWireUnbroken.Invoke();
        }
        else
        {
            Debug.DrawLine(transform.position, hitObject.point, Color.red);

            onTripWireBroken.Invoke();
        }
    }
}
