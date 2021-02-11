using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsAutomatedScript : MonoBehaviour
{
    public Vector3 openPosition;
    public Vector3 closePosition;

    public float doorsSpeed;

    public Transform doors;
    // Start is called before the first frame update
    void Start()
    {
        doors.transform.localPosition = closePosition;
    }

    void OpenDoor()
    {
        LeanTween.moveLocal(doors.gameObject, openPosition, doorsSpeed);
     
    }

    void CloseDoor()
    {
        LeanTween.moveLocal(doors.gameObject, closePosition, doorsSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CloseDoor();
        }
    }
}
