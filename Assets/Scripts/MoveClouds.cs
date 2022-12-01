using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    float timeElapsed;
    [SerializeField] float desiredDuration = 3f;
    bool beginLerp = false;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        float percentegeComplete = timeElapsed/desiredDuration;

        if(transform.position == pointA.position) { beginLerp = true; }

        if (beginLerp) 
        { 
            transform.position = Vector3.Lerp(pointA.position, pointB.position, percentegeComplete); 
        }

        if(transform.position == pointB.position)
        {
            transform.position = pointA.position;
            timeElapsed = 0f;
        }


    }

}
