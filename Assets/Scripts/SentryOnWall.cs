using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryOnWall : MonoBehaviour
{
    public Transform player;
    public bool targetInZone = false;

    public Rigidbody ballPrefab;            //Prefab kuli
    public Transform launchPosition;        //Pozycja z jakiej kula zacznie swój lot
    public float force;                     //Siła wystrzału
    public float destroyDelay;

    public float cooldownTime;//Czas po jakim kula armatnia zostanie zniszczona
    public float coolingTime;

    public float sentrySpeed;


    public SentrySystem sentrySystem;


    public Transform target;

    [ContextMenu("Shoot")]


    private void Awake()
    {
          coolingTime = cooldownTime;
    }

    void Update()
    {
        if (sentrySystem.targetInZone)
        {

            //this.transform.LookAt(player);
            //  followTarget(target);
            followTarget(player);

            if (coolingTime > 0)
            {
                coolingTime -= Time.deltaTime;
            }
            else if (coolingTime <= 0)
            {
                Debug.Log(transform.rotation);
                Debug.Log(transform.position - target.position);
                if (IsLockedOnTarget())
                {

                    Shoot();
                    coolingTime = cooldownTime;
                }

              //  }

            }
        }
        else
        {
            coolingTime = 0;
        }
    }

    //private void followTarget(Transform target)
    //{
    //    Vector3 direction =  this.transform.position - target.position;
    //    Debug.Log(direction);
      
    //    Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);

    //    transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, sentrySpeed * Time.deltaTime);
    //}


    private void followTarget(Transform target)
    {
        Vector3 direction = this.transform.position - target.position;
        direction = direction * (-1);

        transform.rotation = Quaternion.RotateTowards
            (transform.rotation, Quaternion.LookRotation(direction), Time.time * sentrySpeed);
    }

    private bool IsLockedOnTarget()
    {
        Vector3 direction = this.transform.position - target.position;
        // direction = new Vector3(direction.x * (-1), direction.y * (-1), direction.z * (-1));
        direction = direction * (-1);
        // Debug.Log(direction);
        if (transform.rotation == Quaternion.LookRotation(direction))
            return true;
        else return false;
       
        
    }

    public void Shoot()
    {
       // Debug.Log("Strzał działa?");
        Rigidbody missile = Instantiate(ballPrefab, launchPosition.transform.position, launchPosition.transform.rotation);

        missile.AddForce(launchPosition.forward * force, ForceMode.Impulse);
       // Destroy(missile.gameObject, destroyDelay);
    }

}
