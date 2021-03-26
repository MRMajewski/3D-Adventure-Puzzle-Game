using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TakingDamageScript : MonoBehaviour
{
    public PostProcessVolume postProcessing;
    private bool isActiveGrain = false;
    public float time = 2f;
    public Grain grain;

    [ContextMenu("TakeDamage")]


    //void Update()
    //{ 
    //    if(Input.GetKeyUp(KeyCode.E))
    //    {
    //        TakeDamage();
    //    }
    //}

    public void TakeDamage()
    {
        postProcessing.profile.TryGetSettings(out grain);

        StartCoroutine(TakingDamageCoroutine(time));
        Debug.Log("Funkcja TakeDamage działa");
    }

    IEnumerator TakingDamageCoroutine(float time)
    { 



        grain.enabled.value = true;

        yield return new WaitForSeconds(time);

        grain.enabled.value = false;
    }
}
