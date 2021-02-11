using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{

    public HandlingQuests handlingQuests;


    void Start()
    {
        handlingQuests = FindObjectOfType<HandlingQuests>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<PickUpScript>();

        if (item == null) return;
        else
        {

            if (other.gameObject == handlingQuests.quest.itemToFound)

                if (other.gameObject.name == handlingQuests.quest.itemToFound.name + "(Clone)")
                    Debug.Log("Znalezione!");
                else
                {
                    Debug.Log("Jakieś barachło");
                }

        }
    }


}
