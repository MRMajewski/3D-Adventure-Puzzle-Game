using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentrySystem : MonoBehaviour
{
    public bool targetInZone = false;

 //   public SentryOnWall sentry;

 //   public float cooldownTime;//Czas po jakim kula armatnia zostanie zniszczona
 //   public float coolingTime;


    //void Update()
    //{
    //    if (targetInZone)
    //    {
    //        if (coolingTime > 0)
    //        {
    //            coolingTime -= Time.deltaTime;
    //        }
    //        else if (coolingTime <= 0)
    //        {
    //            sentry.Shoot();
    //            coolingTime = cooldownTime;

    //        }
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            targetInZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            targetInZone = false;
    }



}
