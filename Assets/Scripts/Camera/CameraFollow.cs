using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothness = 0.5f;

    void Start()
    {
        cameraOffset = transform.position - player.position;
    }

    void Update()
    {
        Vector3 newPosition = player.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothness);
    }
}
