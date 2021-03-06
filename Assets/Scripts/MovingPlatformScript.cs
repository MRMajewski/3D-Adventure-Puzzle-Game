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

    // Start is called before the first frame update
    void Start()
    {
      //  platform.transform.position = firstPos.position;
       //  MovePlatform();
    }

    // Update is called once per frame
    void Update()
    {
 
        if(control.isActive)
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

       // platform.transform.position = Vector3.Lerp(firstPos.position, secondPos.position, Time.deltaTime * speed);
     //   }
    //    else if (platform.transform.position==secondPos.position)
    //    {
         //   platform.transform.position = Vector3.Lerp(secondPos.position, firstPos.position, Time.deltaTime * speed);
      //  }
       
    
}

