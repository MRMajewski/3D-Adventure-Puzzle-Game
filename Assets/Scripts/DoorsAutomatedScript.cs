using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsAutomatedScript : MonoBehaviour
{
    [SerializeField]
    private Vector3 openPosition;
    [SerializeField]
    private Vector3 closePosition;
    [SerializeField]
    private float doorsSpeed;

    [SerializeField]
    private Transform doors;

    [SerializeField]
    private string textOnEnter;

    void Start()
    {
        doors.transform.localPosition = closePosition;
    }

    void OpenDoor()
    {
        UIManager.Instance.RoomEnterUIAnimation(textOnEnter);
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
