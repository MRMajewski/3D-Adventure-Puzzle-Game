using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryOnWall : MonoBehaviour
{
   // [SerializeField]
    private Transform player;
    private bool targetInZone = false;

    [SerializeField]
    private Rigidbody ballPrefab;
    [SerializeField]
    private Transform launchPosition;        //Pozycja z jakiej kula zacznie swój lot
    [SerializeField]
    private float force;                     //Siła wystrzału
    [SerializeField]
    private float destroyDelay;

    [SerializeField]
    private float cooldownTime;//Czas po jakim kula armatnia zostanie zniszczona
    private float coolingTime;

    [SerializeField]
    private float sentrySpeed;
    [SerializeField]
    private float sentrySpeedOnReturn;

    [SerializeField]
    private SentrySystem sentrySystem;

    private Transform target;

    [SerializeField]
    private Transform defaultPos;


    private void Start()
    {
        InitSentry();
    }

    public void InitSentry()
    {
        coolingTime = cooldownTime;
        player = PlayerController.Instance.FirstPersonMovement.transform;
    }

    void Update()
    {
        if (sentrySystem.TargetInZone)
        {
            followTarget(player);

            if (coolingTime > 0)
            {
                coolingTime -= Time.deltaTime;
            }
            else if (coolingTime <= 0)
            {
                if (IsLockedOnTarget())
                {

                    Shoot();
                    coolingTime = cooldownTime;
                }
            }
        }
        else
        {
            coolingTime = 0;
            returnTodefaultPosition();
        }
    }


    private void followTarget(Transform target)
    {
        Vector3 direction = this.transform.position - target.position;
        direction = direction * (-1);

        transform.rotation = Quaternion.RotateTowards
            (transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * sentrySpeed);
    }

    private void returnTodefaultPosition()
    {
        Vector3 direction = this.transform.position - defaultPos.position;
        direction = direction * (-1);

        transform.rotation = Quaternion.RotateTowards
            (transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * sentrySpeedOnReturn);
    }


    private bool IsLockedOnTarget()
    {
        Vector3 direction = this.transform.position - target.position;
        direction = direction * (-1);
        if (transform.rotation == Quaternion.LookRotation(direction))
            return true;
        else return false;

    }

    [ContextMenu("Shoot")]
    public void Shoot()
    {
        Rigidbody missile = Instantiate(ballPrefab, launchPosition.transform.position, launchPosition.transform.rotation);

        missile.AddForce(launchPosition.forward * force, ForceMode.Impulse);
    }

}
