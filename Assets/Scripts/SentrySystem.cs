using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentrySystem : MonoBehaviour
{
    private bool targetInZone;
    public bool TargetInZone { get => targetInZone; }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player")
    //        targetInZone = true;
    //}

    private void OnTriggerEnter(Collider other)
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
