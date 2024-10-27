using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointScript : MonoBehaviour
{
    [SerializeField]
    private Transform Point;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RespawPlayer(other.gameObject);
        }
        else if (other.GetComponent<PowerUpScript>() != null)
        {
            StartCoroutine(PowerUpDestroyCoroutine(other.gameObject));

        }
        else
        {
            AudioManager.Instance.Play("Destroy");
            destroyAnim(other.gameObject);
            Destroy(other.gameObject, 0.5f);
        }
    }

    protected void RespawPlayer(GameObject player)
    {
        UIManager.Instance.RespawnAnim();
        AudioManager.Instance.Play("RespawnPlayer");
        player.transform.position = Point.transform.position;
    }

    protected IEnumerator PowerUpDestroyCoroutine(GameObject other)
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
