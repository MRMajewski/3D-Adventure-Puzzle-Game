using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointScript : MonoBehaviour
{
    public Transform Point;

    public UIManager uiManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
        {
         //   uiManager.RespawnAnim();
            RespawPlayer(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }

    }

    private void RespawPlayer(GameObject player)
    {
        uiManager.RespawnAnim();
        player.transform.position = Point.transform.position;
    }
}
