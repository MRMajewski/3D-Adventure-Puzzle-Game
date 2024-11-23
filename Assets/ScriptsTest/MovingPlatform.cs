using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool isGoingBack = false;

    [SerializeField]
    private ControlMovingPlatform control;

    [SerializeField]
    private bool isRouteLonger = false;

    [SerializeField]
    private Transform[] route;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int routeIndex = 0;

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
