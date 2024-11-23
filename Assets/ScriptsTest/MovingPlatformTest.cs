using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformTest : MonoBehaviour
{

    public bool isGoingBack = false;

    public Transform platform;
    public ControlMovingPlatform control;

    public bool isRouteLonger = false;

    public Transform[] route;

     Vector3 nextPos;
    //Transform nextPos;

    public float speed;

    public int routeIndex=0;

    private void Start()
    {
        transform.position = route[0].position;

    }
    void Update()
    {
        if (control.IsActive)

            MovePlatform(route);

    }
    public void MovePlatform(Transform[] route)
    {
        transform.position = Vector3.MoveTowards(transform.position, route[routeIndex].position, Time.deltaTime * speed);

        if (transform.position == route[routeIndex].position) routeIndex++;

        if (routeIndex == route.Length)
        {

            Array.Reverse(route);
            routeIndex = 0;
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {        
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }

}
