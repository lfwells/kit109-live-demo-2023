using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenTwoPoints : MonoBehaviour
{
    public Transform start, end;
    public float durationOfMove = 2;

    void Update()
    {
        float percent = Time.timeSinceLevelLoad / durationOfMove;
        transform.position = Vector2.Lerp(start.position, end.position, percent);
    }
}