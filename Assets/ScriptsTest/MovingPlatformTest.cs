using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformTest : MonoBehaviour
{
    public Transform firstPos;
    public Transform secondPos;

    public Transform platform;
    public ControlMovingPlatform control;

    public GameObject controlGameObject;

     Vector3 nextPos;
    //Transform nextPos;

    public float speed;
    // Update is called once per frame


    private void Start()
    {
       // platformTest.transform.position = firstPos.position;
        transform.position = firstPos.position;
       // platform.position = firstPos.position;
    }
    void Update()
    {
        if(control.isActive)
   //   if(controlGameObject.GetComponent<ControlMovingPlatform>().isActive)
            MovePlatform();

    }

    public void MovePlatform()
    {
         if(transform.position==firstPos.position)
        {
            nextPos = secondPos.position;
        }
         else if (transform.position ==secondPos.position)
        {
            nextPos = firstPos.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * speed);
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


    //public void MovePlatformTest()
    //{
    //    if (platform.position == firstPos.position)
    //    {
    //        nextPos = secondPos.position;
    //    }
    //    else if (platform.position == secondPos.position)
    //    {
    //        nextPos = firstPos.position;
    //    }
    //    platform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * speed);
    //}

    //public void MovePlatformTest2()
    //{
    //    if (platformTest.transform.position == firstPos.position)
    //    {
    //        nextPos = secondPos.position;
    //    }
    //    else if (platformTest.transform.position == secondPos.position)
    //    {
    //        nextPos = firstPos.position;
    //    }
    //    platformTest.transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * speed);
    //}
}
