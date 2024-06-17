using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothSpeed = 0.125f;
    public Vector3 offsetDistance;

    void Start()
    {
        offsetDistance = transform.position - playerTransform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (!playerTransform) return;
        Vector3 goalPosition = playerTransform.position + offsetDistance;
        transform.position = Vector3.Lerp(transform.position, goalPosition, smoothSpeed);
    }
}
