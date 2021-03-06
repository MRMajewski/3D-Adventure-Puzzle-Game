using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsAutomatedScript : MonoBehaviour
{
    public Vector3 openPosition;
    public Vector3 closePosition;

    public UIManager UIManager;

    public float doorsSpeed;

    public Transform doors;

    public string textOnEnter;
    // Start is called before the first frame update

    private void Awake()
    {
        UIManager = FindObjectOfType<UIManager>();
    }


    void Start()
    {
        doors.transform.localPosition = closePosition;
    }

    void OpenDoor()
    {
        UIManager.RoomEnterUIAnimation(textOnEnter);
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
