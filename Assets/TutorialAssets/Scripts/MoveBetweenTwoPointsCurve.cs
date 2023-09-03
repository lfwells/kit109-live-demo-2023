using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenTwoPointsCurve : MonoBehaviour
{
    public Transform start, end;
    public float durationOfMove = 2;
    public AnimationCurve curve;

    void Update()
    {
        float percent = curve.Evaluate(Time.timeSinceLevelLoad / durationOfMove);
        transform.position = Vector2.Lerp(start.position, end.position, percent);
    }
}