using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public Transform firstPos;
    public Transform secondPos;

    public GameObject platform;

    public ControlMovingPlatform control;

    Vector3 nextPos;

    public float speed;

    public bool canBeUsed = false;

    void Update()
    {
 
        if(control.IsActive)
        {
            if (platform.transform.position == firstPos.position)
            {
                nextPos = secondPos.position;
            }
            if (platform.transform.position == secondPos.position)
            {
                nextPos = firstPos.position;
            }
            platform.transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime);
        }
    }

    public void MovePlatformTween()
    {
        LeanTween.move(platform, secondPos, 2f).setLoopPingPong();
    }

    public void MovePlatform()
    {
        if (platform.transform.position == firstPos.position)
        {
            nextPos = secondPos.position;
        }
        if (platform.transform.position == secondPos.position)
        {
            nextPos = firstPos.position;
        }
        platform.transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * speed);
    }

}

