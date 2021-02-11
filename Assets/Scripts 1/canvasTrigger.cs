using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasTrigger : MonoBehaviour
{
    public GameObject menu; // Assign in inspector
     private bool isShowing;
 
     void Update() {
         if (Input.GetKeyDown("x")) {
             isShowing = !isShowing;
             menu.SetActive(isShowing);
         }
     }
}
