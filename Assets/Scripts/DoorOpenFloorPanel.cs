using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFloorPanel : MonoBehaviour
{

    public DoorOpenFloorSystem doorSystem;
    public GameObject greenLight;

    private bool isTriggerOn = false;
    private int numberOfObjectsOnTrigger = 0;

    private void Start()
    {
        greenLight.GetComponent<Light>().intensity =0;
        numberOfObjectsOnTrigger = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        numberOfObjectsOnTrigger++;
        if (!isTriggerOn)
        {
          

            Debug.Log("Ilość obiektów na wejściu w trigger: " + numberOfObjectsOnTrigger);
         //   doorSystem.numberOfDoorsOpen++;
            doorSystem.PanelOn();
            StartCoroutine(LightOnCoroutine());
            isTriggerOn = true;
        }
    
    }

    private void OnTriggerExit(Collider other)
    {

        numberOfObjectsOnTrigger--;
        if (isTriggerOn&&numberOfObjectsOnTrigger==0)
        {
         //   
            Debug.Log("Ilość obiektów po wyjściu z triggera: " + numberOfObjectsOnTrigger);
          //  if (numberOfObjectsOnTrigger<=0)
         //   {
                doorSystem.PanelOff();
                StartCoroutine(LightOffCoroutine());
                isTriggerOn = false;
         //   doorSystem.numberOfDoorsOpen--;

        }

        //  if (doorSystem.numberOfDoorsOpen-- < 0)
        //      doorSystem.numberOfDoorsOpen = 0;

    }

    IEnumerator LightOnCoroutine()
    {
        float progress = 0f;

        while (progress < 1.5f)
        {
            greenLight.GetComponent<Light>().intensity = Mathf.Lerp(0, 60, progress);
            yield return new WaitForEndOfFrame();
            progress += Time.deltaTime;
        }
    }

    IEnumerator LightOffCoroutine()
    {
        float progress = 0f;

        while (progress < 1.5f)
        {
            greenLight.GetComponent<Light>().intensity = Mathf.Lerp(60, 0, progress);
            yield return new WaitForEndOfFrame();
            progress += Time.deltaTime;
        }
    }
}
