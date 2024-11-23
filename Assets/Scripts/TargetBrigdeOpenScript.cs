using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBrigdeOpenScript : MonoBehaviour
{
    [SerializeField]
    private BridgeSystemScript bridgeSystem;

    [SerializeField]
    private GameObject greenLight;

    private bool isTriggerOn = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!isTriggerOn)
        {
          
            bridgeSystem.TargetShot();
            bridgeSystem.NumberOfBridgesUp++;
            StartCoroutine(LightOnCoroutine());
            isTriggerOn = true;
        }
    }

    IEnumerator LightOnCoroutine()
    {
        float progress = 0f;

        while (progress < 1.5f)
        {
            greenLight.GetComponent<Light>().intensity = Mathf.Lerp(0, 10, progress);
            yield return new WaitForEndOfFrame();
            progress += Time.deltaTime;
        }
    }
}
