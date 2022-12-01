using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    [Range(0,1)][SerializeField] float smoothSpeed = 0.125f;

    [SerializeField]Vector3 offset;

    void LateUpdate()
    {
        Vector3 finalPosition = new Vector3(target.position.x + offset.x,transform.position.y,target.position.z+offset.z);
        Vector3 smoothPosition = Vector3.Lerp(transform.position,finalPosition,smoothSpeed);
        transform.position = smoothPosition;
    }
}
