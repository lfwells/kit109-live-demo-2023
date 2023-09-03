using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RaycastAtMouseOnClick : MonoBehaviour
{
    public LayerMask layerMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //YOU TO-DO: detect whats under the mouse
            Vector2 mousePositionInScreenSpace = Input.mousePosition;
            Debug.Log("screen space: " + mousePositionInScreenSpace);

            Ray ray = GetComponent<Camera>().ScreenPointToRay(mousePositionInScreenSpace);
            Vector3 mousePositionInWorldSpace = ray.origin;
            mousePositionInWorldSpace.z = 0;
            Debug.Log("world space: " + mousePositionInWorldSpace);

            Collider2D[] collidersUnderMouse = Physics2D.OverlapPointAll(mousePositionInWorldSpace, layerMask);
            RaycastUtils.DebugHitInfo(collidersUnderMouse);
        }
    }
}
