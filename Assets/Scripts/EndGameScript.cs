using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : RespawnPointScript
{
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
        UIManager.Instance.EndGameAnim();
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}
