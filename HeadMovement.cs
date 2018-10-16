using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeadMovement : MonoBehaviour
{

    public GameObject player;
    public Camera cam;
    private Transform playerTransform;
    private Transform camTransform;

    float lowerBound = -10;
    float upperBound = 10;
    float verticalSpeed = 100;
                        // Use this for initialization
    void Start()
    {
        playerTransform = player.transform;
        camTransform = cam.transform;
    }

    void Update()
    {
        player.transform.position = new Vector3(0.0f, Mathf.Clamp(cam.transform.rotation.x * -verticalSpeed, lowerBound, upperBound), player.transform.position.z);
    }
}
