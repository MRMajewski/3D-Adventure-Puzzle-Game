using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointScript : MonoBehaviour
{
    public Transform Point;

    public UIManager uiManager;

    protected virtual void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
        {
       
            RespawPlayer(other.gameObject);
        }
       else if (other.GetComponent<PowerUpScript>() != null)
        {
            StartCoroutine(PowerUpDestroyCoroutine(other.gameObject));
           // destroyAnim(other.gameObject);
          //  RespawnPowerUp(other.gameObject);
        }
        else
        {
            destroyAnim(other.gameObject);
            Destroy(other.gameObject,0.5f);
        }

    }

    protected void RespawPlayer(GameObject player)
    {
        uiManager.RespawnAnim();
        player.transform.position = Point.transform.position;
    }

    protected IEnumerator PowerUpDestroyCoroutine(GameObject other )
    {
        destroyAnim(other);
        yield return new WaitForSeconds(0.5f);
        RespawnPowerUp(other);


    }

    protected void RespawnPowerUp(GameObject powerUp)
    {

        powerUp.transform.position = Point.transform.position;
        LeanTween.scale(powerUp, Vector3.one, 0.1f);
    }

    protected void destroyAnim(GameObject other)
    {
        LeanTween.scale(other, Vector3.zero, 0.5f);
    }

}
