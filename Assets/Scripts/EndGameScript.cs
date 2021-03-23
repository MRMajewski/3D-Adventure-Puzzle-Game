using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : RespawnPointScript
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EndGame();
        }
        else if (other.GetComponent<PowerUpScript>() != null)
        {
            StartCoroutine(PowerUpDestroyCoroutine(other.gameObject));

        }
        else
        {
            destroyAnim(other.gameObject);
            Destroy(other.gameObject, 0.5f);
        }

    }

    private void EndGame()
    {
        StartCoroutine(EndGameCoroutine());
    }

    IEnumerator EndGameCoroutine()
    {
        uiManager.EndGameAnim();
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }


}
