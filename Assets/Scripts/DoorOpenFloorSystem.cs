using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFloorSystem : MonoBehaviour
{
    public int numberOfDoorsOpen = 0;

    public GameObject[] doors;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PanelOn()
    {
        numberOfDoorsOpen++;
        if (numberOfDoorsOpen > doors.Length ) numberOfDoorsOpen = doors.Length;
        Debug.Log(numberOfDoorsOpen);
        OpenDoors(numberOfDoorsOpen - 1);
    }

    public void PanelOff()
    {
        numberOfDoorsOpen--;
        if (numberOfDoorsOpen < 0) numberOfDoorsOpen = 0;
        Debug.Log(numberOfDoorsOpen);
        CloseDoors(numberOfDoorsOpen);
    }


    public void OpenDoors(int index)
    {
        LeanTween.moveLocalY(doors[index],2.65f, 2f);
    }

    public void CloseDoors(int index)
    {
        LeanTween.moveLocalY(doors[index], 0f, 2f);
    }
}
