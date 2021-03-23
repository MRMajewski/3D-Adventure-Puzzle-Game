using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameUIScript : MonoBehaviour
{
    public GameObject EndGamePanel;

    private void Start()
    {
 
    }

    private void OnTriggerEnter(Collider other)
    {

        EndGamePanel.SetActive(true);
        LeanTween.scale(EndGamePanel, Vector3.zero, 0f);
        LeanTween.scale(EndGamePanel, Vector3.one, 2f).setEaseOutSine();
    }

}
