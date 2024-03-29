
using System;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posoffset;

    private Vector3 velocity;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posoffset,
            ref velocity, timeOffset);
    }
}
