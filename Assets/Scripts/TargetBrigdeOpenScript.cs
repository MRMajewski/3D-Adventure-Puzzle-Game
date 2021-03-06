using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBrigdeOpenScript : MonoBehaviour
{
    public BridgeSystemScript bridgeSystem;

    public GameObject greenLight;

    private bool isTriggerOn = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!isTriggerOn)
        {
            bridgeSystem.numberOfBridgesUp++;
            bridgeSystem.TargetShot();
            StartCoroutine(LightOnCoroutine());
            isTriggerOn = true;
        }


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
}
